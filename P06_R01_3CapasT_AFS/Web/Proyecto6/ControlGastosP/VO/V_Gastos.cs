using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class V_Gastos
    {
        public int IdGastos { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public string NombrePersona { get; set; }
        public string Usuario { get; set; }
        public string Categoria { get; set; }
    }
}
