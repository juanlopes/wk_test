using System;
using System.Linq;
using WKTest.Models;
using Microsoft.AspNetCore.Mvc;
using WKTest.DataAccessObject.Repositories;

namespace WKTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaDAO _categoriaDAO;
        public CategoriaController(ICategoriaDAO categoriaDAO)
        {
            _categoriaDAO = categoriaDAO;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            try
            {
                return _categoriaDAO.Get().ToList();
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
                return _categoriaDAO.Get(x => x.Nome == name).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex, stackTrace = ex.StackTrace });
            }
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromBody] Categoria categoria)
        {
            if (categoria is null)
                return BadRequest(new { });
            else 
                try
                {
                    var result = _categoriaDAO.Add(categoria);
                    if (result is not null)
                        return result;
                    else
                        return StatusCode(500, new { erro = "Falha ao criar categoria"});
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message, stackTrace = ex.StackTrace });
                }
        }

        [HttpPut]
        public ActionResult<dynamic> Put([FromBody] Categoria categoria)
        {
            if (categoria is null)
                return BadRequest(new { });
            else
                try
                {
                    var result = _categoriaDAO.Update(categoria);
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
        public ActionResult<dynamic> Delete([FromBody] Categoria categoria)
        {
            if (categoria is null)
                return BadRequest(new { });
            else
                try
                {
                     _categoriaDAO.Delete(categoria);
                     return Ok("Categoria deletada com sucesso");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { erro = ex.Message, stackTrace = ex.StackTrace });
                }
        }
    }
}
