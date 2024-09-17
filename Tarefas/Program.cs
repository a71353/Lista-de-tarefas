using Microsoft.EntityFrameworkCore;
using Tarefas.Data;  // Substitua "SeuProjeto" pelo namespace correto

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adiciona o DbContext ao contêiner de serviços, usando a string de conexão do appsettings.json
builder.Services.AddDbContext<TarefaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TarefaContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tarefas}/{action=Index}/{id?}");

app.Run();
