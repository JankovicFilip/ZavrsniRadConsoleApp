using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Model
{
    internal class Medij : Entitet
    {
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? Vrsta { get; set; }
        public string? Genre { get; set; }
    }
}
