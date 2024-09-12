using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZavrsniRadConsoleApp.Model;

namespace ZavrsniRadConsoleApp
{
    internal class ObradaKomentar
    {
        public List<Komentar> Komentari { get; set; }
        private Izbornik Izbornik;

        public ObradaKomentar()
        {
            Komentari = new List<Komentar>();
        }
        public ObradaKomentar(Izbornik izbornik):this()
        {
            this.Izbornik = izbornik;
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s komentarima");
            Console.WriteLine("1. Pregled svih komentara");
            Console.WriteLine("2. Unos novih komentara");
            Console.WriteLine("3. Promjena podataka postojećeg komentara");
            Console.WriteLine("4. Brisanje komenatara");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziKomentare();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogKomentara();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniKomentar();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiKomentar();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        

        private void PrikaziKomentare()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Komentari u aplikaciji");
            int rb = 0, rbp;
            foreach (var k in Komentari)
            {
                Console.WriteLine(++rb + ". " + k.Opis + " (" + k.Mediji?.Naziv + "), " + k.Korisnici?.Count + " korisnika"); // prepisati metodu toString

                rbp = 0;
                k.Korisnici.Sort(); 
                foreach (var ko in k.Korisnici)
                {
                    Console.WriteLine("\t" + ++rbp + ". " + ko.Ime + " " + ko.Prezime);
                }
            }
            Console.WriteLine("****************************");
        }
        private void UnosNovogKomentara()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite novi komentar");

            Komentar k = new Komentar();
            k.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru komentara", 1, int.MaxValue);
            k.Opis = Pomocno.UcitajString("Unesi opis komentara", 1000, true);
            //smjer
            Izbornik.ObradaMedij.PrikaziMedije();

            k.Mediji = Izbornik.ObradaMedij.Mediji[
                Pomocno.UcitajRasponBroja("Odaberi redni broj medija", 1, Izbornik.ObradaMedij.Mediji.Count) - 1];

            
            // polaznici
            k.Korisnici = UcitajKorisnika((int)k.MaksimalnoKorisnika);

            Komentari.Add(k);
        }

        private List<Korisnik> UcitajKorisnika(int maksimalnoKorisnika)
        {
            List<Korisnik> lista = new List<Korisnik>();
            while (lista.Count < maksimalnoKorisnika && Pomocno.UcitajBool("Za unos korisnika unesi DA", "da"))
            {
                Izbornik.ObradaKorisnik.PrikaziKorisnike();
                Console.WriteLine((Izbornik.ObradaKorisnik.Korisnici.Count + 1) + ". Dodaj novog korisnika");
                var odabranaOpcija = Pomocno.UcitajRasponBroja("Odaberi redni broj korisnika ili zadnji broj za dodavanje novog", 1,
                        Izbornik.ObradaKorisnik.Korisnici.Count + 1);
                if (odabranaOpcija == Izbornik.ObradaKorisnik.Korisnici.Count + 1)
                {
                    // ide novi
                    Izbornik.ObradaKorisnik.UnosNovogKorisnika();
                    lista.Add(Izbornik.ObradaKorisnik.Korisnici.LastOrDefault());
                }
                else
                {
                    lista.Add(Izbornik.ObradaKorisnik.Korisnici[odabranaOpcija]);
                }

            }

            return lista;
        }
        private void PromjeniKomentar()
        {
            PrikaziKomentare();
            var k = Komentari[
                Pomocno.UcitajRasponBroja("Odaberi redni broj komentara za promjenu", 1, Komentari.Count) - 1
                ];
            // copy paste s linije 102 - izvući u metodu
            k.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru komentara", 1, int.MaxValue);
            k.Opis = Pomocno.UcitajString("Unesi opis komentara", 1000, true);
            //smjer
            Izbornik.ObradaMedij.PrikaziMedije();

            k.Mediji = Izbornik.ObradaMedij.Mediji[
                Pomocno.UcitajRasponBroja("Odaberi redni broj smjera", 1, Izbornik.ObradaMedij.Mediji.Count) - 1];

            
            k.MaksimalnoKorisnika = Pomocno.UcitajRasponBroja("Unesi maksimalno polaznika", 1, 30);

            // polaznici
            g.Polaznici = UcitajPolaznike((int)g.MaksimalnoPolaznika);
        }
    }
}


// TU SI STAO, HTIO SAM NAPRAVITI DA SE MOZE PROMIJENITI IME I PREZIME OSOBE ILITI KORISNIKA
