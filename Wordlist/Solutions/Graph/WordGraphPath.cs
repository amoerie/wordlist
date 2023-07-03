using System;

namespace Wordlist.Solutions.Graph;

public class WordGraphPath
{
    private readonly WordGraph _firstWordGraph;
    private readonly WordGraph _secondWordGraph;
    private readonly int _firstWordLength;
    private readonly int _secondWordLength;
    
    public WordGraphPath(WordGraph firstWordGraph, int firstWordLength, WordGraph secondWordGraph, int secondWordLength)
    {
        _firstWordGraph = firstWordGraph;
        _firstWordLength = firstWordLength;
        _secondWordGraph = secondWordGraph;
        _secondWordLength = secondWordLength;
    }

    public bool Contains(ReadOnlySpan<char> word)
    {
        WordGraph? firstWordEnd = _firstWordGraph;
        WordGraph? secondWordEnd = _secondWordGraph;
        var characterIndex = 0;
        while (characterIndex < word.Length
               && characterIndex < _firstWordLength
               && (firstWordEnd = firstWordEnd.GetNode(word[characterIndex])) != null)
        {
            characterIndex++;
        }
    
        if (characterIndex < _firstWordLength)
            return false;
    
        while (characterIndex < word.Length
               && (characterIndex - _firstWordLength) < _secondWordLength
               && (secondWordEnd = secondWordEnd.GetNode(word[characterIndex])) != null)
        {
            characterIndex++;
        }
    
        return characterIndex >= word.Length;
    }
}
