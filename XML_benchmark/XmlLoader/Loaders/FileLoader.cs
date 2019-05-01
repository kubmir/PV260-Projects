using System.IO;

namespace XmlLoader.Loaders 
{
    public class FileLoader : IFileLoader
    {
        public string LoadFile(string pathToFile)
            => File.ReadAllText(pathToFile);
    }
}
