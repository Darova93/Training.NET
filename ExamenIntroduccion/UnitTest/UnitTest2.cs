using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassLibrary.Interface;
using ClassLibrary.Entities;

namespace UnitTest
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Item> list = new List<Item>();
            List<Item> notarchived = new List<Item>();
            ItemRepository itemrepository = new ItemRepository(list);

            for (int i = 1; i <= 10; i++)
            {
                itemrepository.Create(
                    new Item(i
                    , "Nombre " + i.ToString()
                    , "Descripcion " + i.ToString()
                    , DateTime.Now));
            }

            itemrepository.Delete(3);
            itemrepository.Delete(4);

            foreach (Item item in list)
            {
                if (item.IsArchived == false)
                {
                    notarchived.Add(item);
                }
            }

            Assert.AreEqual(8, notarchived.Count);

        }
    }
}
