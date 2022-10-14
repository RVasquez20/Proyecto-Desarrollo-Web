namespace Web_Api.Controllers
{
    internal class tblEmpleadosViewModel
    {
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int IdCargo { get; set; }
        public int? IdClinica { get; set; }
        public string Cargo { get; set; }
    }
}