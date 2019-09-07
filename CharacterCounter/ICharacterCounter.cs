using System;
using System.Collections.Generic;

namespace CharacterCounter
{
    public interface ICharacterCounter
    {
        List<CharacterCount> CountingChar(string characters);

    }
}
