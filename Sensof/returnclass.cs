using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Sensof
{
    class returnclass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8GI342;Initial Catalog=sensof;Integrated Security=True;");



        public string scalarReturn(string q)
        {
            string s = "";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(q, con);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                s = "";
            }
            con.Close();
            return s;

        }
    }
}
