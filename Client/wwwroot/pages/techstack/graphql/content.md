Graph QL

Setting up the GraphQL Service

```csharp
builder.Services.AddScoped<IGraphQLClient>(s =>
    new GraphQLHttpClient(
        "https://localhost:7113/graphql",
        new NewtonsoftJsonSerializer())
);
```

Querying ToDos from an API Server.

```csharp
@code {
    List<ToDo>? _todos;

    public class Response
    {
        public List<ToDo> toDos { get; set; }
    }

    protected override async Task OnInitializedAsync()
    {
        var query = new GraphQLRequest
        {
            Query = @"query todo {
                      toDos {
                        id
                        name
                        description
                        statusKey
                        status {
                          key
                          value
                          description
                        }
                      }
                    }
                    "
        };

        _todos = (await GraphQlClient.SendQueryAsync<Response>(query)).Data.toDos;
    }

}
```

## API Server Setup

Setting up the GraphQL Service.

```csharp
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddType<ToDo>()
    .AddType<ToDoStatus>();
```

Mapping GraphQL Queries and Mutations

```csharp
app.MapGraphQL();
```


Writing the ToDos query in the API Server.

```csharp
public class Query
{
    [UseProjection]
    public IEnumerable<ToDo> GetToDos([Service] Context context) =>
        context.ToDos.Select(todo => new ToDo()
        {
            Id = todo.Id,
            Description = todo.Description,
            Name = todo.Name,
            StatusKey = todo.StatusKey,
            Status = new ToDoStatus()
            {
                Key = todo.Status.Key,
                Description = todo.Status.Description,
                Value = todo.Status.Value
            }
        });
}
```

