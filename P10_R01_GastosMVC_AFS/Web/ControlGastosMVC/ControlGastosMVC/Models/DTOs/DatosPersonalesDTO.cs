using System;
using System.ComponentModel.DataAnnotations;

namespace ControlGastosMVC.Models.DTOs
{
    public class DatosPersonalesDTO
    {
        public int IdDatos { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Apellido Paterno")]
        public string ApPaterno { get; set; }

        [Required(ErrorMessage = "El apellido materno es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Apellido Materno")]
        public string ApMaterno { get; set; }

        [Phone(ErrorMessage = "Teléfono inválido")]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [Range(0, 999999999, ErrorMessage = "Sueldo inválido")]
        [Display(Name = "Sueldo Base")]
        public decimal? SueldoBase { get; set; }

        [Display(Name = "Tipo de Sueldo")]
        public int? IdTipoSueldo { get; set; }

        public int? IdEstatus { get; set; }
    }
}