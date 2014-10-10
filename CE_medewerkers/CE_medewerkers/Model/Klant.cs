using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_medewerkers.Model
{
    class Klant
    {
        //Properties
        public int ID { get; set; }

        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public string Voornaam { get; set; }
        
    }
}
