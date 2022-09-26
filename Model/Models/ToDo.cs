namespace Model;

public partial class ToDo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string StatusKey { get; set; } = null!;
    public virtual ToDoStatus Status { get; set; } = null!;
}