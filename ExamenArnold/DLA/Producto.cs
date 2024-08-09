
using ExamenArnold.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExamenArnold.DLA

{
    public class Producto
    {
        public IEnumerable<ProductoModels> listadoproducto()
        {
            List<ProductoModels> seller = new List<ProductoModels>();
            using (SqlConnection cn = new Conexion().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("listar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new ProductoModels()
                    {

                        Id = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Precio = dr.GetDecimal(2),
                        FechaCreacion = dr.GetDateTime(3)

                    });
                }
            }
            return seller;
        }
        public string insertarproducto(Models.ProductoModels reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new Conexion().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_producto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@dni", reg.Id));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@email", reg.Precio));
                    cmd.Parameters.Add(new SqlParameter("@idact", reg.FechaCreacion));
                    cmd.ExecuteNonQuery();
                    mensaje = "Producto Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
    }
}
