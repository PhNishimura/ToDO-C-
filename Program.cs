var builder = WebApplication.CreateBuilder(args);
var app  = builder.Build();

//banco de dados FAKE
var tarefas = new List<Tarefa>
{
    new(1, "Configurar ambiente C# no VS Code", true),
    new(2, "Criar primeira Minimal API", false)
};

//1 rota GET LISTAR TAREFAS

app.MapGet("/tarefas", () =>
{
    return Results.Ok(tarefas);
});

//2 Rota get por id: Buscar tarefa por id 
app.MapGet("/tarefas/{id}", (int id) =>
{
    var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

    //caso nao acha retorna 400
    return tarefa is not null ? Results.Ok(tarefa) : Results.NotFound("Tarefa não encontrada");
});

//3 Rota Post: Criar um nova tarefa
app.MapPost("/tarefas", (NovaTarefaDto novaTarefa) =>
{
    //gera um id auto somando o maior +1 
    int novoId = tarefas.Count > 0 ? tarefas.Max(t => t.Id) + 1 : 1;

    var tarefaCriada = new Tarefa(novoId, novaTarefa.Titulo, false);
    tarefas.Add(tarefaCriada);

    //retorna 201 cretead
    return Results.Created($"/tarefas/{tarefaCriada.Id}", tarefaCriada);
});

//4 Rota Put: Atualizar uma tarefa
app.MapPut("/tarefas/{id:int}/concluir", (int id) => 
{
    var index = tarefas.FindIndex(t => t.Id == id);
    if (index == -1) return Results.NotFound();

    // Records são imutáveis, então usamos 'with' para criar uma cópia alterando só o 'Concluida'
    tarefas[index] = tarefas[index] with { Concluida = true };

    return Results.Ok(tarefas[index]);
}); 

//5 rota delete

app.MapDelete("/tarefas/{id:int}", (int id) =>
{
    var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null) return Results.NotFound();

    tarefas.Remove(tarefa);
    return Results.NoContent();

});

app.Run();

// --- MODELOS DE DADOS (Records) ---
// 'record' é um recurso moderno do C# perfeito para transportar dados sem precisar escrever getters/setters
record Tarefa(int Id, string Titulo, bool Concluida);
record NovaTarefaDto(string Titulo);