using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProjectClasses
{
    public class Admin : IQuery
    {
        public Admin()
        {

        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Admiistrtor VALUES ('" + ID.ToString() + "', " + "'" + Name +"')";

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
        public void Update() { }
        public void Delete() { }

        //props
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
