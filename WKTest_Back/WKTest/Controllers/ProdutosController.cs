using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WKTest.DataAccessObject.Repositories;
using WKTest.Models;

namespace WKTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoDAO _produtoDAO;
        private readonly ICategoriaDAO _categoriaDAO;
        public ProdutosController(IProdutoDAO produtoDAO, ICategoriaDAO categoriaDAO)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            try
            {
                return _produtoDAO.Get().ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex, stackTrace = ex.StackTrace });
            }
        }

        [HttpGet("{name}")]
        public ActionResult<dynamic> GetFiltered(string name)
        {
            try
            {
                return _produtoDAO.Get(x => x.Nome == name).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex, stackTrace = ex.StackTrace });
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromBody] Produto produto)
        {
            if (produto is null)
                return BadRequest(new { });
            else
                try
                {
                    if (_categoriaDAO.Get(x => x.Id == produto.CategoriaId).ToList().Any())
                    {
                        var result = _produtoDAO.Add(produto);
                        if (result is not null)
                            return result;
                        else
                            return StatusCode(500, new { erro = "Falha ao criar categoria" });
                    } 
                    else
                    {
                        return BadRequest("Categoria do produto inválida.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message, stackTrace = ex.StackTrace });
                }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromBody] Produto produto)
        {
            if (produto is null)
                return BadRequest(new { erro = "Objeto invalido" });
            else
                try
                {
                    var result = _produtoDAO.Update(produto);
                    if (result is not null)
                        return result;
                    else
                        return StatusCode(500, new { erro = "Falha ao atualizar categoria" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message, stackTrace = ex.StackTrace });
                }
        }

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromBody] Produto produto)
        {
            if (produto is null)
                return BadRequest(new { });
            else
                try
                {
                    _produtoDAO.Delete(produto);
                    return Ok("Produto deletado com sucesso");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message, stackTrace = ex.StackTrace });
                }
        }
    }
}
