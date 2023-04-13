
using System.Data;
using System.Data.SqlClient;
using PhoenixCRUD.Models;
using Dapper;

namespace PhoenixCRUD.Repositorios
{
    public class ProdutoRepositorios : IProdutoRepositorios
    {
        private IDbConnection _conexao;
        public ProdutoRepositorios()
        {
            _conexao = new SqlConnection("data source=SERVIDOR; initial catalog=DATABASE; user id=USERNAME ; password=PASSWORD; multipleactiveresultsets=true;");
        }
        public Produto Get(int id)
        {
            return _conexao.QuerySingleOrDefault<Produto>($"select * from Produto where id = {id}");
        }
        public List<Produto> Get()
        {
            string query = "select * from Produto as p left join Categoria as c on c.id = p.categoriaId";
            return _conexao.Query<Produto, Categoria, Produto>(query, (produto, categoria) =>
            {
                produto.Categoria = categoria;
                return produto;
            }).ToList();
        }
        public void Insert(Produto produto)
        {
            _conexao.Open();
            var transaction = _conexao.BeginTransaction();
            try
            {
                string Sql = "INSERT INTO Produto(Nome, Descricao, Preco, Quantidade, dataCriacao, CategoriaId) VALUES (@Nome, @Descricao, @Preco, @Quantidade, @dataCriacao, @CategoriaId); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                produto.Id = _conexao.Query<int>(Sql, produto, transaction).Single();
                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Erro ao inserir o produto {produto.Nome}: {ex.Message}";
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
        public void Update(Produto produto)
        {
            _conexao.Open();
            var transaction = _conexao.BeginTransaction();
            try
            {
                string Sql = "UPDATE Produto SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, Quantidade = @Quantidade, dataCriacao = @dataCriacao, CategoriaId = @CategoriaId WHERE Id = @Id";
                _conexao.Execute(Sql, produto, transaction);
                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Erro ao alterar o produto {produto.Nome}: {ex.Message}";
                    throw new Exception(ex.Message);
                }

            }
            finally
            {
                _conexao.Close();
            }
        }
        public void Delete(int id)
        {
            _conexao.Execute($"DELETE FROM Produto WHERE Id = {id}");
        }
    }
}