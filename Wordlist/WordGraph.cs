using System.Collections.Generic;

namespace Wordlist;

public class WordGraph
{
    public char Char { get; }
    public int Length { get; set; }
    public IDictionary<char, WordGraph> Nodes;

    public WordGraph(int length, char character)
    {
        Length = length;
        Char = character;
        Nodes = new Dictionary<char, WordGraph>();
    }

    public WordGraph GetOrCreateNode(char character)
    {
        if (!Nodes.TryGetValue(character, out WordGraph wordGraph))
        {
            Nodes[character] = wordGraph = new WordGraph(Length - 1, character);
        }

        return wordGraph;
    }

    public override string ToString() => Char.ToString();
}
