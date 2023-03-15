using Injecao_Dependencia.Models;
using Injecao_Dependencia.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Injecao_Dependencia.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOperacao _operacao;
        private readonly IEnumerable<IOperacao> _operacoes;

        public HomeController(IOperacao operacao, IEnumerable<IOperacao> operacoes)
        {
            _operacao = operacao;
            _operacoes = operacoes;
        }
        

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(new
            {
                Primeira = _operacoes.FirstOrDefault(x => x is Operacao).Id,
                Segunda = _operacoes.FirstOrDefault(x => x is SegundaOperacao).Id,
                Terceira = _operacoes.FirstOrDefault(x => x is TerceiraOperacao).Id,
            });
        }

       
    }
}