using Microsoft.Data.SqlClient;

namespace ExamenArnold.DLA
{
    public class Conexion
    {
        SqlConnection cn = new SqlConnection(@"server=LAPTOP-V8V92C5A; database=ExamenDinet;Trusted_Connection= True;" +
           "MultipleActiveResultSets= True;TrustServerCertificate= False;Encrypt= False");
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
