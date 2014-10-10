using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Medewerker
    {
        /*UITLEG: Medewerkers*/
        //Properties
        public int ID { get; set; }

        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        private string _voornaam;

        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }

        private string _telefoonnr;

        public string Telefoonnr
        {
            get { return _telefoonnr; }
            set { _telefoonnr = value; }
        }

        
        
        
        
    }
}
