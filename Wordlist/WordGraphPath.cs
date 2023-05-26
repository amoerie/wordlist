using System.Text;

namespace Wordlist;

public class WordGraphPath
{
    private readonly WordGraph _firstWordGraph;
    private readonly WordGraph _secondWordGraph;
    private readonly StringBuilder _stringBuilder;

    public WordGraphPath(WordGraph firstWordGraph, WordGraph secondWordGraph)
    {
        _firstWordGraph = firstWordGraph;
        _secondWordGraph = secondWordGraph;
        _stringBuilder = new StringBuilder();
    }

    public string Walk(string word, int requestedLength)
    {
        var firstWordEnd = _firstWordGraph;
        var secondWordEnd = _secondWordGraph;
        var firstWordLength = _firstWordGraph.Length;
        var secondWordLength = _secondWordGraph.Length;
        var characterIndex = 0;
        while (characterIndex < word.Length
               && characterIndex < firstWordLength
               && firstWordEnd.Nodes.TryGetValue(word[characterIndex], out firstWordEnd))
        {
            characterIndex++;
        }

        if (characterIndex < firstWordLength)
            return null;

        while (characterIndex < word.Length
               && (characterIndex - firstWordLength) < secondWordLength
               && secondWordEnd.Nodes.TryGetValue(word[characterIndex], out secondWordEnd))
        {
            characterIndex++;
        }

        if (characterIndex < requestedLength)
            return null;

        _stringBuilder.Append(word.Substring(0, firstWordLength));
        _stringBuilder.Append(" + ");
        _stringBuilder.Append(word.Substring(firstWordLength, secondWordLength));
        _stringBuilder.Append(" => ");
        _stringBuilder.Append(word);
        var combination = _stringBuilder.ToString();
        _stringBuilder.Clear();
        return combination;
    }
}
