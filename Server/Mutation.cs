using Model;

namespace Server;

public class Mutation
{
    public async Task<ToDo> AddTodo([Service] Context context, ToDo todo)
    {
        context.ChangeTracker.AutoDetectChangesEnabled = false;        
        context.ToDos.Add(new ()
        {
            Id = 12
        });
        await context.SaveChangesAsync();
        return todo;
    }
}