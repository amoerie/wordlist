using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Wordlist.Solutions.Graph;

public static class GraphCombinationsFinder
{
    private static readonly StringBuilder StringBuilder = new StringBuilder(64);

    public static Func<List<string>> Find(string[] words, int requestedLength)
    {
        // Requested length = 8? We'll only keep of words of length 2-6 
        var wordGraphsPerLength = new WordGraph[requestedLength - 3];
        for (int i = 0; i < wordGraphsPerLength.Length; i++)
        {
            wordGraphsPerLength[i] = new WordGraph();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        WordGraph GetWordGraph(int length)
        {
            return wordGraphsPerLength[length - 2];
        }

        var wordsWithRequestedLength = new List<string>(2000);

        var maxLengthToConsider = requestedLength - 2;
        var minLengthToConsider = 2;
        foreach (var word in words)
        {
            var wordSpan = word.AsSpan();
            var wordLength = wordSpan.Length;
            if (wordLength == requestedLength)
            {
                wordsWithRequestedLength.Add(word);
                continue;
            }

            if (wordLength < minLengthToConsider || wordLength > maxLengthToConsider)
            {
                continue;
            }

            var wordGraph = GetWordGraph(wordLength);
            for (var characterIndex = 0; characterIndex < wordLength; characterIndex++)
            {
                var character = wordSpan[characterIndex];
                wordGraph = wordGraph.GetOrCreateNode(character);
            }
        }

        return () =>
        {
            var results = new List<string>(2000);
            for (int firstWordLength = 2; firstWordLength < requestedLength - 1; firstWordLength++)
            {
                var secondWordLength = requestedLength - firstWordLength;
                var firstWordGraph = GetWordGraph(firstWordLength);
                var secondWordGraph = GetWordGraph(secondWordLength);
                var path = new WordGraphPath(firstWordGraph, firstWordLength, secondWordGraph, secondWordLength);
                
                for (var w = 0; w < wordsWithRequestedLength.Count; w++)
                {
                    var word = wordsWithRequestedLength[w];
                    var wordSpan = word.AsSpan();

                    if (path.Contains(wordSpan))
                    {
                        StringBuilder.Append(wordSpan.Slice(0, firstWordLength));
                        StringBuilder.Append(" + ");
                        StringBuilder.Append(wordSpan.Slice(firstWordLength, secondWordLength));
                        StringBuilder.Append(" = ");
                        StringBuilder.Append(wordSpan);
                        results.Add(StringBuilder.ToString());
                        StringBuilder.Clear();
                    }
                }
            }

            return results;
        };

    }
}
