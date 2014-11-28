using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnectie;

namespace B_vereniging.Model
{
    class Kassa
    {
        private const string CONNECTIONSTRING = "ConnectionString";

        /*UITLEG: Kassa's*/
        //Properties

        public int ID { get; set; }

        private string _beschrijving;

        public string Beschrijving
        {
            get { return _beschrijving; }
            set { _beschrijving = value; }
        }

        private string _plaats;

        public string Plaats
        {
            get { return _plaats; }
            set { _plaats = value; }
        }


        //Alle kassa's ophalen
        public static List<Kassa> GetKassas()
        {
            //Lijst van terug te keren kassa's
            List<Kassa> kassa = new List<Kassa>();

            //SQl statement aanmaken en uitvoeren.
            string sql = "SELECT * FROM Kassa";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            
            //Opgehaalde kassa's overlopen, en bij elke kassa een nieuwe kassa aanmaken.
            while(reader.Read())
            {
                //Nieuwe kassa aanmaken.
                Kassa k = new Kassa()
                {
                    ID = int.Parse(reader["Id"].ToString()),
                    Beschrijving = reader["Beschrijving"].ToString(),
                    Plaats = reader["Plaats"].ToString()
                };
                //Nieuwe kassa toevoegen aan lijstje van kassa's
                kassa.Add(k);
            }

            //Lijst van kassa's terug geven.
            return kassa;
        }

        //Een nieuwe kassa opslaan
        public static void NewKassa(string beschrijving, string plaats)
        {
            //sql statement
            string sql = "INSERT INTO Kassa VALUES(@Beschrijving,@Plaats)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Beschrijving", beschrijving);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Plaats", plaats);
            Database.InsertData(CONNECTIONSTRING, sql, par1, par2);
        }
        


        
        
    }
}
