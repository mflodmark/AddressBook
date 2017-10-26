using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    class DataAccess
    {
        private SqlConnection con;

        public DataAccess()
        {
            var connectionString = Properties.Settings.Default.AddressBookConnection;
            con = new SqlConnection(connectionString);
        }

        public DataSet ExecuteSelectCommand(string cmdText, CommandType cmdType)
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable();

            var cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            //cmd.Parameters.AddRange(param);

            try
            {
                con.Open();

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }

                dataSet.Tables.Add(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }

            return dataSet;


        }
    }

   
}
