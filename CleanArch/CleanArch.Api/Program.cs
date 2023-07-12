using CleanArch.Data.Context;
using CleanArch.Grapghql.Query;
using CleanArch.IoC;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterAutoMapper();

builder.Services.AddDbContext<ProductDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDatabaseConnection"));
}, optionsLifetime: ServiceLifetime.Scoped);

DependencyContainer.RegisterServices(builder.Services);

builder.Services.AddGraphQLServer().AddQueryType<ProductQuery>().AddMutationType<ProductMutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL(path: "/graphql");

app.Run();
