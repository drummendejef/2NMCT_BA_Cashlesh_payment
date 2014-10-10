using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_medewerkers.Model
{
    class Product
    {
        //Properties
        public int ID { get; set; }

        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        private double _stukprijs;

        public double Stukprijs
        {
            get { return _stukprijs; }
            set { _stukprijs = value; }
        }

        private int _aantal;

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }

        private double _totaalprijs;

        public double TotaalPrijs
        {
            get { return _totaalprijs; }
            set { _totaalprijs = value; }
        }
        
        
        
        
    }
}
