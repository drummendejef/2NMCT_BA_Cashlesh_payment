using DatabaseConnectie;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Medewerker
    {
        private const string CONNECTIONSTRING = "ConnectionString";


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

        //Medewerker ophalen aan de hand van een ID
        public static Medewerker GetMedewerker(int id)
        {
            string sql = "SELECT * FROM Medewerker WHERE Id = @Id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Id", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);

            //Opgehaalde klant aanmaken
            Medewerker medewerker = new Medewerker()
            {
                ID = id,
                Naam = reader["Naam"].ToString(),
                Voornaam = reader["Voornaam"].ToString(),
                Telefoonnr = reader["Telefoonnr"].ToString()
            };

            return medewerker;
        }

        //Nieuwe medewerker aanmaken
        public static void NewMedewerker(string naam, string voornaam, string telefoonnr)
        {
            string sql = "INSERT INTO Medewerker VALUES(@Naam, @Voornaam, @Telefoonnr)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Naam", naam);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Voornaam", voornaam);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Telefoonnr", telefoonnr);
            Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3);
        }


        
        
        
        
    }
}
