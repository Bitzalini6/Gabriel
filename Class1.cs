using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;

namespace Gabriel
{
    class Class1
    {
        DataTable dTable;
        SqlDataAdapter sqlDA;
        SqlCommand sqlCmd;
        SqlConnection sqlCon;
        string conStr;

        public Class1()
        {

            conStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Tables;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\Database1.mdf";
        sqlCon = new SqlConnection(conStr);
        }
        public int CudCMD(string sql)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            sqlCmd = new SqlCommand(sql, sqlCon);
            return  sqlCmd.ExecuteNonQuery();
        }

        public DataTable selectCmd(string sql)
        {
            dTable = new DataTable();
            sqlDA = new SqlDataAdapter(sql, conStr);
            sqlDA.Fill(dTable);
            sqlDA.Dispose();
            return dTable;
        }
    }
}

