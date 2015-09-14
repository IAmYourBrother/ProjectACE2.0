using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ProjectClasses
{
    public class Candidate:IQuery
    {
        public Candidate(int id)
        {
            ID = id;
        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Candidate VALUES ('" + ID.ToString() + "', " + "'" + Name + "', '" + Position + "', '"+Votes.ToString()+"')";
                SqlCommand command = new SqlCommand(commandString, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Saved");
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Update()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "UPDATE Candidate SET ID='" + ID.ToString() + "', Name='" + Name + "',  Position='" + Position + "', Votes="+Votes.ToString()+"'";     
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "DELETE FROM Candidate WHERE ID='" + ID.ToString() + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Votes { get; set; }
    }
}
