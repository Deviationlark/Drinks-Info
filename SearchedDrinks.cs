using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DrinksInfo
{
    public class SearchedDrinks
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        internal void Read()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM SearchedDrinks";

                List<DrinkDB> searchedDrinks = connection.Query<DrinkDB>(query).ToList();
            }
        }
        internal void Write(DrinkDB drink)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO SearchedDrinks(id,category,name) VALUES('{drink.Id}', '{drink.Category}', '{drink.Name}')";

                tableCmd.ExecuteNonQuery();
            }
        }   
    }
}

