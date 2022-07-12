using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    class ClientDAO
    {
        public int Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            sql = string.Format("SELECT DISTINCT Person.Name, UserId,TeamId FROM Person INNER JOIN Team ON (Team.TeamLeaderId=Person.UserId) WHERE  Username= '{0}' AND Password= '{1}'", username, password);
            cn = new SqlConnection(Properties.Settings.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            int id = 0;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["CustomerId"];
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                cn.Close();
            }
            return id;

        }

        public List<Project> GetListOfProjects(int teamId)
        {
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List<Task> tasks = new List<Task>();
                sql = "SELECT" FROM Tank WHERE ProjectId = ' "   + dr["Project Id"].ToString() + " ' ";
          cn2 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                cmd2 = new SqlCommand(sql, cn2);

                cn2.Open();

                dr2 = cmd2.ExecuteReader();

                while (dr2.Read())

                {

                    Task t = new Task((Guid)dr2["TaskId"), dr2["Name"].ToString(), (Status)dr2["StatusId"]);

                    tasks.Add(t);
                }
                dr2.Close();

                Project p = new Project(dr["Name").ToString(), (DateTime)dr["ExpectedStartDate"), (DateTime)dr["ExpectedEndDate"), (Guid)dr["Project Id"], tasks);

                projects.Add(p);
            }
            dr.Close();
        }
catch (SqlException ex)
{
    throw new Exception("Error Getting list", ex);
    }
finally
{
    cn.Close();
}








)



    }
}

    }
}