using System.Collections.Generic;
using DataAccess.DTO;
using DataAccess.InterfacesOffline;
using DataAccess.Implementation.Helpers;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DataAccess.ImplementationOffline
{
    public class QuestionADOOff : IQuestionRepositoryOff
    {
        public void Add(QuestionDTO entity)
        {
            int rowCount = 0;

            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string insertCommandText = "INSERT INTO [dbo].[Question] ([Text],[QuestionTypeId]) VALUES (@Text, @QuestionTypeId)";

            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand insertCommand = new SqlCommand(insertCommandText, connStringObj);
            
            insertCommand.Parameters.Add("@Text", SqlDbType.VarChar, 50).Value = entity.Text;
            insertCommand.Parameters.Add("@QuestionTypeId", SqlDbType.Int).Value = entity.QuestionTypeId;

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                InsertCommand = insertCommand
            };

            connStringObj.Open();
            rowCount = adapter.InsertCommand.ExecuteNonQuery();
            connStringObj.Close();

            Console.WriteLine("Inserted {0} rows", rowCount);
        }

        public int CountQuestion()
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionDTO> GetAll()
        {
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [Survey].[dbo].[Question]";
            List<QuestionDTO> results = new List<QuestionDTO>();
            DataSet dsQuestionType = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(commandText, connString);

            using(SqlConnection conn = new SqlConnection(connString))
            {
                adapter.Fill(dsQuestionType, "Question");
            }



        }

        public QuestionDTO GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
