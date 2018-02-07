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
            throw new NotImplementedException();
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
            List<QuestionDTO> questionlist = new List<QuestionDTO>();
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            SqlConnection connStringobj = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("dbo.uspGetAllQuestions", connStringobj);

            command.CommandType = CommandType.StoredProcedure;
            connStringobj.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                questionlist.Add(new QuestionDTO
                {
                    QuestionId = (int)reader["QuestionId"],
                    Text = reader["Text"].ToString(),
                    QuestionTypeId = (int)reader["QuestionTypeId"]
                });
            }

            return questionlist;
        }

        public QuestionDTO GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }

        public List<OptionDTO> OptionsByQuestionId(int entityId)
        {
            List<OptionDTO> optionlist = new List<OptionDTO>();
            string connstring = ConnectionStringHelper.GetConnStringFromConfigFile();
            SqlConnection connstringobj = new SqlConnection(connstring);

            SqlCommand command = new SqlCommand("dbo.uspGetOptionsbyQuestionId", connstringobj);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = entityId;

            connstringobj.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                optionlist.Add(new OptionDTO
                {
                    OptionId = (int)reader["QuestionId"],
                    Text = reader["Option"].ToString()
                });
            }

            foreach (OptionDTO question in optionlist)
            {
                Console.WriteLine("{0} {1}", question.OptionId, question.Text);
            }
            
            return optionlist;
        }

    }
}
