using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectie
{
    public class Database
    {
        #region "connections"

        //connectie (open) geven met database
        private static DbConnection GetConnection(string connStringName)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connStringName];

            DbConnection con = DbProviderFactories.GetFactory(settings.ProviderName).CreateConnection();
            con.ConnectionString = connStringName;
            con.Open();

            return con;
        }

        //transactie maken & teruggeven
        public static DbTransaction BeginTransAction(string connStringName)
        {
            DbConnection con = null;
            try
            {
                con = GetConnection(connStringName);
                return con.BeginTransaction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ReleaseConnection(con);
                throw;
            }
        }

        //connectie vrijgeven
        public static void ReleaseConnection(DbConnection con)
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }

        #endregion


        #region "build commands"
        
        //commando opbouwen
        private static DbCommand BuildCommand(string conStringName, string sql, params DbParameter[] parameters)
        {
            DbCommand command = GetConnection(conStringName).CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            if(parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;
        }

        //commando opbouwen via transactie
        public static DbCommand BuildCommand(DbTransaction trans, string sql, params DbParameter[] parameters)
        {
            DbCommand command = trans.Connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Transaction = trans;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;
        }

        //parameter opbouwen
        public static DbParameter AddParameter(string connStrName,string name, object value)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connStrName];
            DbParameter par = DbProviderFactories.GetFactory(settings.ProviderName).CreateParameter();
            par.ParameterName = name;
            par.Value = value;

            return par;
        }

        #endregion


        #region "data aanspreken (select, update, insert)"
        
        //get om data op te halen (select)
        // geeft datareader terug met alle data
        public static DbDataReader GetData(string conStringName, string sql, params DbParameter[] parameters)
        {
            //Maakt ze hier al aan omdat hij ze misschien in z'n catch nodig heeft.
            DbCommand command = null;
            DbDataReader reader = null;

            try
            {
                command = BuildCommand(conStringName, sql, parameters);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null)
                    reader.Close();
                if (command != null)
                    ReleaseConnection(command.Connection);

                throw;
            }
        }

        public static DbDataReader GetData(DbTransaction trans, string sql, params DbParameter[] parameters)
        {
            DbCommand command = null;
            DbDataReader reader = null;

            try
            {
                command = BuildCommand(trans, sql, parameters);

                //GEEN commandbehavior.CloseConnection meegeven!
                reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (reader != null)
                    reader.Close();
                if (command != null)
                    ReleaseConnection(command.Connection);

                throw;
            }

        }

        //modify om bestaande data te wijzigen (update)
        // geeft aantal aangepaste rijen terug
        public static int ModifyData(string conStringName, string sql, params DbParameter[] parameters)
        {
            DbCommand command = null;

            try
            {
                command = BuildCommand(conStringName, sql, parameters);
                ReleaseConnection(command.Connection);
                //Aantal aangepaste rijen terugsturen
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null)
                    ReleaseConnection(command.Connection);
                return 0;
            }
        }

        public static int ModifyData(DbTransaction trans, string sql, params DbParameter[] parameters)
        {
            DbCommand command = null;
            try
            {
                command = BuildCommand(trans, sql, parameters);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null)
                    ReleaseConnection(command.Connection);
                return 0;
                throw;
            }
        }

        //insert om nieuwe data in te voeren (insert)
        // geeft het id terug van het nieuw ingevoerd record
        public static int InsertData(string connstrName, string sql, params DbParameter[] parameters)
        {
            DbCommand command = null;
            try
            {
                command = BuildCommand(connstrName, sql, parameters);
                command.ExecuteNonQuery();
                
                command.Parameters.Clear();
                command.CommandText = "SELECT @IDENTITY";

               
                int identity = Convert.ToInt32(command.ExecuteScalar());

                return identity;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
		return 0;
                throw;
            }
           
        }

        #endregion


    }
}
