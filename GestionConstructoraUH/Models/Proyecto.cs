using System;
using System.Collections.Generic;

namespace GestionConstructoraUH.Models
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<Asignacion> Asignaciones { get; set; } = new HashSet<Asignacion>();
    }
}
