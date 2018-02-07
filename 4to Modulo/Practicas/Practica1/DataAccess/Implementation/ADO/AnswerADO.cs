using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class AnswerADO : IAnswerRepository
    {
        public void Add(AnswerDTO entity)
        {
            SqlParameter[] parameter = new SqlParameter[3];
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "INSERT INTO [dbo].[Answers] ([QuestionId],[OpenValue],[OptionId]) VALUES (@QuestionId, @OpenValue, @OptionId)";

            parameter [0] = new SqlParameter("@QuestionId", entity.QuestionId);
            parameter [1] = new SqlParameter("@OpenValue", entity.OpenValue);
            parameter[3] = new SqlParameter("@OptionId", entity.OptionId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) inserted", rows);
        }

        public int CountAnswer()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT COUNT [AnswerId] FROM [SurveyDB].[dbo].[Anwers]";

            object oValue = CommandHelper.ExecuteScalar(connectionString, commandText, CommandType.Text);

            if (int.TryParse(oValue.ToString(), out int count))
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

        public void Delete(int entityId)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "DELETE FROM [dbo].[Answers] WHERE [AnswerId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) deleted", rows);
        }

        public List<AnswerDTO> GetAll()
        {
            List<AnswerDTO> results = new List<AnswerDTO>();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Answers]";

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new AnswerDTO
                        {
                            AnswerId = (int)reader["AnswerId"],
                            QuestionId = (int)reader["QuestionId"],
                            OpenValue = reader["OpenValue"].ToString(),
                            OptionId = (int)reader["OptionId"]
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
            }

            return results;
        }

        public AnswerDTO GetById(int entityId)
        {
            AnswerDTO item = new AnswerDTO();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Answers] WHERE [AnswerId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text, parameter))
            {
                if (reader.HasRows)
                {
                    item = new AnswerDTO
                    {
                        AnswerId = (int)reader["AnswerId"],
                        QuestionId = (int)reader["QuestionId"],
                        OpenValue = reader["OpenValue"].ToString(),
                        OptionId = (int)reader["OptionId"],
                    };
                }
                else
                {
                    Console.WriteLine("Id not found");
                }

                return item;
            }
        }

        public void Update(AnswerDTO entity)
        {
            int entityId = entity.AnswerId;
            int questionid = 1;
            string openvalue = "Open Answer";
            int optionid = 1;
            SqlParameter[] parameter = new SqlParameter[4];

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "UPDATE [dbo].[Answers] SET ([QuestionId],[OpenValue],[OptionId]) = (@QuestionId, @OpenValue, @OptionId) WHERE [AnswerId] = @entityId";

            parameter[0] = new SqlParameter("@QuestionId", questionid);
            parameter[1] = new SqlParameter("@openvalue", openvalue);
            parameter[2] = new SqlParameter("@OptionId", optionid);
            parameter[3] = new SqlParameter("@entityId", entityId);

            int count = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("Items modified: {0}", count);
        }
    }
}
