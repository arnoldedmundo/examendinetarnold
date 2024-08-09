using ExamenArnold.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExamenArnold.Controllers
{
    [ApiController]
    [Route("producto")]
    public class ProductoController : ControllerBase
    {
        [HttpGet("listar")]
        public async Task<ActionResult> GetProducto()
        {
            return Ok(await Task.Run(() => new DLA.Producto().listadoproducto()));

        }

        [HttpPost("registrar")]
        public async Task<ActionResult> PostRegistrar(ProductoModels reg)
        {
            return Ok(await Task.Run(() => new DLA.Producto().insertarproducto(reg)));

        }

    }
}
