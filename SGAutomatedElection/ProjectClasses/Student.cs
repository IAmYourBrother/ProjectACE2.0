using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
namespace ProjectClasses
{
    public class Student : IQuery
    {
        public Student(int id, string name, string section, string password, int hasvoted)
        {
            ID = id;
            Name = name;
            Section = section;
            Password = password;
            HasVoted = hasvoted;
        }
        public Student(int id)
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
                string commandString = "INSERT INTO Student VALUES ('" + ID.ToString() + "', " + "'" + Name + "', '" + Section + "', "+HasVoted+")";
                string commandString2 = "INSERT INTO Accounts VALUES ('"+ID.ToString()+"', '"+Password+"', 'Student')";
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
            string commandString = "UPDATE Student SET ID='" +ID.ToString()+ "', Name='" +Name+ "',  YearSection='" + Section+  "'";
            string commandString2 = "UPDATE Accounts SET ID='" + ID.ToString() + "', PW='" + Password + "', Utype = 'Student'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void VUpdate()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "UPDATE Student SET HasVoted '"+HasVoted+"'";         
            SqlCommand command = new SqlCommand(commandString, connection);
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();
            string commandString = "DELETE FROM Student WHERE ID='" +ID.ToString()+ "'";
            string commandString2 = "DELETE FROM Accounts WHERE ID='" + ID.ToString() + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlCommand command2 = new SqlCommand(commandString2, connection);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        //addtionals
        public void FindYou(int id)
        {
 
        }

        //Props
        public int ID { get; set; }//Eto na rin yung Username so, no need to use UN property
        public string Name { get; set; }
        public string Password { get; set; }
        public int HasVoted { get; set; }
        public string Section { get; set; }
    }
}
