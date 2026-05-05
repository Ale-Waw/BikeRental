namespace BikeRental
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rower> flota = new List<Rower>
            {
                new Rower(),
                new Gorski(),
                new Gorski(),
                new Szosowy(),
                new Elektryk(),
                new Dzieciecy(),

            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM WYPOŻYCZALNI ROWERÓW ===");
                for (int i = 0; i < flota.Count; i++)
                {
                    Console.WriteLine($"{flota[i]}");
                }

                Console.WriteLine("\nMenu: [1] Wypożycz | [2] Zwróć | [3] Wyjdź");
                string wybor = Console.ReadLine();

                if (wybor == "3") break;

                Console.Write("Podaj ID roweru: ");
                if (int.TryParse(Console.ReadLine(), out int szukaneId))
                {
                    // Szukamy w liście roweru, którego Id zgadza się z wpisanym numerem
                    Rower wybranyRower = flota.Find(r => r.ID == szukaneId);

                    if (wybranyRower != null)
                    {
                        if (wybor == "1") wybranyRower.Wypozycz();
                        else if (wybor == "2")
                        {
                            double koszt = wybranyRower.Zwroc();
                            if (koszt > 0) Console.WriteLine($"Do zapłaty: {koszt} zł");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono roweru o takim ID!");
                    }
                }

                Console.WriteLine("\nNaciśnij dowolny klawisz...");
                Console.ReadKey();
            }
        }
    }

}

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
        this.rodzaj = "miejski";
        this.cenaGodz = 5;
        this.czyWypozyczony = false;
        this.dataWypozyczenia = null;
    }

    public void Wypozycz()
    {
        if (czyWypozyczony)
        {
            Console.WriteLine("Rower jest już zajęty!");
            return;
        }
        czyWypozyczony = true;
        dataWypozyczenia = DateTime.Now;
        Console.WriteLine($"Wypożyczono: {rodzaj} o godzinie {dataWypozyczenia} ");
    }

    public double Zwroc()
    {
        if (!czyWypozyczony || dataWypozyczenia == null)
        {
            Console.WriteLine("Błąd: Ten rower nie był wypożyczony.");
            return 0;
        }

        // Obliczanie czasu (dla testu możesz odjąć minuty zamiast godzin)
        TimeSpan czas = DateTime.Now - dataWypozyczenia.Value;

        // Zaokrąglamy w górę do pełnych godzin (minimum 1h)
        double godziny = Math.Ceiling(czas.TotalHours);
        if (godziny < 1) godziny = 1;

        double koszt = godziny * cenaGodz;

        czyWypozyczony = false;
        dataWypozyczenia = null;

        return koszt;
    }

    public override string ToString()
    {
        string status = czyWypozyczony ? "[ZAJĘTY]" : "[WOLNY]";
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


