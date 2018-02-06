using DataAccess.DTO;
using DataAccess.Implementation.ADO;
using DataAccess.Interfaces;
using System;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuestionTypeRepository questionTypeRepository = new QuestionTypeADO();

            //DEMO 1
            //ConnectionStringHelper.OpenSqlConnectionInCode();

            //ADD QUESTION
            //questionTypeRepository.Add(new QuestionTypeDTO { Description = "Dumb" });

            //DELETE QUESTION
            //questionTypeRepository.Delete(4);
            
            //COUNT ROWS
            //Console.WriteLine(questionTypeRepository.CountQuestionType());

            //GET ALL
            var results = questionTypeRepository.GetAll();
            foreach(QuestionTypeDTO item in results)
            {
                //Console.WriteLine($"{item.QuestionTypeId} {item.Description}");
                Console.WriteLine("{0} {1}", item.QuestionTypeId, item.Description);
            }

            Console.ReadKey();
        }
    }
}