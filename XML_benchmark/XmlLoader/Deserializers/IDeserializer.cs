using System.Xml;

namespace XmlLoader.Deserializers
{
    public interface IDeserializer
    {
        T Deserialize<T>(XmlDocument document);
    }
}
