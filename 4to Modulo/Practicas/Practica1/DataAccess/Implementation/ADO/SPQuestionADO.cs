using DataAccess.Implementation.Helpers;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation
{
    public class SPQuestionADO : IQuestionRepository
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
            throw new NotImplementedException();
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
    }
}
