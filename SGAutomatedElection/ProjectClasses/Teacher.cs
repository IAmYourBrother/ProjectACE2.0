using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectClasses
{
    public class Teacher : IQuery
    {
        public Teacher(int id, string name, string department, string password)
        {

        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Teacher VALUES ('" + ID.ToString() + "', " + "'" + Name + "', " +Department+ "')";

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

        //Props
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

    }
}
