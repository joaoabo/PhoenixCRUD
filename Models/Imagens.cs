
namespace PhoenixCRUD.Models
{
    public class Imagens
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo_Imagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public int ProdutoId { get; set; }
    }
}