using NUnit.Framework;
using XmlBenchmark;

namespace Tests
{
    public class FilterInvalidXmlCharactersTests
    {
        [TestCase("a \x01 b", "a  b")]
        [TestCase("\x01\x01\x01", "")]
        [TestCase("\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009", "\u0009")]
        [TestCase("\u0001 valid \u0002 text \u0003\u0004\u0005\u0006\u0007\u0008\u0009", " valid  text \u0009")]
        [TestCase("\u000B", "")]
        [TestCase("\u000C", "")]
        [TestCase("\u000E\u0011\u0019\u001C\u001E\u001F", "")]
        public void FilterInvalidXmlCharactersUsingRegex_ReturnsValidCharacters_WithInvalidInput(string input, string output)
        {
            //Arrange
            var filter = new FilterInvalidXmlCharactersBenchmark(input);

            //Act
            var result = filter.FilterInvalidXmlCharactersUsingRegex();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase("a \x01 b", "a  b")]
        [TestCase("\x01\x01\x01", "")]
        [TestCase("\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009", "\u0009")]
        [TestCase("\u0001 valid \u0002 text \u0003\u0004\u0005\u0006\u0007\u0008\u0009", " valid  text \u0009")]
        [TestCase("\u000B", "")]
        [TestCase("\u000C", "")]
        [TestCase("\u000E\u0011\u0019\u001C\u001E\u001F", "")]
        public void FilterInvalidXmlCharactersUsingLinq_ReturnsValidCharacters_WithInvalidInput(string input, string output)
        {
            //Arrange
            var filter = new FilterInvalidXmlCharactersBenchmark(input);

            //Act
            var result = filter.FilterInvalidXmlCharactersUsingLinq();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase("a \x01 b", "a  b")]
        [TestCase("\x01\x01\x01", "")]
        [TestCase("\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009", "\u0009")]
        [TestCase("\u0001 valid \u0002 text \u0003\u0004\u0005\u0006\u0007\u0008\u0009", " valid  text \u0009")]
        [TestCase("\u000B", "")]
        [TestCase("\u000C", "")]
        [TestCase("\u000E\u0011\u0019\u001C\u001E\u001F", "")]
        public void FilterInvalidXmlCharactersUsingStringBuilder_ReturnsValidCharacters_WithInvalidInput(string input, string output)
        {
            //Arrange
            var filter = new FilterInvalidXmlCharactersBenchmark(input);

            //Act
            var result = filter.FilterInvalidXmlCharactersUsingStringBuilder();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }
    }
}