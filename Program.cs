using Injecao_Dependencia.Models;
using Injecao_Dependencia.Models.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOperacao, Operacao>();
builder.Services.AddTransient<IOperacao, SegundaOperacao>();
builder.Services.AddSingleton<IOperacao, TerceiraOperacao>();

var app = builder.Build();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
