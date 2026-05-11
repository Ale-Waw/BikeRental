using System;
using System.Collections.Generic;
using System.Text;

namespace BikeRental
{
    public class RekordHistorii
    {
        public int RowerID { get; set; }
        public string Rodzaj { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataKoniec { get; set; }
        public double Kwota { get; set; }

        public override string ToString()
        {
            return $"[{DataKoniec:yyyy-MM-dd HH:mm}] ID: {RowerID:D3} ({Rodzaj}) - Kwota: {Kwota} zł";
        }
    }
}
