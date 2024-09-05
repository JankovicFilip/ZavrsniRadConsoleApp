using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRadConsoleApp.Klase
{
    internal class Osoba : Entitet
    {

        public Osoba() { }
        public Osoba(int sifra, string? ime, string? prezime, string? password, bool? uloga)
        {
            base.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Password = password;
            this.Uloga = uloga;
        }

        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Uloga { get; set; }
    }
}
