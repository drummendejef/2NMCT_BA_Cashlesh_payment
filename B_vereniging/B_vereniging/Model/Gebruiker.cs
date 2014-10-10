using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Gebruiker
    {
        /*UITLEG: Als er een persoon in wilt loggen, gebruiken we deze klasse om te kijken of deze gebruiker al gekend is in het systeem.*/

        //Properties
        private string _gebruikersnaam;

        public string Gebruikersnaam
        {
            get { return _gebruikersnaam; }
            set { _gebruikersnaam = value; }
        }

        private string _wachtwoord;

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; }
        }
        
        
    }
}
