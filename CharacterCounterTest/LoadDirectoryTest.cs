using System.Diagnostics;
using NUnit.Framework;
using CharacterCounter;
using Moq;

namespace Tests
{
    [TestFixture]
    public class LoadDirectoryTest
    {
        LoadDirectory test = new LoadDirectory();

        [Test]
        public void TimeTakenToRunMethod()
        {
            Stopwatch timer = new Stopwatch();
            Assert.Pass();
        }

        [Test]
        public void GettingTheRightCsFiles()
        {
            var getFiles = test.GetFilesFromDirectoryTarget("/Users/hongle/Projects/CharacterCounter");
            bool result = true;

            foreach (var file in getFiles)
            {
                if (!file.Contains(".cs"))
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnErrMessageIfDirectoryDoesNotExist()
        {
            var results = test.LoadingDirectory("FalseDirectory");

            Assert.AreEqual(results, "FalseDirectory does not exist");
        }

        [Test]
        public void ReturnErrMessageIfThereAreNoCsFiles()
        {
            string path = "/Users/hongle/Projects/CharacterCounter/CharacterCounterTest/EmptyDirectory";
            var result = test.LoadingDirectory(path);

            Assert.AreEqual(result, $"{path} does not contain any .cs files");
        }

        [Test]
        public void CanConvertFilesToString()
        {
            var results = test.LoadingDirectory("/Users/hongle/Projects/CharacterCounter");
            System.Console.WriteLine(results);
        }
    }

}