using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Contexto;
using Exam.Intreface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        IAccesoDatos<Productos, int> _datos;

        public ProductosController( IAccesoDatos<Productos, int> datos)
        {
            this._datos = datos;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Productos>> Get()
        {
            var productos = _datos.ProductosGet();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productos = _datos.ProductosGetId(id);
            if (productos == null)
            {
                return NotFound();
            }
            return Ok(productos);
        }



        [HttpPost]
        public IActionResult Post([FromBody] Productos model)
        {
            int res = _datos.InsertProductos(model);
            if (res != 0)
            {
                return Ok();
            }
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Productos model)
        {
            if (id == model.Id_producto)
            {
                int res = _datos.ActualizarProductos(id, model);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = _datos.EliminarProductos(id);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }



    }
}
