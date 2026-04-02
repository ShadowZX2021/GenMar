using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CamionesWebMVCGenMar.Models.DTOs
{
    public class CamionDTO
    {
        public int IdCamion { get; set; }

        [Required(ErrorMessage = "La matricula es obligatoria")]
        [StringLength(50,ErrorMessage = "Máximo 50 caracteres")]
        [Display(Name ="Matricula")]

        public string Matricula { get; set; }

        [Required(ErrorMessage ="El tipo de camion es obligatorio")]
        [Display(Name = "Tipo de Camión")]
        public string TipoCamion { get; set; }

        [Required(ErrorMessage ="El modelo es obligatorio")]
        [Range(1900,2030,ErrorMessage ="Modelo inválido")]
        public int Modelo { get; set; }

        [Required(ErrorMessage ="La marca es obligatoria")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required(ErrorMessage ="La capacidad es obligatoria")]
        [Range(1,100000,ErrorMessage = "Capacidad entre 1 y 100000 kg")]
        [Display(Name = "Capacidad (kg)")]
        public int Capacidad { get; set; }

        [Range(0,double.MaxValue, ErrorMessage = "Kilometro invalido")]
        public double Kilometraje { get; set; }

        [Display(Name ="Disponible")]
        public bool Disponible { get; set; }

        [Display(Name ="URL Foto")]
        [Url(ErrorMessage ="URL invalida")]
        public string URLFoto { get; set; }

        [Display(Name ="Fecha de registro")]
        public DateTime FechaRegistro { get; set; }

    }
}