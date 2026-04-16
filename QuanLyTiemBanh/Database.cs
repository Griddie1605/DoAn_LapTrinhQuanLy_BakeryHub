using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace BakeryHub
{
    internal class Database
    {
        public SqlConnection cn;
        SqlDataAdapter da;

        public Database(string srvname, string dbName)
        {
            string cnnstr = "Data source=" + srvname + ";Initial Catalog=" + dbName + ";Integrated Security=True";
            cn = new SqlConnection(cnnstr);
        }

        public DataTable laydl(string sqlstr)
        {
            da = new SqlDataAdapter(sqlstr, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void thucthi(SqlCommand sqlcmd)
        {
            cn.Open();
            sqlcmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
