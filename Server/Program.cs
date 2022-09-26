using Microsoft.EntityFrameworkCore;
using Server;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddType<ToDo>()
    .AddType<ToDoStatus>();

var connectionString = builder.Configuration["ConnectionStrings:Ex"];

builder.Services.AddDbContext<jonathanmccaffreyContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();