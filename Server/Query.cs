using Model;

namespace Server;

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