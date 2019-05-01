using System.Xml.Serialization;

namespace XmlLoader.Models
{
    [XmlRoot("book")]
    public class Book
    {
        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("publish_date")]
        public string PublishDate { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Book: {Author}, {Title}, {Price}";
        }
    }
}
