# Injeção Dependência

https://www.notion.so/Dominando-Inje-o-de-Depend-ncia-8f540c704fab48c88944625df558183c?pvs=4#9688e695293e45388046e5c639874a70

*Não é um padrão (Design Pattern);
*Técnica que implementa o IoC:
  *Inversão de Controle
  *DIP
*Ajuda no baixo acoplamento;
*Provê uma melhor divisão de responsabilçidades.

# I. Baixo Acoplamento

*Tem que funcionar de forma independente;
*Fácil de entender;
*Fácil de manutenção;
*Se precisar joga fora e cria outro é facil.

# II. Inversão de Controle

*Externaliza as responsabilidaddes (Delega);
*Cria uma dependência externa.

# III. Porque Abstrair?

*Facilita a mudanças (ex: troca de um banco de dados)
*Teste de Unidade (não pode depender de banco, rede ou qualuqer outra coisa externa);
*Se você depende da abstração, a implementação não importa.

# IV. Princípio da Inversão de Dependência (DIP)

*Principio da inversão de dependência;
*Depende de abstração e não de implementações

# V. AddScoped, AddTransient, AddSingleton

Há quatro modos de vida para um serviço que está sendo injetado:
1. Singleton : Um objeto do serviço é criado e fornecido para todas as requisições. Assim, todas as requisições obtém o mesmo objeto;
2. Escoped : Um objeto do serviço é criado para cada requisição. Dessa forma, cada requisição obtém uma nova instância do serviço;
3. Transient : Um objeto do serviço é criado toda a vez que um objeto for requisitado (Ex: 200).

# DI, IoC e DIP na Prática.

* 1 - Classe Abstrata:

namespace Injecao_Dependencia.Models.Contracts
{
    public interface IOperacao
    {
        Guid Id { get; set; }

    }
}

using Injecao_Dependencia.Models.Contracts;

namespace Injecao_Independencia.Models
{
    public class Operacao : IOperacao
    {
        public Guid Id { get; set; }

        public Operacao()
        {
            Id = Guid.NewGuid();

        }

    }

}


* 2 - Criando dependência

using Injecao_Dependencia.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Injecao_Dependencia.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOperacao _operacao; 
       
        public HomeController(IOperacao operacao) //a ID deve ser inserida no construtor
        {
            _operacao = operacao;
            
        }

      [...] => Vrebos a ser criados
    }
}


* 3 - Implementando no Controller

using Injecao_Dependencia.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Injecao_Dependencia.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOperacao _operacao;
        private readonly IServiceProvider _provider;


        public HomeController(
            IOperacao operacao,
            IServiceProvider provider)
        {
            _operacao = operacao;
            _provider = provider;

        }

        [HttpGet("Construtor")] //criando ID com metodo construtor + utilizada
        public IActionResult Construtor()
        {
            return Ok(_operacao.Id);
        }

        [HttpGet("Anotacao")] //criando ID com metodo Anotação - é só inseriri [FromServices]
        public IActionResult Anotacao([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }

        [HttpGet("Provider")] //Metodo Provider é omais complexo.
        public IActionResult Provider()
        {
            return Ok(_provider.GetRequiredService<IOperacao>());
        }
    }
}

* 4 - Incluindo a ID no Program.

using Injecao_Dependencia.Models;
using Injecao_Dependencia.Models.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOperacao, Operacao>();
/*A ID pode ser incluida como AddScoped, AddTransient, AddSingleton, conforme artigo 
anterior.*/

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
