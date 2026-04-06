using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastosMVC.Models
{
    public class DatosPersonalesVM
    {
        public int IdDatos { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public decimal? SueldoBase { get; set; }
        public int? IdEstatus { get; set; }
        public string TipoSueldoDescripcion { get; set; } // Para mostrar solo la descripción
    }
}