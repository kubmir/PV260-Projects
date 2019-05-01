using BenchmarkDotNet.Attributes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace XmlBenchmark
{
    public class FilterInvalidXmlCharactersBenchmark
    {
        private string xmlContent;
        private readonly string file = @"test.xml";

        public FilterInvalidXmlCharactersBenchmark(string content)
        {
            xmlContent = content;
        }

        public FilterInvalidXmlCharactersBenchmark() : this("")
        { }

        [GlobalSetup]
        public void Setup()
        {
            xmlContent = File.ReadAllText(file);
        }

        [Benchmark]
        public string FilterInvalidXmlCharactersUsingRegex()
        {
            return Regex.Replace(
                xmlContent,
                @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]",
                string.Empty
            );
        }

        [Benchmark]
        public string FilterInvalidXmlCharactersUsingLinq()
        {
            var validXmlChars = xmlContent
                .Where(character => XmlConvert.IsXmlChar(character))
                .ToArray();

            return new string(validXmlChars);
        }

        [Benchmark]
        public string FilterInvalidXmlCharactersUsingStringBuilder()
        {
            StringBuilder filteredContent = new StringBuilder();

            foreach (var character in xmlContent)
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
