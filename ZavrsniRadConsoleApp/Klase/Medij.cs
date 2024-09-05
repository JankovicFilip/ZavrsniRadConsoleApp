using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Klase
{
    internal class Medij : Entitet
    {
        public Medij() { }
        public Medij(int sifra, string? naziv, string? opis, string? vrsta, string? genre)
        {
            base.Sifra = sifra;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Vrsta = vrsta;
            this.Genre = genre;

        }

        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? Vrsta { get; set; }
        public string? Genre { get; set; }


    }
}
