using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class OptionADO : IOptionRepository
    {
        public void Add(OptionDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "INSERT INTO [dbo].[Options] ([Text]) VALUES (@Text)";

            SqlParameter parameter = new SqlParameter("@Text", entity.Text);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) inserted", rows);
        }

        public int CountOption()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT COUNT [OptionId] FROM [SurveyDB].[dbo].[Options]";

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
            string commandText = "DELETE FROM [dbo].[Options] WHERE [OptionId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row(s) deleted", rows);
        }

        public List<OptionDTO> GetAll()
        {
            List<OptionDTO> results = new List<OptionDTO>();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Options]";

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new OptionDTO
                        {
                            OptionId = (int)reader["OptionId"],
                            Text = reader["Text"].ToString()
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

        public OptionDTO GetById(int entityId)
        {
            OptionDTO item = new OptionDTO();

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT * FROM [dbo].[Options] WHERE [OptionId] = @entityId";

            SqlParameter parameter = new SqlParameter("@entityId", entityId);

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text, parameter))
            {
                if (reader.HasRows)
                {
                    item = new OptionDTO
                    {
                        OptionId = (int)reader["OptionId"],
                        Text = reader["Text"].ToString(),
                    };
                }
                else
                {
                    Console.WriteLine("Id not found");
                }

                return item;
            }
        }

        public void Update(OptionDTO entity)
        {
            int entityId = entity.OptionId;
            string text = "Male";
            SqlParameter[] parameter = new SqlParameter[2];

            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "UPDATE [dbo].[Options] SET [Text] = @Text WHERE [OptionId] = @entityId";

            parameter[0] = new SqlParameter("@Text", text);
            parameter[1] = new SqlParameter("@entityId", entityId); 

            int count = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("Items modified: {0}", count);
        }
        
    }
}
