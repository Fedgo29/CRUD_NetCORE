using System.Data.SqlClient;

namespace NetCoreTest.Datos
{
    public class Conexion
    {
        private string sqlString = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            sqlString = builder.GetSection("ConnectionStrings:SQLString").Value;
        }
        public string getSQLString()
        {
            return sqlString;
        }
    }
}
