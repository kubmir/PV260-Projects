using System.Xml.Serialization;

namespace XmlLoader.Models
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlElement("book")]
        public Book[] Books { get; set; }

        public override bool Equals(object obj) 
            => base.Equals(obj);

        public override int GetHashCode() 
            => base.GetHashCode();

        public override string ToString() 
            => Books.ToString();
    }
}
