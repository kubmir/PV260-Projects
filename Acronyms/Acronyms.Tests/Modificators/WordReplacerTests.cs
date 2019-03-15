using NUnit.Framework;
using System.Collections.Generic;

namespace Acronyms.Tests
{
    [TestFixture]
    class WordReplacerTests
    {
        [Test]
        public void ModifyWords_ReplaceAndWithAndSymbol() 
        {
            //Arrange
            var replacer = new WordReplacer(new Dictionary<string, string>() {
                { "and", "&"}
            });
            var initialWords = new string[] { "Word", "and", "And", "Second" };
            var expectedWords = new string[] { "Word", "&", "&", "Second" };

            //Act
            var result = replacer.ModifyWords(initialWords);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedWords));
        }
    }
}
