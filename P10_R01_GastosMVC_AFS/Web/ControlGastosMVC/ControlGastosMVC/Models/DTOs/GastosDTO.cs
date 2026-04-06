using System;
using System.ComponentModel.DataAnnotations;

namespace ControlGastosMVC.Models.DTOs
{
    public class GastosDTO
    {
        public int IdGastos { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public int IdCategorias { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, 999999999, ErrorMessage = "Monto inválido")]
        public decimal Monto { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        public int? IdEstatus { get; set; }
    }
}