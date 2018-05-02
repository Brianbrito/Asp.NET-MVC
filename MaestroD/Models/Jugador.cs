﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaestroD.Models
{
    [Table("Jugadores")]
    public class Jugador
    {
        public int JugadorId { get; set; } 
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido{ get; set; }
        public string Posicion { get; set; }
        public bool Estado { get; set; }

        public string NombreEquipo { get; set; }
        public Equipo Equipo { get; set; }
    }
}