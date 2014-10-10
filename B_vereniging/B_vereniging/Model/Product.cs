using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Product
    {
        /*UITLEG: Producten*/
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

        private string _omschrijving;

        public string Omschrijving
        {
            get { return _omschrijving; }
            set { _omschrijving = value; }
        }
        
        
        
    }
}
