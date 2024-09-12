using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRadConsoleApp.Model;

namespace ZavrsniRadConsoleApp
{
    internal class ObradaMedij
    {
        public List<Medij> Mediji { get; set; }

        public ObradaMedij()
        {
            Mediji = new List<Medij>();
            if (Pomocno.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            Mediji.Add(new() {Sifra = 1, Naziv = "Attack on Titan", Genre = "Action, Drama", Opis = "Story of people who turn into giant titans!", Vrsta = "Anime"});
            Mediji.Add(new() { Sifra = 2, Naziv = "One piece", Genre = "Action, Drama, Super power, Comedy", Opis = "Pirates fighting for the Great Treasure", Vrsta = "Anime" });
            Mediji.Add(new() { Sifra = 3, Naziv = "Game of thrones", Genre = "Drama, Action, Nudity", Opis = "Story follows the Stark family", Vrsta = "TV show" });                
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s medijima");
            Console.WriteLine("1. Pregled svih Medija");
            Console.WriteLine("2. Pregled detalja pojedinog medija");
            Console.WriteLine("3. Unos novog medija");
            Console.WriteLine("4. Promjena podataka postojećeg medija");
            Console.WriteLine("5. Brisanje medija");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    PrikaziMedije();
                    PrikaziIzbornik();
                    break;
                case 2:
                    PregledDetaljaMedija();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UnosNovogMedija();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjeniPostojeciMedij();
                    PrikaziIzbornik();
                    break;
                case 5:
                    ObrisiPostojeciMedij();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }
        public void PrikaziMedije()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Mediji u aplikaciji");
            int rb = 0;
            foreach (var m in Mediji)
            {
                Console.WriteLine(++rb + ". " + m.Naziv);
            }
            Console.WriteLine("****************************");
        }
        private void PregledDetaljaMedija()
        {
            PrikaziMedije();
            var m = Mediji[
                Pomocno.UcitajRasponBroja("Odaberi redni broj smjera za detalje", 1, Mediji.Count) - 1
                ];
            Console.WriteLine("--------------------");
            Console.WriteLine("Detalji smjera:");
            Console.WriteLine("Šifra: " + m.Sifra);
            Console.WriteLine("Naziv: " + m.Naziv);
            Console.WriteLine("Genre: " + m.Genre);
            Console.WriteLine("Opis: " + m.Opis);
            Console.WriteLine("Vrsta: " + m.Vrsta);
            Console.WriteLine("--------------------");
        }
        private void UnosNovogMedija()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o mediju");
            Mediji.Add(new()
            {
                Sifra = Pomocno.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue),
                Naziv = Pomocno.UcitajString("Unesi naziv smjera", 100, true),
                Vrsta = Pomocno.UcitajString("Unesi naziv smjera", 50, true),
                Opis = Pomocno.UcitajString("Unesi naziv smjera", 1000, true),
                Genre = Pomocno.UcitajString("Unesi naziv smjera", 50, true)
            });
        }

        private void PromjeniPostojeciMedij()
        {
            PrikaziMedije();
            var odabrani = Mediji[Pomocno.UcitajRasponBroja("Odaberi redni broj smjera za promjenu",
                1, Mediji.Count) - 1];

            if (Pomocno.UcitajRasponBroja("1. Mjenjaš sve\n2. Pojedinačna promjena", 1, 2) == 1)
            {
                // poziv API-u da se javi tko ovo koristi
                odabrani.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue);
                odabrani.Naziv = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
                odabrani.Vrsta = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
                odabrani.Opis = Pomocno.UcitajString("Unesi naziv smjera", 1000, true);
                odabrani.Genre = Pomocno.UcitajString("Unesi naziv smjera", 50, true);

            }
            else
            {
                // poziv API-u da se javi tko ovo koristi
                switch (Pomocno.UcitajRasponBroja("1. Šifra\n2. Naziv\n3. Vrsta\n4. Opis\n" +
                    "5. Genre", 1, 5))
                {
                    case 1:
                        odabrani.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue);
                        break;
                    case 2:
                        odabrani.Naziv = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
                        break;
                    case 3:
                        odabrani.Vrsta = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
                        break;
                    case 4:
                        odabrani.Opis = Pomocno.UcitajString("Unesi naziv smjera", 1000, true);
                        break;
                    case 5:
                        odabrani.Genre = Pomocno.UcitajString("Unesi naziv smjera", 50, true);
                        break;


                }

            }
        }
        private void ObrisiPostojeciMedij()
        {
            PrikaziMedije();
            var odabrani = Mediji[Pomocno.UcitajRasponBroja("Odaberi redni broj smjera za Brisanje",
                1, Mediji.Count) - 1];

            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Naziv + "? (DA/NE)", "da"))
            {
                Mediji.Remove(odabrani);
            }
        }
    }
}
