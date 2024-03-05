namespace CRUDCORE.Datos
{
    public class Conexion
    {
        /// <summary>
        /// conexion utilizando var builder y .net 
        /// </summary>
        private string cadenaSQL = string.Empty;
        public Conexion() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); //establezco el directorio 
            cadenaSQL = builder.GetSection("ConnectionStrings").Value; // Aquí se obtiene la cadena de conexión y lo asigna a la variable
        }
        public string getCadenaSQL  () { return cadenaSQL; } 
    }
}
