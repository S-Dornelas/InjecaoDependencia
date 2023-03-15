using Injecao_Dependencia.Models.Contracts;

namespace Injecao_Dependencia.Models
{
    public class SegundaOperacao : IOperacao
    {
        public Guid Id { get; set; }

        public SegundaOperacao()
        {
            Id = Guid.NewGuid();            
        }
    } 

}
