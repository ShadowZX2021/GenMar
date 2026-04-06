using System.ComponentModel.DataAnnotations;

namespace ControlGastosMVC.Models.DTOs
{
    public class CategoriasDTO
    {
        public int IdCategorias { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public int? IdEstatus { get; set; }
    }
}