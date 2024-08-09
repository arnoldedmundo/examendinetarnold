using System.ComponentModel.DataAnnotations;

namespace Web_Mvc.Models
{
    public class Producto
    {
        [Display(Name = "Id")] public int Id { get; set; }
        [Display(Name = "Nombre")] public string Nombre { get; set; }
        [Display(Name = "Precio")] public decimal Precio { get; set; }
        [Display(Name = "Fecha_Creacion")] public DateTime Fecha_Creacion { get; set; }

    }
}
