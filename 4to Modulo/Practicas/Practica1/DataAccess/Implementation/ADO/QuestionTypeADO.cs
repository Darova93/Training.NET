using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class QuestionTypeADO : IQuestionTypeRepository
    {
        public void Add(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "INSERT INTO [dbo].[QuestionTypes]([Description])VALUES(@Description)";

            SqlParameter parameter = new SqlParameter("@Description", entity.Description);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) inserted", rows);
        }

        public int CountQuestionType()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "SELECT COUNT (QuestionTypeId) FROM [SurveyDB].[dbo].[QuestionTypes]";

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

            string commandText = "DELETE FROM [dbo].[QuestionTypes] WHERE QuestionTypeId = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) deleted", rows);
        }

        public List<QuestionTypeDTO> GetAll()
        {

            List<QuestionTypeDTO> results = new List<QuestionTypeDTO>();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "SELECT * FROM [dbo].[QuestionTypes]";

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new QuestionTypeDTO
                        {
                            Description = reader["Description"].ToString(),
                            QuestionTypeId = (int)reader["QuestionTypeId"]
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

        public QuestionTypeDTO GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionTypeDTO entity)
        {
            throw new NotImplementedException();
        }

    }
}
