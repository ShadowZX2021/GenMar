using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlGastosMVC.Models
{
    public class GastosVM
    {
        public int IdGastos { get; set; }
        public decimal? Monto { get; set; }  // <-- aquí
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdEstatus { get; set; }
        public string CategoriaNombre { get; set; }
        public string UsuarioNombre { get; set; }
    }
}