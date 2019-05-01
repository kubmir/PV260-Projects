using System.Xml;
using System.Xml.Serialization;

namespace XmlLoader.Deserializers
{
    public class XmlDeserializer : IDeserializer
    {
        public T Deserialize<T>(XmlDocument document)
        {
            XmlReader reader = new XmlNodeReader(document);
            var serializer = new XmlSerializer(typeof(T));

            var deserializedObject = (T)serializer.Deserialize(reader);

            return deserializedObject;
        }
    }
}
