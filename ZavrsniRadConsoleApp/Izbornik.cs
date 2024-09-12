using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavrsniRadConsoleApp.Model;

namespace ZavrsniRadConsoleApp
{
    internal class Izbornik
    {
        public ObradaKomentar ObradaKomentar { get; set; }
        public ObradaKorisnik ObradaKorisnik { get; set; }
        public ObradaMedij ObradaMedij { get; set; }

        public Izbornik()
        {
            Pomocno.DEV = true;
            ObradaMedij = new ObradaMedij();
            ObradaKorisnik = new ObradaKorisnik();
            ObradaKomentar = new ObradaKomentar(this);
            UcitajPodatke();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }
        private void UcitajPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(Path.Combine(docPath, "mediji.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "mediji.json"));
                ObradaMedij.Mediji = JsonConvert.DeserializeObject<List<Medij>>(file.ReadToEnd());
                file.Close();

            }

        }
        private void PozdravnaPoruka()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("**** Mediji Console App v 1.0 ***");
            Console.WriteLine("*********************************");
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Smjerovi");
            Console.WriteLine("2. Polaznici");
            Console.WriteLine("3. Grupe");
            Console.WriteLine("4. Izlaz iz programa");
            OdabirOpcijeIzbornika();
        }
        private void OdabirOpcijeIzbornika()
        {

            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 4))
            {
                case 1:
                    Console.Clear();
                    ObradaKorisnik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaMedij.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaKomentar.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.WriteLine("Hvala na korištenju aplikacije, doviđenja!");
                    SpremiPodatke();
                    break;
            }
        }
        private void SpremiPodatke()
        {
            if (Pomocno.DEV)
            {
                return;
            }

            //Console.WriteLine(JsonConvert.SerializeObject(ObradaSmjer.Smjerovi));

            string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "mediji.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaMedij.Mediji));
            outputFile.Close();
        }
    }
}
