Normally, I store all my data in JSON or just binary. I am still in the mental process of switching over to SQL for all
reusable data.

Using secrets, cmd to generate rough models.

```bash
dotnet ef dbcontext scaffold Name=ConnectionStrings:Ex Microsoft.EntityFrameworkCore.SqlServer --schema ex -o ../Model/Models -F
```

Auto generated context.

```csharp
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDo> ToDos { get; set; } = null!;
    public virtual DbSet<ToDoStatus> ToDoStatuses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:Ex");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("ToDo", "ex");

            entity.Property(e => e.Description).HasMaxLength(255);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.Property(e => e.StatusKey).HasMaxLength(50);

            entity.HasOne(d => d.Status)
                .WithMany()
                .HasForeignKey(d => d.StatusKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StatusKey_ToDoStatus_Key");
        });

        modelBuilder.Entity<ToDoStatus>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("ToDoStatus", "ex");

            entity.Property(e => e.Key).HasMaxLength(50);

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.Property(e => e.Value).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
```

Auto generated ToDo.

```csharp
namespace Model;

public partial class ToDo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string StatusKey { get; set; } = null!;
    public virtual ToDoStatus Status { get; set; } = null!;
}
```

Auto generated ToDo Status.

```csharp
namespace Model;

public partial class ToDoStatus
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Description { get; set; } = null!;
}
```