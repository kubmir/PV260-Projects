using System.Text;
using System.Xml;
using XmlLoader.Deserializers;
using XmlLoader.Loaders;

namespace XmlLoader
{
    public class XmlFileLoader
    {
        private XmlDocument LoadedXmlDocument { get; set; }
        private IFileLoader FileLoader { get; set; }
        private string Path { get; set; }
        private IDeserializer Deserializer { get; set; }

        public XmlFileLoader(string pathToFile, IDeserializer deserializer, IFileLoader fileLoader)
        {
            LoadedXmlDocument = new XmlDocument();
            FileLoader = fileLoader;
            Path = pathToFile;
            Deserializer = deserializer;
        }

        public XmlFileLoader(string pathToFile, IDeserializer deserializer) 
            : this(pathToFile, deserializer, new FileLoader())
        { }

        public T LoadXmlWithoutInvalidCharacters<T>()
        {
            var content = FileLoader.LoadFile(Path);

            var correctedXMlString = FilterInvalidXmlCharacters(content);

            LoadedXmlDocument.LoadXml(correctedXMlString);
            
            return Deserializer.Deserialize<T>(LoadedXmlDocument);
        }

        private string FilterInvalidXmlCharacters(string content)
        {
            StringBuilder filteredContent = new StringBuilder();

            foreach (var character in content)
            {
                if (XmlConvert.IsXmlChar(character))
                {
                    filteredContent.Append(character);
                }
            }

            return filteredContent.ToString();
        }
    }
}
