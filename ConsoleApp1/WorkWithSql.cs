using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;

namespace ConsoleAppPersons
{
    public class WorkWithSql
    {
        static string connectionString = "Data Source=localhost; Initial Catalog=testDB; User id=sa; Password=P@ssword; Integrated Security=SSPI; TrustServerCertificate=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public void OpenConnectionToSql()
        {
            sqlConnection.Open();
        }

        public void InsertToTablePersons(string lastName, string firstName, int age)
        {
            string insertQuery = $"INSERT INTO Persons VALUES ('{lastName}','{firstName}', {age})";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Data successfully written");
        }

        public void SelectAllFromDbAdnPrint()
        {
            string selectQuery = "SELECT * FROM Persons";
            SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader dataReader = selectCommand.ExecuteReader();

            if (!dataReader.HasRows)
                Console.WriteLine("Table is empty");

            while (dataReader.Read())
            {
                Console.WriteLine($"Id -- {dataReader.GetValue(0).ToString()}");
                Console.WriteLine($"LastName -- {dataReader.GetValue(1).ToString()}");
                Console.WriteLine($"FirstName -- {dataReader.GetValue(2).ToString()}");
                Console.WriteLine($"Age -- {dataReader.GetValue(3).ToString()}");
                Console.WriteLine("-------------------------------");
            }



            dataReader.Close();
        }

        public void DeleteFromDbById()
        {
            Console.WriteLine("What id you want to delete?");
            int personId = int.Parse(Console.ReadLine());
            string deleteQuery = $"DELETE from Persons where PersonId = {personId}";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Data successfully deleted");
        }

        public void CloseConnectionToSql()
        {
            sqlConnection.Close();
        }
    }
}
