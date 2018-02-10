using DataAccess.Implementation.ADO;
using DataAccessEF;
using DataAccessEF.Entities;
using DataAccessEF.Implementation;
using DTO.DTO;
using Interfaces.Interfaces;
using System;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IQuestionTypeRepository questionTypeRepository = new QuestionTypeADO();
            //IQuestionRepository questionRepository = new QuestionADO();
            //IOptionRepository optionRepository = new OptionADO();
            //IAnswerRepository answerRepository = new AnswerADO();

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

            //List<QuestionDTO> results = new List<QuestionDTO>();
            //results = questionRepositoryOff.GetAll();
            //foreach(QuestionDTO question in results)
            //{
            //    Console.WriteLine("{0} {1} {2}", question.QuestionId, question.Text, question.QuestionTypeId);
            //}

            //SPOptionADO spado = new SPOptionADO();
            //spado.OptionsByQuestionId(4);

            /////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////****ENTITY FRAMEWORK****///////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////

            //using(var context = new DemoContext())
            //{
            //    context.QuestionTypes.Add(new QuestionType { Description = "Si/No" });
            //    context.QuestionTypes.Add(new QuestionType { Description = "Abierta" });
            //    context.QuestionTypes.Add(new QuestionType { Description = "Opcion Multiple" });
            //    context.QuestionTypes.Add(new QuestionType { Description = "Test Question" });
            //    context.SaveChanges();
            //}

            //using (var context = new DemoContext())
            //{
            //    context.QuestionTypes.Add(new QuestionType { Description = "Para que corra" });
            //    context.SaveChanges();
            //}

            IQuestionTypeRepository questionTypeRepository = new QuestionTypeEF();
            IQuestionRepository questionRepository = new QuestionEF();
            IOptionRepository optionRepository = new OptionEF();

            //questionTypeRepository.Add(new QuestionTypeDTO { Description = "Paquecorra", CreateDate = DateTime.Now });
            //questionTypeRepository.Update(new QuestionTypeDTO { Description = "Ya corrio!", QuestionTypeId = 9 });
            //questionTypeRepository.Delete(8);

            //questionRepository.Add(new QuestionDTO { Text = "Que tal?", QuestionTypeId = 1, IsActive = false, IsRequired = true });
            //questionRepository.Update(new QuestionDTO { QuestionId = 9, Text = "Donde llueve cafe?" });
            //questionRepository.Delete(11);

            //optionRepository.Add(new OptionDTO { Text = "En el campo" });
            //optionRepository.Update(new OptionDTO { OptionId = 9, Text = "Mexico" });

            var question = questionRepository.GetById(1);
            var options = question.Option;
            
            Console.WriteLine($"{question.Text} \n {}");

            //Console.WriteLine("Question Types");
            //var resultqtype = questionTypeRepository.GetAll();
            //foreach(QuestionTypeDTO qtype in resultqtype)
            //{
            //    Console.WriteLine($"{qtype.QuestionTypeId} { qtype.Description}");
            //}

            //Console.WriteLine("\n Questions");
            //var resultqu = questionRepository.GetAll();
            //foreach (QuestionDTO qtype in resultqu)
            //{
            //    Console.WriteLine($"{qtype.QuestionId} {qtype.Text} {qtype.QuestionTypeId}");
            //}

            //Console.WriteLine("\n Options");
            //var resultop = optionRepository.GetAll();
            //foreach (OptionDTO qtype in resultop)
            //{
            //    Console.WriteLine($"{qtype.OptionId} { qtype.Text}");
            //}

            Console.ReadKey();
        }
    }
}