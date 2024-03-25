using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {

        public SqlConnection sqlConn = Adapter.NewSqlConn();

        protected void OpenConnection()
        {
            if (sqlConn == null)
                sqlConn = Adapter.NewSqlConn();
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        private static SqlConnection NewSqlConn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringLocal"].ConnectionString);
        }
    }
}
