using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Commons;
using academy_demo;

namespace UnitTestProject1
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void When_Process_File_is_Ok()
        {
            string expected = "hey";

            FileManager fileManager = new TextFileManager();

            FileManagerApp app = new FileManagerApp(fileManager);

            string path = @"C:\temp\dummy.txt";
            string content = app.ProcessFile(path);

            Assert.IsNotNull(content);
            Assert.IsTrue(content.Length > 0);
            Assert.AreEqual(expected, content);
        }

        [TestMethod]
        public void When_Process_file_fails()
        {
            Mock<FileManager> fileManager = new Mock<FileManager>();

            fileManager.Setup(x => x.CanRead("asasasdasd")).Returns(false);
            fileManager.Setup(x => x.CanRead("zxczxc")).Returns(true);

            FileManagerApp app = new FileManagerApp(fileManager.Object);

            string path = @"C:\temp\dummyfile";
            string content = app.ProcessFile(path);

            Assert.IsNull(content);
        }

        [TestMethod]
        [ExpectedException(typeof(FileManagerException))]
        public void When_Exception()
        {
            FileManager fileManager = new TextFileManager();

            FileManagerApp app = new FileManagerApp(fileManager);

            string path = @"C:\Users\Academia\Documents\david_rodriguezv\2do Modulo\Practicas\academy_demo\bin\Debug\dummyfile";
            string content = app.ProcessFile(path);

            Assert.IsNotNull(content);
            Assert.IsTrue(content.Length > 0);
        }

    }
}
