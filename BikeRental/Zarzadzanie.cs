using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRental
{
    public static class Zarzadzanie
    {
        public static void PokazRowery(List<Rower> flota)
        {
         //   Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("          ===SYSTEM WYPOŻYCZALNI ROWERÓW===");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var rower in flota)
                Console.WriteLine(rower);
        }

        public static void WypozyczRower(List<Rower> flota)
        {
            Console.Write("Podaj ID roweru: ");
            if (int.TryParse(Console.ReadLine(), out int szukaneID))
            {
                // Szukamy w liście roweru, którego Id zgadza się z wpisanym numerem
                var rower = flota.Find(r => r.ID == szukaneID); // tworzymy tymczasową zmienną "r", szukamy ID takiego jak szukaneID
                if (rower != null)
                    rower.Wypozycz();
                else
                    Console.WriteLine("Nie znaleziono roweru o takim ID!");

            }
        }

        public static void ZwrocRower(List<Rower> flota, HistoriaWypozyczen ksiega)
        {
            Console.Write("Podaj ID roweru do zwrotu: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var rower = flota.Find(r => r.ID == id);
                if (rower != null && rower.czyWypozyczony && rower.dataWypozyczenia.HasValue)
                {
                    DateTime start = rower.dataWypozyczenia.Value;
                    double koszt = rower.Zwroc();
                    ksiega.DodajWpis(rower, koszt, start);
                    Console.WriteLine($"Zwrócono. Do zapłaty: {koszt} zł.");
                }
                else Console.WriteLine("Ten rower nie jest obecnie wypożyczony.");
            }
                
            
        }
    }
}
