using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace DAL
{
    public class IndicatorDao : IIndicatorDao
    {
        private readonly string connectionstring;

        public IndicatorDao(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public bool UpdateIndicator(Indicator indicator)
        {
            string sqlExpression = "UpdateIndicator";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@Indicator_Id",
                        Value = indicator.IndicatorId
                    };

                    SqlParameter name = new SqlParameter
                    {
                        ParameterName = "@Value",
                        Value = indicator.Value
                    };

                    command.Parameters.Add(id);
                    command.Parameters.Add(name);

                    var returnParameter = command.ExecuteNonQuery();
                    return returnParameter > 0 ? true : false;
                }
                catch
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(UpdateIndicator)}");
                }
            }
        }

        public List<Indicator> GetAllIndicators(int universityd)
        {
            string sqlExpression = "GetAllIndicators";
            List<Indicator> indicators = new List<Indicator>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universityd
                    };

                    command.Parameters.Add(id);

                    SqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var indicator = GetIndicator(reader);

                        indicators.Add(indicator);
                    }
                }
                catch(Exception e)
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllIndicators)}");
                }
            }

            return indicators;
        }

        public List<University> GetAllUniversities()
		{
            var sqlExpression = "GetAllUniversities";
            var universities = new List<University>();
            using (var connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        University university = new University()
                        {
                            Id = (int)reader.GetValue(0),
                            UniversityName = (string)reader.GetValue(1),
                        };

                        universities.Add(university);
                    }
                }
                catch
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllUniversities)}");
                }
            }

            return universities;
        }

        public List<int> GetAllYearsByUniversityId(int universityId)
		{
            var sqlExpression = "GetAllYearsByUniversityId";
            var years = new List<int>();
            using (var connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universityId
                    };

                    command.Parameters.Add(id);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        var year = (int)reader.GetValue(0);

                        years.Add(year);
                    }
                }
                catch
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllYearsByUniversityId)}");
                }
            }

            return years;
        }

        public List<Indicator> GetAllIndicatorsByUniversityAndYear(int universityId, int year)
        {
            var sqlExpression = "GetAllIndicatorsByUniversityAndYear";
            var indicators = new List<Indicator>();

            using (var connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    var idParam = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universityId
                    };
                    var yearParam = new SqlParameter
                    {
                        ParameterName = "@Year",
                        Value = year
                    };

                    command.Parameters.Add(idParam);
                    command.Parameters.Add(yearParam);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var indicator = GetIndicator(reader);

                        indicators.Add(indicator);
                    }
                }
                catch
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllIndicatorsByUniversityAndYear)}");
                }
            }

            return indicators;
        }

        public List<Indicator> GetAllIndicatorsByUniversity(int universityId)
        {
            var sqlExpression = "GetAllIndicatorsByUniversity";
            var indicators = new List<Indicator>();

            using (var connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    var idParam = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universityId
                    };

                    command.Parameters.Add(idParam);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var indicator = GetIndicator(reader);

                        indicators.Add(indicator);
                    }
                }
                catch
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllIndicatorsByUniversityAndYear)}");
                }
            }

            return indicators;
        }

        public List<Indicator> GetIndicatorsByIdAndUniversity(int universityd, int indicatorId)
        {
            string sqlExpression = "GetIndicatorsByIdAndUniversity";
            List<Indicator> indicators = new List<Indicator>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter id = new SqlParameter
                    {
                        ParameterName = "@UniversityId",
                        Value = universityd
                    };
                    SqlParameter indicatorIdParam = new SqlParameter
                    {
                        ParameterName = "@IndicatorId",
                        Value = universityd
                    };

                    command.Parameters.Add(id);
                    command.Parameters.Add(indicatorIdParam);

                    SqlDataReader reader;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var indicator = GetIndicator(reader);

                        indicators.Add(indicator);
                    }
                }
                catch(Exception e)
                {
                    throw new Exception($"layer = DAL, class = {nameof(IndicatorDao)}, method = {nameof(GetAllIndicators)}");
                }
            }

            return indicators;
        }

        private Indicator GetIndicator(SqlDataReader reader)
        {
            Indicator indicator = new Indicator()
            {
                IndicatorId = (int)reader.GetValue(0),
                UniversityId = (int)reader.GetValue(1),
                IndicatorName = (string)reader.GetValue(2),
                Value = (int)reader.GetValue(3),
                UnitOfMeasure = (string)reader.GetValue(4),
                UniversityName = (string)reader.GetValue(5),
                Year = (int)reader.GetValue(6)
            };

            return indicator;
        }
    }
}
