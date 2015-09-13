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
        public Student(int id, string name, int year, string section, string username, string password, bool hasvoted)
        {
            ID = id;
            Name = name;
            YearLevel = year;
            Section = section;
            Password = password;
            HasVoted = hasvoted;
        }
        //IQuery methods
        public void Insert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                connection.Open();
                string commandString = "INSERT INTO Students VALUES ('" + ID.ToString() + "', " + "'" + Name + "', " + YearLevel.ToString() + Section + "')";

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

            string commandString = "UPDATE Students SET ID='" +ID.ToString()+ "', Name='" +Name+ "',  YearSection='" +YearLevel.ToString() + Section+  "'";

            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);
            connection.Open();

            string commandString = "DELETE FROM Students WHERE ID='" +ID+ "'";

            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        //Props
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasVoted { get; set; }
        public string Section { get; set; }
        public int YearLevel { get; set; }

    }
}
