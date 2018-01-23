using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Entities;

namespace ClassLibrary.Interface
{
    public class ItemRepository : IGenericRepository<Item>
    {
        private readonly List<Item> ItemList;

        public ItemRepository(List<Item> ItemList)
        {
            this.ItemList = ItemList;
        }

        public void Create(Item item)
        {
            ItemList.Add(item);
        }

        public void Delete(int id)
        {
            ItemList[id].IsArchived = true;
        }

        public List<Item> Read(string filter)
        {
            switch (filter)
            {
                case "status":
                    return ItemList.OrderByDescending(e => e.StatusId).ToList();

                case "range":
                    return ItemList.OrderByDescending(e => e.Range).ToList();

                case "title":
                    return ItemList.OrderByDescending(e => e.Title).ToList();

                default:
                    return ItemList.OrderByDescending(e => e.Priority).ToList();
            }
        }

        public void Update(string filter, int idtomodify, string newdata)
        {
            Item item = ItemList[idtomodify];
            int number;
            DateTime duedate;
            switch (filter)
            {
                case "title":
                    if (Convert.ToInt32(item.StatusId) <= 3)
                    {
                        item.Title = newdata;
                        item.StatusId = 0;
                    }
                    break;
                case "description":
                    
                    if (Convert.ToInt32(item.StatusId) <= 3)
                    {
                        item.Description = newdata;
                        item.StatusId = 0;
                    }
                    //6442286006
                    break;
                case "duedate":
                    duedate = Convert.ToDateTime(newdata);
                    if (duedate >= item.DueDate)
                    {
                        item.DueDate = duedate;
                        item.Range = item.DueDate.Subtract(item.CreateDate);
                    }
                    break;
                case "priority":
                    number = Convert.ToInt32(newdata);
                    if (number >= 1)
                    {
                        item.Priority = number;
                    }
                    break;
                case "status":
                    int stat = Convert.ToInt32(item.StatusId);
                    if (stat == 0)
                    {
                        item.StatusId++;
                    }
                    else if (stat == 2 || stat == 3)
                    {
                        Console.WriteLine("Do you want to cancel it");
                        bool option = Convert.ToBoolean(Console.ReadLine());
                        if (option == true)
                        {
                            item.StatusId = Status.Cancel;
                        }
                        else
                        {
                            item.StatusId++;
                        }
                        
                    }
                        
                    break;
            }

            item.ModifyDate = DateTime.Now;
        }
    }
}
