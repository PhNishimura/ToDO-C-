# 📝 TodoApi — Minha Primeira API em C#

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Minimal%20API-5C2D91?style=for-the-badge)

Uma API RESTful simples de lista de tarefas (**To-Do List**) desenvolvida com **C#** e **ASP.NET Core Minimal APIs**.  
Este é o meu primeiro projeto em C#, criado para aprender os fundamentos do ecossistema .NET na prática! 🚀

---

## ✨ Funcionalidades

- 📋 Listar todas as tarefas cadastradas
- 🔍 Buscar uma tarefa específica por ID
- ➕ Criar novas tarefas com geração automática de ID
- ✅ Marcar tarefas como concluídas
- 🗑️ Remover tarefas existentes

> **Nota:** Os dados são armazenados em memória (`List<Tarefa>`), iniciando com duas tarefas de exemplo. Ao reiniciar a aplicação, a lista volta ao estado inicial.

---

## 🛠️ Tecnologias e Conceitos Praticados

- **C#** & **.NET 10**
- **ASP.NET Core Minimal APIs** (`MapGet`, `MapPost`, `MapPut`, `MapDelete`)
- **Records e Imutabilidade** (`record` e expressão `with` para atualizar registros)
- **DTOs** (`NovaTarefaDto` para entrada de dados)
- **LINQ** (`FirstOrDefault`, `FindIndex`, `Max`)
- **Boas práticas REST** com códigos de status HTTP (`200 OK`, `201 Created`, `204 No Content`, `404 Not Found`)

---

## 📁 Estrutura do Projeto

```text
TodoApi/
├── Properties/
│   └── launchSettings.json   # Perfis e portas locais da aplicação
├── Program.cs                # Configuração da Minimal API, rotas e modelos
├── TodoApi.csproj            # Configurações do projeto (.NET 10)
├── appsettings.json          # Configurações da aplicação
├── teste.http                # Requisições prontas para testar os endpoints
└── README.md
```

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado na máquina.

### Passo a passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/PhNishimura/ToDO-C-.git
   cd ToDO-C-
   ```

2. Execute a aplicação:
   ```bash
   dotnet run
   ```

3. A API estará disponível em:
   ```text
   http://localhost:5202
   ```

---

## 📡 Endpoints da API

| Método | Rota | Descrição | Status de Retorno |
| :--- | :--- | :--- | :--- |
| `GET` | `/tarefas` | Lista todas as tarefas | `200 OK` |
| `GET` | `/tarefas/{id}` | Busca uma tarefa pelo ID | `200 OK` / `404 Not Found` |
| `POST` | `/tarefas` | Cria uma nova tarefa | `201 Created` |
| `PUT` | `/tarefas/{id}/concluir` | Marca a tarefa como concluída | `200 OK` / `404 Not Found` |
| `DELETE` | `/tarefas/{id}` | Remove uma tarefa pelo ID | `204 No Content` / `404 Not Found` |

### Exemplos de Requisição e Resposta

#### Criar uma tarefa (`POST /tarefas`)
**Body (JSON):**
```json
{
  "titulo": "Estudar Entity Framework"
}
```

**Resposta (`201 Created`):**
```json
{
  "id": 3,
  "titulo": "Estudar Entity Framework",
  "concluida": false
}
```

---

## 🧪 Como Testar

### Opção 1: Usando o arquivo `teste.http` (VS Code)
1. Instale a extensão **REST Client** no VS Code.
2. Abra o arquivo [`teste.http`](./teste.http).
3. Com a API rodando (`dotnet run`), clique em **Send Request** acima de cada requisição.

### Opção 2: Usando `curl` no terminal
```bash
# Listar todas as tarefas
curl http://localhost:5202/tarefas

# Criar uma nova tarefa
curl -X POST http://localhost:5202/tarefas \
  -H "Content-Type: application/json" \
  -d '{"titulo": "Estudar Entity Framework"}'

# Concluir a tarefa 2
curl -X PUT http://localhost:5202/tarefas/2/concluir

# Deletar a tarefa 1
curl -X DELETE http://localhost:5202/tarefas/1
```

---

## 🗺️ Próximos Passos (Ideias de Evolução)

- [ ] Persistência de dados com **Entity Framework Core** + SQLite / PostgreSQL
- [ ] Documentação interativa com **OpenAPI / Swagger**
- [ ] Validação de entrada (ex.: impedir títulos vazios)
- [ ] Rota para editar o título de uma tarefa
- [ ] Testes automatizados (unitários e de integração)

---

Feito com dedicação durante meus primeiros passos em **C# e .NET** 💻✨
