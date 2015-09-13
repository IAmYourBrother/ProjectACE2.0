using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProjectClasses
{
    public static class Helper
    {
        public static int GetNewID(SqlConnection connection, string tableName, string fieldName)
        {
            string commandString = "SELECT TOP 1 ID FROM [" + tableName + "] ORDER BY id DESC";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();

            int lastID = (int)dataReader[fieldName];

            dataReader.Close();
            dataReader.Dispose();

            return lastID + 1;
        }
    }
}
