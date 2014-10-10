using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_medewerkers.Model
{
    class Medewerker
    {
        //Properties
        public int ID { get; set; }

        private string _voornaam;

        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        
    }
}
