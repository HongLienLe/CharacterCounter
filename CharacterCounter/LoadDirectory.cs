using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CharacterCounter
{
    public class LoadDirectory : ILoadDirectory
    {

        public string LoadingDirectory(string directoryTarget)
        {
            if (!Directory.Exists(directoryTarget))
            {
                return $"{directoryTarget} does not exist";
            }

            var getFiles = GetFilesFromDirectoryTarget(directoryTarget);

            if (getFiles.All(x => string.IsNullOrEmpty(x)))
            {
                return $"{directoryTarget} does not contain any .cs files";
            }

            StringBuilder stringBuilder = new StringBuilder();

             foreach(var file in getFiles)
            {
                var readFile = ReadFiles(file);

                stringBuilder.Append(readFile);
            }

            return stringBuilder.ToString();
        }

        public string[] GetFilesFromDirectoryTarget(string directoryTarget)
        {

            return Directory.GetFiles(directoryTarget, "*.cs", SearchOption.AllDirectories);
        }

        public string ReadFiles(string path)
        {
            StringBuilder stringbuilder = new StringBuilder();

                var lines = File.ReadAllLines(path).ToList();

                foreach (var line in lines)
                {
                    stringbuilder.Append(line);
                }

            return stringbuilder.ToString();
        }
    }
}
