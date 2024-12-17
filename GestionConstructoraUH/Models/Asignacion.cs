using System.ComponentModel.DataAnnotations;

namespace GestionConstructoraUH.Models
{
    public class Asignacion
    {
        public int IdAsignacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un empleado.")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un proyecto.")]
        public int IdProyecto { get; set; }

        [Required(ErrorMessage = "La fecha de asignación es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        public virtual Empleado Empleado { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
