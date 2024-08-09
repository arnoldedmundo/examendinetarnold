using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using Web_Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Web_Mvc.Controllers
{
    public class PlataformaController : Controller
    {
        String api = "https://localhost:7052/api/ApiNegocios/";
        // GET: PlataformaController
        async Task<List<Producto>> productos()
        {
            List<Producto> auxiliar = new List<Producto>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("productos");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    auxiliar = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
                }
            }
            return auxiliar;
        }
    
        public async Task<IActionResult> Index()
        {
            ViewBag.solicitudes = await productos();
            ViewBag.titulo = "Agregar";
            ViewBag.actividades = new SelectList(await productos(), "idact", "desact");
            //envio un nuevo Seller, GET
            return View(await Task.Run(() => new Producto()));
        }


        [HttpPost]
        public async Task<IActionResult> Agregar(Producto reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                reg.Fecha_Creacion = DateTime.Now;
                cliente.BaseAddress = new Uri(api);
                //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                //ejecutar el Put
                HttpResponseMessage respuesta = await cliente.PostAsync("registrar", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            //al finalizar refrescar la pagina
            ViewBag.mensaje = mensaje;
            ViewBag.solicitudes = await productos();
            ViewBag.actividades = new SelectList(await productos(), "idact", "desact");
            ViewBag.titulo = "Agregar";
            //envio un nuevo Seller, GET
            return View("Index", await Task.Run(() => new Producto()));
        }
    }
}
