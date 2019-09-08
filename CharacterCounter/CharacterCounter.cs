using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterCounter
{ 
    public class CharacterCounter : ICharacterCounter
    {

        public List<CharacterCount> CountingChar(string characters)
        {
            var charArray = characters.ToCharArray();
            var distinctChar = charArray.Distinct().Where(i => !char.IsWhiteSpace(i));

            List<CharacterCount> charCount = new List<CharacterCount>();

            foreach (var n in distinctChar)
            {
                charCount.Add(new CharacterCount() { Character = n, Count = charArray.Count(i => i == n) });
            }

            return charCount;
        }
    }
}
