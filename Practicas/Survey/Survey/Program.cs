using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary.Business;
using ClassLibrary.Entities;

namespace Survey
{
    class Program
    {
        static void Main(string[] args)
        {
            int idQuest = 0, deleteid;
            string questiontext, requiretext, menu;
            bool requirement, exit = false;
            QuestionType type;
            List<Questions> questionList = new List<Questions>();
            StreamWriter sw = new StreamWriter("C:\\Users\\Academia\\Documents\\david_rodriguezv\\Practicas\\Survey\\Test.txt");
            QuestionRepository questionRepository = new QuestionRepository(questionList);

            do
            {
                Console.Clear();
                Console.WriteLine("Menu \n 1. Add question \n 2. Delete question \n 3. Take quizz \n 4. Exit");
                menu = Console.ReadLine();
                switch (menu)   
                {
                    case "1":
                        Console.WriteLine("Type the question:");
                        questiontext = Console.ReadLine();
                        sw.Write(questiontext);
                        Console.WriteLine("Is your question required?");
                        requiretext = Console.ReadLine();
                        sw.WriteLine(requiretext);
                        if (requiretext == "yes")
                        {
                            requirement = true;
                        }
                        else
                        {
                            requirement = false;
                        }
                        Console.WriteLine("What type of question it it?");
                        type = 0;
                        questionRepository.CreateQuestion(new Questions(idQuest, questiontext, requirement, type));
                        idQuest++;
                        break;
                    case "2":
                        Console.WriteLine("Which id do you want to delete?");
                        deleteid = Convert.ToInt32(Console.ReadLine());
                        questionRepository.DeleteQuestion(deleteid);
                        break;
                    case "3":
                        foreach (Questions question in questionList)
                        {
                            Console.WriteLine(question.Id + " " + question.Text + " " + question.Isrequired + " " + question.QuestionType);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Select a valid option");
                        Console.ReadKey();
                        break;

                }

            } while (exit == false);

            sw.Close();
        }
    }
}
