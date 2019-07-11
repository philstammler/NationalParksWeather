using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class Survey_ResultSqlDao : ISurvey_ResultSqlDao
    {
        private const string Sql_GetAllSurveys = "SELECT * FROM survey_result JOIN park on park.parkCode = survey_result.parkCode;";
        private const string Sql_AddResult = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @email, @state, @activityLevel);";
        private const string Sql_GetTopRankedParks = "SELECT COUNT(survey_result.parkCode) as numVotes, park.parkName, survey_result.parkCode FROM survey_result JOIN park ON park.parkCode = survey_result.parkCode GROUP BY parkName, survey_result.parkCode ORDER BY numVotes DESC, parkName ASC, parkCode";

        private string connectionString;

        public Survey_ResultSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Survey_Result> GetAllSurveys()
        {
            List<Survey_Result> output = new List<Survey_Result>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql_GetAllSurveys, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Survey_Result sr = new Survey_Result();

                    sr.Id = Convert.ToInt32(reader["surveyId"]);
                    sr.ParkCode = Convert.ToString(reader["parkCode"]);
                    sr.Email = Convert.ToString(reader["emailAddress"]);
                    sr.State = Convert.ToString(reader["state"]);
                    sr.ActivityLevel = Convert.ToString(reader["activityLevel"]);

                    output.Add(sr);
                }
            }

            return output;
        }

        public bool AddResult(Survey_Result result)
        {
            bool output;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_AddResult, conn);
                    cmd.Parameters.AddWithValue("@parkCode", result.ParkCode);
                    cmd.Parameters.AddWithValue("@email", result.Email);
                    cmd.Parameters.AddWithValue("@state", result.State);
                    cmd.Parameters.AddWithValue("@activityLevel", result.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
                output = true;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public List<SurveyResultViewModel> GetTopRankedParks()
        {
            List<SurveyResultViewModel> output = new List<SurveyResultViewModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Sql_GetTopRankedParks, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SurveyResultViewModel srvm = new SurveyResultViewModel();

                    srvm.ParkCode = Convert.ToString(reader["parkCode"]);
                    srvm.ParkName = Convert.ToString(reader["parkName"]);
                    srvm.VoteCount = Convert.ToInt32(reader["numVotes"]);

                    output.Add(srvm);
                }
            }

            return output;
        }
        public static List<SelectListItem> States = new List<SelectListItem>()
    {
        new SelectListItem() {Text="Alabama", Value="AL"},
        new SelectListItem() { Text="Alaska", Value="AK"},
        new SelectListItem() { Text="Arizona", Value="AZ"},
        new SelectListItem() { Text="Arkansas", Value="AR"},
        new SelectListItem() { Text="California", Value="CA"},
        new SelectListItem() { Text="Colorado", Value="CO"},
        new SelectListItem() { Text="Connecticut", Value="CT"},
        new SelectListItem() { Text="District of Columbia", Value="DC"},
        new SelectListItem() { Text="Delaware", Value="DE"},
        new SelectListItem() { Text="Florida", Value="FL"},
        new SelectListItem() { Text="Georgia", Value="GA"},
        new SelectListItem() { Text="Hawaii", Value="HI"},
        new SelectListItem() { Text="Idaho", Value="ID"},
        new SelectListItem() { Text="Illinois", Value="IL"},
        new SelectListItem() { Text="Indiana", Value="IN"},
        new SelectListItem() { Text="Iowa", Value="IA"},
        new SelectListItem() { Text="Kansas", Value="KS"},
        new SelectListItem() { Text="Kentucky", Value="KY"},
        new SelectListItem() { Text="Louisiana", Value="LA"},
        new SelectListItem() { Text="Maine", Value="ME"},
        new SelectListItem() { Text="Maryland", Value="MD"},
        new SelectListItem() { Text="Massachusetts", Value="MA"},
        new SelectListItem() { Text="Michigan", Value="MI"},
        new SelectListItem() { Text="Minnesota", Value="MN"},
        new SelectListItem() { Text="Mississippi", Value="MS"},
        new SelectListItem() { Text="Missouri", Value="MO"},
        new SelectListItem() { Text="Montana", Value="MT"},
        new SelectListItem() { Text="Nebraska", Value="NE"},
        new SelectListItem() { Text="Nevada", Value="NV"},
        new SelectListItem() { Text="New Hampshire", Value="NH"},
        new SelectListItem() { Text="New Jersey", Value="NJ"},
        new SelectListItem() { Text="New Mexico", Value="NM"},
        new SelectListItem() { Text="New York", Value="NY"},
        new SelectListItem() { Text="North Carolina", Value="NC"},
        new SelectListItem() { Text="North Dakota", Value="ND"},
        new SelectListItem() { Text="Ohio", Value="OH"},
        new SelectListItem() { Text="Oklahoma", Value="OK"},
        new SelectListItem() { Text="Oregon", Value="OR"},
        new SelectListItem() { Text="Pennsylvania", Value="PA"},
        new SelectListItem() { Text="Rhode Island", Value="RI"},
        new SelectListItem() { Text="South Carolina", Value="SC"},
        new SelectListItem() { Text="South Dakota", Value="SD"},
        new SelectListItem() { Text="Tennessee", Value="TN"},
        new SelectListItem() { Text="Texas", Value="TX"},
        new SelectListItem() { Text="Utah", Value="UT"},
        new SelectListItem() { Text="Vermont", Value="VT"},
        new SelectListItem() { Text="Virginia", Value="VA"},
        new SelectListItem() { Text="Washington", Value="WA"},
        new SelectListItem() { Text="West Virginia", Value="WV"},
        new SelectListItem() { Text="Wisconsin", Value="WI"},
        new SelectListItem() { Text="Wyoming", Value="WY"}
    };
    }
}
