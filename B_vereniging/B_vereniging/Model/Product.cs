using DatabaseConnectie;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_vereniging.Model
{
    class Product
    {
        private const string CONNECTIONSTRING = "ConnectionString";

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

        //Producten ophalen
        public static Product GetProducten()
        {
            string sql = "SELECT * FROM Producten";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);

            //Opgehaalde klant aanmaken
            Product product = new Product()
            {
                ID = int.Parse(reader["Id"].ToString()),
                Naam = reader["Naam"].ToString(),
                Stukprijs = double.Parse(reader["Stukprijs"].ToString()),
                Omschrijving = reader["Omschrijving"].ToString()
            };

            return product;
        }

        //Nieuwe product aanmaken
        public static void NewProduct(string naam, double stukprijs, string omschrijving)
        {
            string sql = "INSERT INTO Producten VALUES(@Naam, @Stukprijs, @Omschrijving)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Naam", naam);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Stukprijs", stukprijs);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Omschrijving", omschrijving);
            Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3);
        }
        
    }
}
