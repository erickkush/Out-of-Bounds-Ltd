using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    class SuperDAO
    {
        protected Customer GetCustomer(int custId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            Customer cust;

            sql = "SELECT * FROM Customer WHERE CustomerId = " + custId;
            cn = new SqlConnection("Server=localhost;Database=wm75;User Id=root;Password=abcd1234;");
            cmd = new SqlCommand(sql, cn);

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                dr.Read();
                cust = new Customer(dr["Name"].ToString(), (int)dr["CustomerId"]);
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting Customer", ex);
            }
            finally
            {
                cn.Close();
            }
            return cust;
        }

    }
}
