using Injecao_Dependencia.Models.Contracts;

namespace Injecao_Dependencia.Models
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
