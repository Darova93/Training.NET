using DataAccess.Implementation;
using DataAccess.Implementation.ADO;
using DataAccess.ImplementationOffline;
using DataAccess.Interfaces;
using DataAccess.InterfacesOffline;
using System;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuestionTypeRepository questionTypeRepository = new QuestionTypeADO();
            IQuestionRepository questionRepository = new QuestionADO();
            IOptionRepository optionRepository = new OptionADO();
            IAnswerRepository answerRepository = new AnswerADO();

            IQuestionRepositoryOff questionRepositoryOff = new QuestionADOOff();

            //DEMO 1
            //ConnectionStringHelper.OpenSqlConnectionInCode();

            //ADD QUESTION
            //questionTypeRepository.Add(new QuestionTypeDTO { Description = "Dumb" });

            //DELETE QUESTION
            //questionTypeRepository.Delete(4);

            //COUNT ROWS
            //Console.WriteLine(questionTypeRepository.CountQuestionType());

            //GET ALL QUESTIONTYPES
            //var results = questionTypeRepository.GetAll();
            //foreach(QuestionTypeDTO item in results)
            //{
            //    //Console.WriteLine($"{item.QuestionTypeId} {item.Description}");
            //    Console.WriteLine("{0} {1}", item.QuestionTypeId, item.Description);
            //}

            //GET ALL OPTIONS
            //var results = optionRepository.GetAll();
            //foreach (OptionDTO item in results)
            //{
            //    Console.WriteLine("{0} {1}", item.OptionId, item.Text);
            //}

            //GET ALL QUESTIONS
            //var results = questionRepository.GetAll();
            //foreach (QuestionDTO item in results)
            //{
            //    Console.WriteLine("{0} {1} {2}", item.QuestionId, item.Text, item.QuestionTypeId);
            //}

            //GET ALL ANSWERS
            //var results = answerRepository.GetAll();
            //foreach (AnswerDTO item in results)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", item.AnswerId, item.QuestionId, item.OpenValue, item.OptionId);
            //}



            Console.ReadKey();
        }
    }
}