using System.ComponentModel.DataAnnotations;

namespace ControlGastosMVC.Models.DTOs
{
    public class NivelUsuarioDTO
    {
        public int IdNivelUsuario { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? IdEstatus { get; set; }
    }
}