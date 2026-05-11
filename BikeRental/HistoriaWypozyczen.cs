using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRental
{
    public class HistoriaWypozyczen
    {
        private List<RekordHistorii> _wpisy = new List<RekordHistorii>();

        public void DodajWpis(Rower r, double kwota, DateTime start)
        {
            _wpisy.Add(new RekordHistorii
            {
                RowerID = r.ID,
                Rodzaj = r.rodzaj,
                DataStart = start,
                DataKoniec = DateTime.Now,
                Kwota = kwota
            });
        }

        public void PokazRaport()
        {
            Console.Clear();
            Console.WriteLine("=== HISTORIA ZAROBKÓW ===");
            double suma = 0;
            foreach (var wpis in _wpisy)
            {
                Console.WriteLine(wpis);
                suma += wpis.Kwota;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"RAZEM: {suma} zł");
        }
    }
}
