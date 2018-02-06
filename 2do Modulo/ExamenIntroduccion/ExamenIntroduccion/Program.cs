using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary.Interface;
using ClassLibrary.Entities;

namespace ExamenIntroduccion
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemID = 0, tagID = 0, modifyid, tagassigned;
            string menu, description, title, modifyfield, newdata;
            bool global, exit = false;
            List<Item> itemList = new List<Item>();
            List<Tag> tagList = new List<Tag>();
            ItemRepository itemRepository = new ItemRepository(itemList);
            TagRepository tagRepository = new TagRepository(tagList);
            StreamWriter sw = new StreamWriter("C:\\Users\\Academia\\Documents\\David Rodriguez\\ExamenIntroduccion\\Test.txt");

            do
            {
                Console.Clear();
                Console.WriteLine("Menu \n 1. Create Task \n 2. Modify Task \n 3. Archive Task \n 4. View Tasks \n 5. Create Tag \n 6. Delete Tag \n 7. View Tags \n 8. Assign Tag \n 9. Exit");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.WriteLine("Task Title:");
                        title = Console.ReadLine();
                        Console.WriteLine("Type the description");
                        description = Console.ReadLine();
                        itemRepository.Create(new Item(itemID, title, description, DateTime.Now));
                        itemID++;
                        break;

                    case "2":
                        Console.WriteLine("Which id do you want to modify?");
                        modifyid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("What are you modifying?");
                        modifyfield = Console.ReadLine();
                        Console.WriteLine("Enter new data");
                        newdata = Console.ReadLine();
                        itemRepository.Update(modifyfield, modifyid, newdata);
                        break;

                    case "3":
                        Console.WriteLine("Which id do you want to archive");
                        modifyid = Convert.ToInt32(Console.ReadLine());
                        itemRepository.Delete(modifyid);
                        break;

                    case "4":
                        foreach (Item item in itemList)
                        {
                            if (item.IsArchived == false)
                            {
                                Console.WriteLine(item.Id + " " + item.Title + " " + item.Description, " " + item.CreateDate + " " + item.ModifyDate + " " + item.DueDate + " " + item.Priority + " " + item.StatusId);
                            }
                        }
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("What is the tag name");
                        title = Console.ReadLine();
                        Console.WriteLine("Is your tag global?");
                        global = Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("What is your user id");
                        modifyid = Convert.ToInt32(Console.ReadLine());
                        tagRepository.Create(new Tag(tagID, title, global, modifyid));
                        tagID++;
                        break;

                    case "6":
                        Console.WriteLine("Type the id of the tag you want to delete");
                        modifyid = Convert.ToInt32(Console.ReadLine());
                        tagRepository.Delete(modifyid);
                        break;

                    case "7":
                        foreach (Tag tag in tagList)
                        {
                            Console.WriteLine(tag.Id+ " " + tag.Name + " " + tag.IsGlobal, " " + tag.UserId + " " + tag.Tasks);
                        }
                        Console.ReadKey();
                        break;

                    case "8":
                        Console.WriteLine("Type the task id");
                        modifyid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Type the id of the tag you want to assign");
                        tagassigned = Convert.ToInt32(Console.ReadLine());
                        tagRepository.AssignTag(new ItemTags(modifyid, tagassigned));
                        tagList[tagassigned].Tasks++;
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Select a valid option");
                        Console.ReadKey();
                        break;

                }

            } while (exit == false);

            foreach (Item item in itemList)
            {
                sw.WriteLine(item.Id + " " + item.Title + " " + item.Description, " " + item.CreateDate + " " + item.ModifyDate + " " + item.DueDate + " " + item.Priority + " " + item.StatusId);
            }
            foreach (Tag tag in tagList)
            {
                sw.WriteLine(tag.Id + " " + tag.Name + " " + tag.IsGlobal, " " + tag.UserId + " " + tag.Tasks);
            }

            sw.Close();
        }
    }
}
