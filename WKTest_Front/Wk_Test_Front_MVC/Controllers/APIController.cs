using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wk_Test_Front_MVC.Services.Contracts;

namespace Wk_Test_Front_MVC.Controllers
{
    [Route("api")]
    public class APIController : Controller
    {
        private readonly IAPI _api;
        public APIController(IAPI api)
        {
            _api = api;
        }

        [HttpGet("{items}")]
        public ActionResult<dynamic> Get(string items)
        {
            switch (items)
            {
                case "Produtos":
                case "Categoria":
                    return _api.ExecuteRequest("GET", items, null);
                default:
                    return BadRequest("Wrong Argument");
            }
        }

        [HttpPost("{items}")]
        public ActionResult<dynamic> Post(string items, [FromBody]object item)
        {
            switch (items)
            {
                case "Produtos":
                case "Categoria":
                    try
                    {
                        return _api.ExecuteRequest("POST", items, item.ToString());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                default:
                    return BadRequest("Wrong Argument");
            }
        }

        [HttpPut("{items}")]
        public ActionResult<dynamic> Put(string items, [FromBody] object item)
        {
            switch (items)
            {
                case "Produtos":
                case "Categoria":
                    try
                    {
                        return _api.ExecuteRequest("PUT", items, item.ToString());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                default:
                    return BadRequest("Wrong Argument");
            }
        }

        [HttpDelete("{items}")]
        public ActionResult<dynamic> Delete(string items, [FromBody] object item)
        {
            switch (items)
            {
                case "Produtos":
                case "Categoria":
                    try
                    {
                        return _api.ExecuteRequest("DELETE", items, item.ToString());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                default:
                    return BadRequest("Wrong Argument");
            }
        }

    }
}
