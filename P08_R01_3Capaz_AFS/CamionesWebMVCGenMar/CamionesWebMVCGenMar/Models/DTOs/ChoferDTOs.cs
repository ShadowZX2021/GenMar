using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CamionesWebMVCGenMar.Models.DTOs
{
    public class ChoferDTOs
    {
        public int IdChofer { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El apellido paterno es obligatorio")]
        [StringLength(100)]
        [Display(Name ="Apellido paterno")]
        public string ApPaterno { get; set; }

        [Required(ErrorMessage = "El apellido materno es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Apellido materno")]
        public string ApMaterno { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(15)]
        [Phone(ErrorMessage ="Telefono invalido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage ="La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage ="La licencia es obligatoria")]
        [StringLength(50)]
        public string Licencia { get; set; }

        [Display(Name ="URL Foto")]
        [Url(ErrorMessage ="URL incalida")]
        public string UrlFoto { get; set; }

        [Display(Name ="Disponible")]
        public bool Disponibilidad {  get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $"{Nombre} {ApPaterno} {ApMaterno}";

        [Display(Name ="Edad")]
        public int Edad => DateTime.Now.Year - FechaNacimiento.Year -
                  (FechaNacimiento > DateTime.Now.AddYears(-(DateTime.Now.Year - FechaNacimiento.Year)) ? 1 : 0);


    }
}