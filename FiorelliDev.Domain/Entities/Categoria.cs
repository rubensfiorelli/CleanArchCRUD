using FiorelliDev.Domain.Validations.Interfaces;
using Royal.Domain.Validations;

namespace FiorelliDev.Domain.Entities
{
    public class Categoria : BaseEntity, IContract
    {
        public Categoria(string nome)
        {
            Nome = nome;
            Produtos = new List<Produto>();
        }


        public string Nome { get; private set; }
        public virtual List<Produto> Produtos { get; set; }



        public override bool Validate()
        {
            var contracts = new ContractValidations<Categoria>()
                     .NomeIsOk(Nome, 3, 15, "O nome precisa ter entre 3 e 15 caracteres", "Nome da categoria");

            return contracts.IsValid();
        }

        public void SetCategoria(string newNome)
        {
            Nome = newNome;
        }

    }
}
