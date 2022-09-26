namespace Server;

public class Query
{
    [UseProjection]
    public IEnumerable<ToDo> GetToDos([Service] jonathanmccaffreyContext context) =>
        context.ToDos.Select(todo => new ToDo()
        {
            Id = todo.Id,
            Description = todo.Description,
            Name = todo.Name,
            StatusKey = todo.StatusKey,
            StatusKeyNavigation = new ToDoStatus()
            {
                Key = todo.StatusKeyNavigation.Key,
                Description = todo.StatusKeyNavigation.Description,
                Value = todo.StatusKeyNavigation.Value
            }
        });
}