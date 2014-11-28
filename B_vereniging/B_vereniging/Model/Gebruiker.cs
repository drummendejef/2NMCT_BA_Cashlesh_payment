using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnectie;

namespace B_vereniging.Model
{
    class Gebruiker
    {
        private const string CONNECTIONSTRING = "ConnectionString";
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

        //Connectie maken met database.
        //Kijken of de gebruikersnaam er ergens instaat.
        //Zoniet, fout teruggeven dat gebruikersnaam niet bestaat.
        private static int FindGebruikersnaam(string naam)
        {
            string sql = "SELECT Naam, Id FROM Gebruikers WHERE Naam='@Naam'";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING,"@Naam", naam);
            return Database.InsertData(CONNECTIONSTRING, sql, par1);      
        }
        
        //Wachtwoord ophalen en ontcijferen.
        //Kijken of het hetzelfde wachtwoord is.
        
        
    }
}
