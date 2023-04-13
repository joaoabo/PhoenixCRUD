
using PhoenixCRUD.Models;
using PhoenixCRUD.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace PhoenixCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepositorios _repositorios;
        public ProdutosController()
        {
            _repositorios = new ProdutoRepositorios();
        }
        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            return Ok(_repositorios.Get(id));
        }
        [HttpGet]
        public IActionResult GetProduto()
        {
            return Ok(_repositorios.Get());
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Models.Produto produto)
        {
            _repositorios.Insert(produto);
            return Ok(produto);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Produto produto)
        {
            try
            {
                _repositorios.Update(produto);
            }
            catch(Exception ex)
            {
                return BadRequest("Não está salvando as alterações!" + ex.Message);
            }
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorios.Delete(id);
            return Ok();
        }
    }
}