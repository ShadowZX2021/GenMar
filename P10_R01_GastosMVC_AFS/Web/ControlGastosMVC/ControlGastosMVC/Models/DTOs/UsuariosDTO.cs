using System;
using System.ComponentModel.DataAnnotations;

namespace ControlGastosMVC.Models.DTOs
{
    public class UsuariosDTO
    {
        public int IdUsuario { get; set; }

        [Required]
        public int IdDatos { get; set; }

        [Required]
        [Display(Name = "Nivel de Usuario")]
        public int IdNivelUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        public int? IdEstatus { get; set; }
    }
}