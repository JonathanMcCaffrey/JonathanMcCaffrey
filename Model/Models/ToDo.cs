using System.ComponentModel.DataAnnotations;

namespace Model;

public class ToDo
{
    [Required]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? RandomChange { get; set; }
    public string? RandomChange2 { get; set; }
    public string StatusKey { get; set; } = null!;
    public virtual ToDoStatus Status { get; set; } = null!;
}