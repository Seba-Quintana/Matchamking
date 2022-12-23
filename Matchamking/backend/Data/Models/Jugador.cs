﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Models
{
    public class Jugador
    {
        [Key]
        public string Nickname { get; set; }
        public int Jugados { get; set; }
        public int Victorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public float Elo { get; set; }
        public int Racha { get; set; }
        public bool Resaca { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }

        public float Eloboost { get; set; }
        public List<Equipo_Jugador> Equipo_Jugadores { get; set; }


        //    public Jugador() { }
        //    public Jugador(string nickname)
        //    {
        //        Nickname = nickname;
        //    }
        //}
    }
}
