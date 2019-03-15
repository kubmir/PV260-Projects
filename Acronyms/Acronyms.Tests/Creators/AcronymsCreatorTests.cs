using NUnit.Framework;
using System.Collections.Generic;

namespace Acronyms.Tests
{
    [TestFixture]
    public class AcronymsCreatorTests
    {
        [TestCase("Don't repeat yourself", "DRY")]
        [TestCase("Asynchronous Javascript and XML", "AJAX")]
        [TestCase("Complementary metal-oxide semiconductor	", "CMS")]
        [TestCase("Don't", "D")]
        [TestCase("", "")]
        [TestCase(null, "")]
        public void GetAcronymOfSentence_ReturnsCorrectAcronym_WithBaseSentences(string sentence, string acronym)
        {
            //Arrange
            var acronymsCreator = new AcronymsCreator();

            //Act
            var result = acronymsCreator.GetAcronymOfSentence(sentence);

            //Assert
            Assert.That(result, Is.EqualTo(acronym));
        }

        [TestCase("Don't repeat yourself", "DRY")]
        [TestCase("Asynchronous Javascript and XML", "AJAX")]
        [TestCase("Complementary metal-oxide semiconductor	", "CMOS")]
        [TestCase("Don't", "D")]
        [TestCase("", "")]
        [TestCase(null, "")]
        public void GetAcronymOfSentence_ReturnsCorrectAcronym_WithExtendedSeparators(string sentence, string acronym)
        {
            //Arrange
            var separators = new char[] { ' ', '-' };
            var acronymsCreator = new AcronymsCreator(separators);

            //Act
            var result = acronymsCreator.GetAcronymOfSentence(sentence);

            //Assert
            Assert.That(result, Is.EqualTo(acronym));
        }

        [TestCase("Rythm and blues", "R&B")]
        public void GetAcronymOfSentence_ReturnsCorrectAcronym_WithModifier(string sentence, string acronym)
        {
            //Arrange
            var separators = new char[] { ' ', '-' };
            var modifiers = new IModificator[] {
                new WordReplacer(new Dictionary<string, string>() {
                    { "and", "&"}
                })
            };
            var acronymsCreator = new AcronymsCreator(separators, modifiers);

            //Act
            var result = acronymsCreator.GetAcronymOfSentence(sentence);

            //Assert
            Assert.That(result, Is.EqualTo(acronym));
        }
    }
}
