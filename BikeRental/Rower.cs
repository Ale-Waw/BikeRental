using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRental
{
    public class Rower
    {
        private static int _ID = 1;
        public int ID { get; set; }
        public string rodzaj { get; set; }
        public double cenaGodz { get; set; }
        public bool czyWypozyczony { get; private set; }
        public DateTime? dataWypozyczenia { get; private set; }

        public Rower()
        {
            ID = _ID++;
            rodzaj = "Miejski";
            cenaGodz = 5.0;
        }

        public void Wypozycz()
        {
            if (czyWypozyczony) return;
            czyWypozyczony = true;
            dataWypozyczenia = DateTime.Now;
        }

        public double Zwroc()
        {
            if (!czyWypozyczony || dataWypozyczenia == null) return 0;

            TimeSpan czas = DateTime.Now - dataWypozyczenia.Value;
            double godziny = Math.Ceiling(czas.TotalHours);
            if (godziny < 1) godziny = 1; // Opłata za godzinę

            double koszt = godziny * cenaGodz;

            // Resetowanie stanu
            czyWypozyczony = false;
            dataWypozyczenia = null;

            return koszt;
        }

        public override string ToString()
        {
            string status = czyWypozyczony ? $"[ZAJĘTY od {dataWypozyczenia:HH:mm}]" : "[WOLNY]";
            return $"ID: {ID:D3} | {status} | {rodzaj} | {cenaGodz} zł/h";
        }

    }
    public class Gorski : Rower
    {
        public Gorski()
        {
            rodzaj = "Górski";
            cenaGodz = 7;
        }
    }

    public class Szosowy : Rower
    {
        public Szosowy()
        {
            rodzaj = "Szosowy";
            cenaGodz = 10;
        }
    }

    public class Elektryk : Rower
    {
        public Elektryk()
        {
            rodzaj = "Elektryczny";
            cenaGodz = 20;
        }
    }

    public class Dzieciecy : Rower
    {
        public Dzieciecy()
        {
            rodzaj = "Dziecięcy";
            cenaGodz = 2.50;
        }
    }
}
