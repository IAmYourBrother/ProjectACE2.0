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
        public Admin(int id, string name, string password)
        {
            ID = id;
            Name = name;
            Password = password;
        }
        public Admin(int id)
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
                string commandString = "INSERT INTO Administrator VALUES ('" + ID.ToString() + "', " + "'" + Name +"')";
                string commandString2 = "INSERT INTO Accounts VALUES ('" + ID.ToString() + "', '" + Password + "', 'Admin')";
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlCommand command2 = new SqlCommand(commandString2, connection);
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
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
            string commandString = "UPDATE Administrator SET ID='" + ID.ToString() + "', Name='" + Name + "' WHERE ID = '" + ID + "'";
            string commandString2 = "UPDATE Accounts SET ID='" + ID.ToString() + "', PW='" + Password + "', Utype = Admin WHERE ID = '" + ID + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "DELETE FROM Administrator WHERE ID='" + ID.ToString() + "'";
            string commandString2 = "DELETE FROM Accounts WHERE ID='" + ID.ToString() + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        //props
        public int ID { get; set; }//Eto na rin yung Username so, no need to use UN property
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
