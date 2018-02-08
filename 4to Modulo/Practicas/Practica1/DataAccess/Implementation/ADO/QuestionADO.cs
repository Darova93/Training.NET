using DataAccess.Implementation.Helpers;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class QuestionADO : IQuestionRepository
    {
        public void Add(QuestionDTO entity)
        {
            SqlParameter[] parameter = new SqlParameter[2];
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "INSERT INTO [dbo].[Questions]([Description],[QuestionTypeId])VALUES(@Description,@QuestionTypeId)";

            parameter[0] = new SqlParameter("@Description", entity.Text);
            parameter[1] = new SqlParameter("@QuestionTypeId", entity.QuestionTypeId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) inserted", rows);
        }

        public int CountQuestion()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT COUNT [QuestionId] FROM [SurveyDB].[dbo].[Questions]";

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
            string commandText = "DELETE FROM [dbo].[Questions] WHERE [QuestionId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) deleted", rows);
        }

        public List<QuestionDTO> GetAll()
        {
            List<QuestionDTO> results = new List<QuestionDTO>();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Questions]";

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new QuestionDTO
                        {
                            QuestionId = (int)reader["QuestionId"],
                            Text = reader["Text"].ToString(),
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

        public QuestionDTO GetById(int entityId)
        {
            QuestionDTO item = new QuestionDTO();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Questions] WHERE [QuestionId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text, parameter))
            {
                if (reader.HasRows)
                {
                    item = new QuestionDTO
                    {
                        QuestionId = (int)reader["QuestionId"],
                        Text = reader["Description"].ToString(),
                        QuestionTypeId = (int)reader["QuestionTypeId"],
                    };
                }
                else
                {
                    Console.WriteLine("Id not found");
                }

                return item;
            }
        }

        public void Update(QuestionDTO entity)
        {
            int entityId = entity.QuestionId;
            string text = "New Question";
            int questiontypeid = 1;
            SqlParameter[] parameter = new SqlParameter[3];

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "UPDATE [dbo].[Questions] SET ([Text],[QuestionTypeId]) = (@Description, @QuestionTypeId) WHERE [QuestionTypeId] = @entityId";

            parameter[0] = new SqlParameter("@Text", text);
            parameter[1] = new SqlParameter("@QuestionTypeId", questiontypeid);
            parameter[2] = new SqlParameter("@entityId", entityId);

            int count = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("Items modified: {0}", count);
        }

        public static void TransactionTest(QuestionDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            int questionTypeId = 100;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand();// connection.CreateCommand();
                command.Transaction = sqlTran;
                command.Connection = connection;

                try
                {
                    command.CommandText =
                     "INSERT INTO [dbo].[Question] ([Text], [QuestionTypeID]) VALUES.(@text, @questionTypeId";

                    command.Parameters.Add("@text", SqlDbType.VarChar, 200).Value = entity.Text;
                    command.Parameters.Add("@questionTypeId", SqlDbType.Int).Value = questionTypeId;

                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();
                    Console.WriteLine("Both records were written to database.");
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
