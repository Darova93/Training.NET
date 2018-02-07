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
            string commandText = "SELECT COUNT [QuestionTypeId] FROM [SurveyDB].[dbo].[QuestionTypes]";

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
            string commandText = "DELETE FROM [dbo].[QuestionTypes] WHERE [QuestionTypeId] = @entityId";

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
                            QuestionTypeId = (int)reader["QuestionTypeId"],
                            Description = reader["Description"].ToString()
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

        public QuestionTypeDTO GetById(int entityId)
        {
            QuestionTypeDTO item = new QuestionTypeDTO();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[QuestionTypes] WHERE [QuestionTypeId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text, parameter))
            {
                if (reader.HasRows)
                {
                    item = new QuestionTypeDTO
                    {
                        QuestionTypeId = (int)reader["QuestionTypeId"],
                        Description = reader["Description"].ToString(),
                    };
                }
                else
                {
                    Console.WriteLine("Id not found");
                }

                return item;
            }
        }

        public void Update(QuestionTypeDTO entity)
        {
            int entityId = entity.QuestionTypeId;
            string description = "Gay";
            SqlParameter[] parameter = new SqlParameter[2];

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "UPDATE [dbo].[QuestionTypes] SET [Description] = @Description WHERE [QuestionTypeId] = @entityId";

            parameter[0] = new SqlParameter("@Description", description);
            parameter[1] = new SqlParameter("@entityId", entityId);

            int count = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("Items modified: {0}", count);
        }

    }
}
