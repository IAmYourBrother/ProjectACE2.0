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
        public Teacher(int id, string name, string department, string username, string password)
        {
            ID = id;
            Name = name;
            Department = department;
            Username = username;
            Password = password;
        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Teacher VALUES ('" + ID.ToString() + "', " + "'" + Name + "', " +Department+ "')";
                string commandString2 = "INSERT INTO Accounts VALUES ('" + ID.ToString() + "', " + Username + ", " + Password + ", " + "Teacher" + "')";
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
            string commandString = "UPDATE Teacher SET ID='" + ID.ToString() + "', Name='" + Name + "',  Department='" + Department + "'";
            string commandString2 = "UPDATE Accounts SET ID='" + ID.ToString() + ", UN ='" + Username + "', PW='" + Password + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "DELETE FROM Teacher WHERE ID='" + ID.ToString() + "'";
            string commandString2 = "DELETE FROM Accounts WHERE ID='" + ID.ToString() + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        //Props
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

    }
}
