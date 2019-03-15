using System.Collections.Generic;

namespace Acronyms
{
    public class WordReplacer : IModificator
    {
        private readonly Dictionary<string, string> _replacements;

        public WordReplacer(Dictionary<string, string> replacements)
        {
            _replacements = replacements;
        }

        public string[] ModifyWords(string[] words)
        {
            var modifiedWords = new string[words.Length];

            for(int i = 0; i < words.Length; i++)
            {
                var word = words[i].ToLower();

                if (_replacements.ContainsKey(word))
                {
                    modifiedWords[i] = _replacements[word];
                }
                else
                {
                    modifiedWords[i] = words[i];
                }
            }

            return modifiedWords;
        }
    }
}
