using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLDATA
{
    class SQL
    {
        string ConnectionString = "Data Source=.;Initial Catalog = Multipeople; Integrated Security=True";
        public int? insert(Personer personer)
        {

            // Prepare a proper parameterized query 
            string sql = "Insert into personer(navn, dob) output inserted.id values(@navn,@dob)";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Open the connection to the database. 
                    // This is the first critical step in the process.
                    // If we cannot reach the db then we have connectivity problems
                    cnn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.Add("@Navn", SqlDbType.NVarChar).Value = personer.Navn;
                        cmd.Parameters.Add("@Dob", SqlDbType.DateTime).Value = personer.Dob;

                        // Let's ask the db to execute the query
                        int id = (int)cmd.ExecuteScalar();

                        return id;

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.Message);
                    return null;
                }
            }
        }
        internal List<Personer> select(DateTime datetime)
        {
            List<Personer> personList = new List<Personer>();
            string sql = $"Select * from Personer where dob = @dob";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = datetime;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[2]}");
                        personList.Add(new Personer()
                        {
                            Id = (int)reader[0],
                            Navn = (string)reader[1],
                            Dob = (DateTime)reader[2]
                        });
                    }

                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.GetType() + "\n" + ex.Message);
                    return null;
                }

            }
            return personList;

        }
        internal List<Personer> select2(DateTime dateTime, DateTime dateTime2)
        {
            List<Personer> personList = new List<Personer>();
            string sql = "select * from Personer where dob >= @dob and dob <= @dob2";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);                    
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dateTime;
                    cmd.Parameters.Add("@dob2", SqlDbType.DateTime).Value = dateTime2;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[2]}");
                        personList.Add(new Personer()
                        {
                            Id = (int)reader[0],
                            Navn = (string)reader[1],
                            Dob = (DateTime)reader[2]
                        });
                    }

                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    Console.WriteLine("ERROR:" + ex.GetType() + "\n" + ex.Message);
                    return null;
                }

            }
            return personList;

        }
    }
}
