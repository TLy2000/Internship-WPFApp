/// Author
/// Thinh Ly
/// 11/12/2020
/// WPF app
///

using System.Collections.Generic;
using System.Data.SqlClient;

namespace WPFApp
{
    public class DataAccess
    {
        public static void DatabaseActions(Person person, string table, string name)
        {
            Person user = (new Person { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName });
            WriteToDatabase(person, table, name);
        }
        public static List<Person> GetPeople(string table, string name)
        {
            SqlConnection conn = new SqlConnection(Helper.CnnVal(name));
            conn.Open();
            SqlCommand cmdRd = new SqlCommand("SELECT FirstName, LastName FROM " + table, conn);
            SqlDataReader reader = cmdRd.ExecuteReader();
            // creates a new object and object list for the objects to populate
            List<Person> userList = new List<Person>();
            // reads each line while there is something in the row
            while (reader.Read())
            {
                // creates new instance of the person object
                Person user = new Person();
                // gets the property values from the database
                user.FirstName = reader.GetString(0);
                user.LastName = reader.GetString(1);
                // adds to a list of objects
                userList.Add(user);
            }
            reader.Close();
            conn.Close();
            return userList;
        }
        private static void WriteToDatabase(Person person, string table, string name)
        {
            // writes to the database
            SqlConnection conn = new SqlConnection(Helper.CnnVal(name));
            conn.Open();
            // sql commands to insert each field in the corresponding column
            SqlCommand insertComm = new SqlCommand("INSERT INTO " + table + "(Id, FirstName, LastName) VALUES (@0, @1, @2)", conn);
            insertComm.Parameters.Add(new SqlParameter("0", person.Id));
            insertComm.Parameters.Add(new SqlParameter("1", person.FirstName));
            insertComm.Parameters.Add(new SqlParameter("2", person.LastName));
            insertComm.ExecuteNonQuery();
            conn.Close();
            return;
        }
        
    }
}
