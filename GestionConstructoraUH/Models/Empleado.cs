using System;
using System.Collections.Generic;

namespace GestionConstructoraUH.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string CarnetUnico { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = "San José";
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public decimal Salario { get; set; }
        public string CategoriaLaboral { get; set; }

        public virtual ICollection<Asignacion> Asignaciones { get; set; } = new HashSet<Asignacion>();
    }
}
