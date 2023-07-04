using FullStackKanbanAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FullStackKanBanDBContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("FullStackKanBanConnectionString"))); // creating DB and connecting to SQL server 
 
// commuicating to the server and using the NuGets to create a SQL server and DB tables 
// for the creation of the DB the console commands needed inside of the NuGet Console is :

// Add-Migration "" |  this will inilize the migration and gives it a massage
// Update-Database  |  this will update the database giveing us the ability to see the new database within SQL 



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
