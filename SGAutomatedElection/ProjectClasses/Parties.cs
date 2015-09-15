using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectClasses
{
    public class Parties :IQuery
    {
        public Parties()
        { 
        }
        //IQuery Methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Parties VALUES ('" + Name + "')";
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
            string commandString = "UPDATE Parties SET Name='" + Name +"'";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "DELETE FROM Parties WHERE Name='" + Name + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        //props
        public string Name { get; set; }
    }
}
