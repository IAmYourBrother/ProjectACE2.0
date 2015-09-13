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
            ID = id;
            Name = name;
            Department = department;
            Password = password;
        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Teacher VALUES ('" + ID.ToString() + "', '" + Name + "', '" +Department+ "')";
                string commandString2 = "INSERT INTO Accounts VALUES ('" + ID.ToString() + "', '" + Password + "', 'Teacher')";
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
            string commandString = "UPDATE Teacher SET ID='" + ID.ToString() + "', Name='" + Name + "',  Department='" + Department + "'";
            string commandString2 = "UPDATE Accounts SET ID='" + ID.ToString() + "', PW='" + Password + "', Utype = 'Teacher'";
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
            string commandString = "DELETE FROM Teacher WHERE ID='" + ID.ToString() + "'";
            string commandString2 = "DELETE FROM Accounts WHERE ID='" + ID.ToString() + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        //Props
        public int ID { get; set; }//Eto na rin yung Username so, no need to use UN property
        public string Name { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

    }
}
