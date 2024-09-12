using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRadConsoleApp.Model;

namespace ZavrsniRadConsoleApp
{
    internal class ObradaKorisnik
    {
        public List<Korisnik> Korisnici { get; set; }

        public ObradaKorisnik()
        {
            Korisnici = new List<Korisnik>();
            if (Pomocno.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            for (int i = 0; i < 10; i++)
            {
                Korisnici.Add(new()
                {
                    Ime = Faker.Name.First(),
                    Prezime = Faker.Name.Last(),
                    Username = Faker.Name.FullName(),
                    Password = Faker.Name.Middle()
                });
            }
        }

        private void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s korisnicima");
            Console.WriteLine("1. Pregled svih korisnika");
            Console.WriteLine("2. Unos novog korisnika");
            Console.WriteLine("3. Promjena podataka postojećeg korisnika");
            Console.WriteLine("4. Brisanje korisnika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziKorisnike();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogKorisnika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatakaKorisnika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiKorisnika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }

        

        private void PrikaziKorisnike()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Korisnici u aplikaciji");
            int rb = 0;
            foreach (var k in Korisnici)
            {
                Console.WriteLine(++rb + ". " + k.Ime + " " + k.Prezime); // prepisati metodu toString
            }
            Console.WriteLine("****************************");
        }
        private void UnosNovogKorisnika()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o polazniku");
            Korisnici.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru polaznika", 1, int.MaxValue),
                Ime = Pomocno.UcitajString("Unesi ime polaznika", 50, true),
                Prezime = Pomocno.UcitajString("Unesi prezime polaznika", 50, true),
                Username = Pomocno.UcitajString("Unesi email polaznika", 50, true),
                Password = Pomocno.UcitajString("Unesi OIB polaznika", 50, true)
            });
        }
        private void PromjeniPodatakaKorisnika()
        {
            PrikaziKorisnike();
            var odabrani = Korisnici[
                Pomocno.UcitajRasponBroja("Odaberi redni broj polaznika za promjenu",
                1, Korisnici.Count) - 1
                ];
            odabrani.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru polaznika", 1, int.MaxValue);
            odabrani.Ime = Pomocno.UcitajString(odabrani.Ime, "Unesi ime polaznika", 50, true);
            odabrani.Prezime = Pomocno.UcitajString("Unesi prezime polaznika", 50, true);
            odabrani.Username = Pomocno.UcitajString("Unesi email polaznika", 50, true);
            odabrani.Password = Pomocno.UcitajString("Unesi OIB polaznika", 50, true);
        }

        private void ObrisiKorisnika()
        {
            PrikaziKorisnike();
            var odabrani = Korisnici[
                Pomocno.UcitajRasponBroja("Odaberi redni broj polaznika za brisanje",
                1, Korisnici.Count) - 1
                ];
            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Ime + " " + odabrani.Prezime + "? (DA/NE)", "da"))
            {
                Korisnici.Remove(odabrani);
            }
        }

    }
}
