using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Klase
{
    internal class Komentar : Entitet
    {

        public Komentar() { }
        public Komentar(int sifra,string? opis, Osoba? osoba, Medij? medij)
        {
            base.Sifra = sifra;
            this.Opis = opis;
            this.osoba = osoba;
            this.medij = medij;
        }

        public string? Opis { get; set; }
        public Osoba? osoba { get; set; }
        public Medij? medij { get; set; }


    }
}
