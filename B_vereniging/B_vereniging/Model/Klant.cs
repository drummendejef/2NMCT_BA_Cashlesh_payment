using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnectie;

namespace B_vereniging.Model
{
    class Klant
    {
        private const string CONNECTIONSTRING = "ConnectionString";

        /*UITLEG: Klant*/
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

        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        
        //Klant ophalen aan de hand van z'n ID
        public static Klant GetKlant(int id)
        {
            string sql = "SELECT * FROM Klant WHERE Id = @Id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Id", id);
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, par1);
            
            //Opgehaalde klant aanmaken
            Klant klant = new Klant()
            {
                ID = id,
                Naam = reader["Naam"].ToString(),
                Voornaam = reader["Voornaam"].ToString(),
                Telefoonnr = reader["Telefoonnr"].ToString(),
                Saldo = double.Parse(reader["Saldo"].ToString())
            };
            
            return klant;
        }

        //Nieuwe klant in database steken
        public static void NewKlant(string naam, string voornaam, string telefoonnummer, double saldo)
        {
            //SQL statement
            string sql = "INSERT INTO klant VALUES(@Naam,@Voornaam,@Telefoonnr,@Saldo)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Naam", naam);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Voornaam", voornaam);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Telefoonnr", telefoonnummer);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Saldo", saldo);
            Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4);

        }
        
        
        
    }
}
