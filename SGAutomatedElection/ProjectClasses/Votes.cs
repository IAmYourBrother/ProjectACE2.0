using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProjectClasses
{
    public class Votes : IQuery
    {
        public int votecast;

        public Votes(int id)
        {
            ID = id;
        }
        public void Insert()
        { 
            //nothing should happen here since we'll just update the votes in the candidate table. :))
        }
        public int GetLastCount()
        {
            string comstr = "SELECT Votes AS Votes from Candidates WHERE ID = '" + ID.ToString() + "'";
            using (SqlConnection connection = new SqlConnection(Settings.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(comstr, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    votecast = Convert.ToInt32(reader["Votes"]);
                }
                reader.Close();
            }
            return votecast;

        }
        public void Update()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "UPDATE Candidates SET Votes = " +(GetLastCount()+1)+" WHERE ID = '" + ID + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            //nothing here
        }
            //props
        public int ID { get; set; }
    }
}
