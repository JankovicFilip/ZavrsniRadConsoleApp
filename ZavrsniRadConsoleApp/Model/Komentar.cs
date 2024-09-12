using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Model
{
    internal class Komentar : Entitet
    {

        public string? Opis { get; set; }
        public List<Korisnik>? Korisnici { get; set; }
        public Medij? Mediji { get; set; }

    }
}
