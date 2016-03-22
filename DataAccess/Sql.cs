using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Sql
    {
        private string _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["WCFData"].ToString();

        public bool RunProcedure(string ProcedureName, Dictionary<string, object> Parameters) {

            bool success = true;

            using (SqlConnection conn = new SqlConnection(_connectionstring)) {

                try {

                    SqlCommand cmd = new SqlCommand(ProcedureName, conn);

                    foreach (KeyValuePair<string, object> parameter in Parameters) {

                        cmd.Parameters.Add("@" + parameter.Key, parameter.Value);
                    }

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();

                }
                catch (Exception ex) {
                    success = false;
                    // TODO: Log Error
                }
            }

            return success;
        }
    }
}
