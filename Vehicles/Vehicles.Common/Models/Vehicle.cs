using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Common.Models
{
    
   public class Vehicle
    {
        [Key]
        [AutoIncrement]
        public string id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Modelo { get; set; }

        [Required]
        public string NoPlacas { get; set; }

        [Required]
        public string NoSerie { get; set; }

        [Required]
        public string Depositarios { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string Adscripcion { get; set; }

        [Required]
        public string NoAveriguacion { get; set; }

        [Required]
        public string NoExpediente { get; set; }

        [Required]
        public string Origen { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFinal { get; set; }

        public override string ToString()
        {
            return this.Marca;
        }


    }
}
