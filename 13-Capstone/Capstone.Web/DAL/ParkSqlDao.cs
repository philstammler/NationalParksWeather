using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;


        public ParkSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetParks()
        {

            List<Park> parks = new List<Park>();
            {





                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM park";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a Park
                        Park park = new Park();
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = reader["acreage"] as int? ?? default(int);
                        park.ElevationInFeet = reader["elevationInFeet"] as int? ?? default(int);
                        park.MilesOfTrail = Convert.ToDecimal(reader["milesOfTrail"]); 
                        park.NumberOfCampsites = reader["numberOfCampsites"] as int? ?? default(int);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = reader["yearFounded"] as int? ?? default(int);
                        park.AnnualVisitorCount = reader["annualVisitorCount"] as int? ?? default(int);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = reader["entryFee"] as decimal? ?? default(decimal);
                        park.NumberOfAnimalSpecies = reader["numberOfAnimalSpecies"] as int? ?? default(int);


                        parks.Add(MapRowToPark(reader));
                        //parks.Add(MapRowToPark(reader));

                    }
                }


            }

            return parks;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            return new Park()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                ParkName = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Acreage = reader["acreage"] as int? ?? default(int),
                ElevationInFeet = reader["elevationInFeet"] as int? ?? default(int),
                MilesOfTrail = reader["milesOfTrail"] as int? ?? default(int),
                NumberOfCampsites = reader["numberOfCampsites"] as int? ?? default(int),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = reader["yearFounded"] as int? ?? default(int),
                AnnualVisitorCount = reader["annualVisitorCount"] as int? ?? default(int),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = reader["entryFee"] as decimal? ?? default(decimal),
                NumberOfAnimalSpecies = reader["numberOfAnimalSpecies"] as int? ?? default(int)
            };
        }

        public Park GetPark(string parkCode)
        {

            Park result = new Park();
            // Create a new connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                string sql = $"SELECT * FROM park WHERE parkCode = @parkCode";



                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                // Execute the command
                SqlDataReader reader = cmd.ExecuteReader();


                // Loop through each row
                while (reader.Read())
                {
                    // Create a product
                    Park park = new Park();
                    park.ParkCode = Convert.ToString(reader["parkCode"]);
                    park.ParkName = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.Acreage = reader["acreage"] as int? ?? default(int);
                    park.ElevationInFeet = reader["elevationInFeet"] as int? ?? default(int);
                    park.MilesOfTrail = reader["milesOfTrail"] as int? ?? default(int);
                    park.NumberOfCampsites = reader["numberOfCampsites"] as int? ?? default(int);
                    park.Climate = Convert.ToString(reader["climate"]);
                    park.YearFounded = reader["yearFounded"] as int? ?? default(int);
                    park.AnnualVisitorCount = reader["annualVisitorCount"] as int? ?? default(int);
                    park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                    park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    park.ParkDescription = Convert.ToString(reader["parkDesription"]);
                    park.EntryFee = reader["entryFee"] as decimal? ?? default(decimal);
                    park.NumberOfAnimalSpecies = reader["numberOfAnimalSpecies"] as int? ?? default(int);

                    result = park;
                }

                return result;
            }
        }




    }
}
