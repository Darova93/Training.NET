using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassLibrary.Interface;
using ClassLibrary.Entities;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
                List<Item> list = new List<Item>();
                ItemRepository itemrepository = new ItemRepository(list);

                for (int i = 1; i <= 10; i++)
                {
                    itemrepository.Create(
                        new Item(i
                        , "Nombre " + i.ToString()
                        , "Descripcion " + i.ToString()
                        , DateTime.Now));
                }
                Assert.AreEqual(10, list.Count);

        }
    }
}
