using Injecao_Dependencia.Models.Contracts;

namespace Injecao_Dependencia.Models
{
    public class TerceiraOperacao : IOperacao
    {
        public Guid Id { get; set; }

        public TerceiraOperacao() 
        {        
            Id = Guid.NewGuid();
        }
    }
}
