using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaestroD.Models
{
    [Table("Equipos")]
    public class Equipo
    {
       

        [Key]
        [MaxLength(30)]
        public string NombreEquipo { get; set; }
        public string Pais { get; set; }
        public string Provincia{ get; set; }
        public bool Estado { get; set; }
       

        public List<Jugador> Jugadors { get; set; }
        //public string JugadorId { get; internal set; }
    }
}