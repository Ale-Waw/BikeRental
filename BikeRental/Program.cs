using System;
using System.Collections.Generic;

namespace BikeRental
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rower> flota = new List<Rower>
            {
                new Rower(), new Gorski(), new Gorski(),
                new Szosowy(), new Elektryk(), new Dzieciecy()
            };
            HistoriaWypozyczen ksiega = new HistoriaWypozyczen();

            while (true)
            {
                Zarzadzanie.PokazRowery(flota);
                Console.WriteLine("\n[1] Wypożycz | [2] Zwróć | [3] Historia | [4] Wyjdź");
                string wybor = Console.ReadLine();

                if (wybor == "4") break;

                switch (wybor)
                {
                    case "1": Zarzadzanie.WypozyczRower(flota); break;
                    case "2": Zarzadzanie.ZwrocRower(flota, ksiega); break;
                    case "3": ksiega.PokazRaport(); break;
                }

                Console.WriteLine("\nNaciśnij dowolny klawisz...");
                Console.ReadKey();
            }
        }
    }
}