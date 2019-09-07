using System;
namespace CharacterCounter
{
    public interface ICharacterCount
    {
        char Character { get; set; }
        int Count { get; set; }
    }
}
