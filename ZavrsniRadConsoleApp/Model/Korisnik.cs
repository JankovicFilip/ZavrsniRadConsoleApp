﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Model
{
    internal class Korisnik : Osoba
    {

        public string? Username { get; set; }
        public string? Password { get; set; }

        public int CompareTo(Korisnik? other)
        {
            return Prezime.CompareTo(other.Prezime); 
        }
    }

}
