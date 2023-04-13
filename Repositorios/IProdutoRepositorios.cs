using PhoenixCRUD.Models;

namespace PhoenixCRUD.Repositorios
{
    interface IProdutoRepositorios
    {
        public List<Produto> Get();
        public Produto Get(int id);
        public void Insert(Produto produto);
        public void Update(Produto produto);
        public void Delete(int id);
    }
}