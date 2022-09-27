using Microsoft.EntityFrameworkCore;
using Model;
using Server;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddType<ToDo>()
    .AddType<ToDoStatus>();


const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins,
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings")!));

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();