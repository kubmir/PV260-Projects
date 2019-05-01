using FakeItEasy;
using Newtonsoft.Json;
using NUnit.Framework;
using XmlLoader;
using XmlLoader.Deserializers;
using XmlLoader.Loaders;
using XmlLoader.Models;

namespace Tests
{
    public class XmlLoaderTests
    {
        private IFileLoader fileLoader;
        private readonly string path = "/test";
        private string author = "Ralls, Kim";
        private string title = "Midnight Rain";
        private string genre = "Fantasy";
        private string price = "5.95";
        private string publishDate = "2000 - 12 - 16";
        private string description = "A former architect";

        [SetUp]
        public void Setup()
        {
            var book = $@"   
                <book>
                    <author>{author}</author>
                    <title>{title}</title>
                    <genre>{genre}</genre>
                    <price>{price}</price>
                    <publish_date>{publishDate}</publish_date>
                    <description>{description}</description>
                </book>
            ";
            var fileContent = "<catalog>" + book + "</catalog>";

            fileLoader = A.Fake<IFileLoader>();
            A.CallTo(() => fileLoader.LoadFile(path)).Returns<string>(fileContent);
        }

        [Test]
        public void LoadXmlWithoutInvalidCharacters_ReturnDeserializedCatalog_OnValidFile()
        {
            var expectedResult = new Catalog
            {
                Books = new Book[]
                {
                    new Book()
                    {
                        Author = author,
                        Description = description,
                        Genre = genre,
                        Price = price,
                        PublishDate = publishDate,
                        Title = title
                    }
                }
            };

            var xmlLoader = new XmlFileLoader(path, new XmlDeserializer(), fileLoader);

            var actualResult = xmlLoader.LoadXmlWithoutInvalidCharacters<Catalog>();

            var actualJson = JsonConvert.SerializeObject(actualResult);
            var expectedJson = JsonConvert.SerializeObject(expectedResult);

            Assert.That(actualJson, Is.EqualTo(expectedJson));
        }
    }
}