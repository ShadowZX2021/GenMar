using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CamionesWebMVCGenMar.Models.DTOs
{
    public class RutaDTOs
    {
        public int IdRuta {  get; set; }

        [Required(ErrorMessage = "Debe seleccionar un chofer")]
        [Display(Name = "Chofer")]
        public int IdChofer { get; set; }

        [Required(ErrorMessage = "Debe de selecionar un camion")]
        [Display(Name = "Camion")]
        public int IdCamion;

        [Required(ErrorMessage ="El origen es obligatorio")]
        [StringLength(200)]
        public string Origen { get; set; }

        [Required(ErrorMessage = "El destina es obligatorio")]
        [StringLength(200)]
        public string Destino { get; set; }

        [Required(ErrorMessage = "La fecha de salida es obligatoria")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha de salida")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "La fecha de llegada es obligatoria")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de llegada")]
        public DateTime FechaLlegada { get; set; }

        [Display(Name ="Llego a tiempo")]
        public bool ATiempo {  get; set; }

        [Required(ErrorMessage ="La distancia es obligatoria")]
        [Range(0.1,10000, ErrorMessage ="Distancia entre 0.1 y 10000 km")]
        [Display(Name ="Distancia (Km)")]
        public double Distancia { get; set; }

        [Display(Name ="Chofer")]
        public string NombreChofer { get; set; }

        [Display(Name ="Licencia")]
        public string LicenciaChofer { get; set; }

        [Display(Name ="Matricula")]
        public string MatriculaCamion { get; set; }

        [Display(Name ="Duracion (horas)")]
        public double DuracionHoras
        {
            get
            {
                TimeSpan duracion = FechaLlegada - FechaSalida;
                return Math.Round(duracion.TotalHours, 2);
            }
        }
    }
}