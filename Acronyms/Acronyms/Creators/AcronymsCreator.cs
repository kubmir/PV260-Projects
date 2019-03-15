using System.Collections.Generic;
using System.Linq;

namespace Acronyms
{
    public class AcronymsCreator : IAcronymsCreator
    {
        private readonly char[] _separators;
        private readonly IEnumerable<IModificator> _modifiers;

        public AcronymsCreator(char[] separators, IEnumerable<IModificator> modifiers)
        {
            _separators = separators;
            _modifiers = modifiers;
        }

        public AcronymsCreator(char[] separators) : this(separators, new List<IModificator>())
        { }

        public AcronymsCreator() : this(new char[] { ' ' })
        { }

        public string GetAcronymOfSentence(string sentence)
        {
            if (sentence == "" || sentence == null)
                return "";

            var words = sentence.Split(_separators);

            foreach (var modifier in _modifiers)
            {
                words = modifier.ModifyWords(words);
            }

            return words
                .Select(word => word.First().ToString())
                .Aggregate((first, second) => first + second)
                .ToUpper();
        }
    }
}
