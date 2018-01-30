using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Entities;

namespace ClassLibrary.Business
{
    public class QuestionRepository : IGenericRepository<Questions>
    {
        public QuestionRepository(List<Questions> QuestionList)
        {
            this.QuestionList = QuestionList;
        }

        private readonly List<Questions> QuestionList;

        public void CreateQuestion(Questions question)
        {
            QuestionList.Add(question);
        }

        public void DeleteQuestion(int id)
        {
            QuestionList.Remove(SearchId(id));
        }

        public List<Questions> ReadQuestion(string filter)
        {
            if (filter.Equals(string.Empty))
            {
                return QuestionList;
            }
            else
            {
                return QuestionList.Where(e => e.Text.Contains(filter)).ToList();
            }
        }

        public List<Questions> UpdateQuestion(int id, Questions question)
        {
            QuestionList[QuestionList.FindIndex(e => e.Id == id)] = question;
            return QuestionList;
        }

        public Questions SearchId(int id)
        {
            return QuestionList.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
