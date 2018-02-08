using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class SPOptionADO : IOptionRepository
    {
        public void Add(OptionDTO entity)
        {
            throw new NotImplementedException();
        }

        public int CountOption()
        {
            throw new NotImplementedException();
        }
            

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<OptionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OptionDTO GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(OptionDTO entity)
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
            SqlDataReader reader = command.ExecuteReader();

            connstringobj.Open();

            while (reader.Read())
            {
                optionlist.Add(new OptionDTO
                {
                    OptionId = (int)reader["QuestionId"],
                    Text = reader["Option"].ToString()
                });
            }

            connstringobj.Close();
            return optionlist;
        }

    }
}
