using System.ComponentModel.DataAnnotations;

namespace Model;

public partial class ToDoStatus
{
    [Key]
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Description { get; set; } = null!;
}