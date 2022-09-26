using System;
using System.Collections.Generic;

namespace Server
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string StatusKey { get; set; } = null!;

        public virtual ToDoStatus StatusKeyNavigation { get; set; } = null!;
    }
}
