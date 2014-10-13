using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF_Klant.Model
{
    class Klant
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Emailadres { get; set; }
        public string rekeningsnummer { get; set; }
        public int KaartID { get; set; }
        public double Saldo { get; set; }
    }
}
