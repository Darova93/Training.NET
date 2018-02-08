using System.Collections.Generic;
using DataAccess.DTO;
using DataAccess.Interfaces;
using DataAccess.Implementation.Helpers;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DataAccess.ImplementationOffline
{
    public class QuestionADOOff : IQuestionRepository
    {
        public void Add(QuestionDTO entity)
        {
            int rowCount = 0;
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string insertCommandText = "INSERT INTO [dbo].[Question] ([Text], [QuestionTypeID]) VALUES (@text, @questionTypeId)";

            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand insertCommand = new SqlCommand(insertCommandText,
                connStringObj);

            insertCommand.Parameters.Add("@text", SqlDbType.VarChar, 200).Value = entity.Text;
            insertCommand.Parameters.Add("@questionTypeId", SqlDbType.Int).Value = entity.QuestionTypeId;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            // adapter.InsertCommand = insertCommand;

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                InsertCommand = insertCommand
            };
                        
            connStringObj.Open();
            rowCount = adapter.InsertCommand.ExecuteNonQuery();
            connStringObj.Close();

            Console.WriteLine("Inserted {0} record(s)", rowCount);
        }

        public int CountQuestion()
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteQuestion", connStringObj);

            command.Parameters.Add("QuestionId", SqlDbType.Int).Value = entityId;
            command.CommandType = CommandType.StoredProcedure;
            connStringObj.Open();

            int rows = command.ExecuteNonQuery();

            Console.WriteLine("{0} row(s) deleted", rows);
        }

        public List<QuestionDTO> GetAll()
        {
            
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [Survey].[dbo].[Questions]";

            List<QuestionDTO> results = new List<QuestionDTO>();
            DataSet dsQuestionTypes = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(commandText, connString);

            using (SqlConnection connection = new SqlConnection(connString))
            {
                adapter.Fill(dsQuestionTypes, "Questions");
                // adapter.Fill(dsQuestionTypes, "Question");
            }

            int rowCount = dsQuestionTypes.Tables["Questions"].Rows.Count;

            Console.WriteLine("Row count from DataSet: {0}", rowCount);

            return results;
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
