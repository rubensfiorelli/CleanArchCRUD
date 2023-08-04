using FiorelliDev.Domain.Validations.Interfaces;
using Royal.Domain.Validations;

namespace FiorelliDev.Domain.Entities
{
    public class Produto : BaseEntity, IContract
    {
        public Produto(string nome, string descricao, decimal preco, int estoque, string imgUrl)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            ImgUrl = imgUrl;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string ImgUrl { get; private set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; private set; }

        public override bool Validate()
        {
            var contracts = new ContractValidations<Produto>()
                     .NomeIsOk(Nome, 3, 15, "O nome precisa ter entre 3 e 15 caracteres", "Categoria")
                     .DescricaoIsOk(Nome, 10, 100, "O campo precisa ter entre 10 e 100 caracteres", nameof(Nome))
                     .PrecoIsOk(1, "O valor não pode ser menor ou igual a zero", "Preco produto")
                     .EstoqueIsOk(1, "O valor não pode ser menor ou igual a zero", nameof(Estoque))
                     .ImgUrlIsOk(ImgUrl, "O campo imagem nao pode ser vazio", "Imagem do produto");

            return contracts.IsValid();

        }

        public void SetProduto(string newNome, string newDescricao, decimal newPreco, int newEstoque, string newImgUrl)
        {

            Nome = newNome;
            Descricao = newDescricao;
            Preco = newPreco;
            Estoque = newEstoque;
            ImgUrl = newImgUrl;
        }

    }
}

