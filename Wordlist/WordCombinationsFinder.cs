using System.Collections.Generic;
using System.Globalization;

namespace Wordlist;

public class WordCombinationsFinder
{
    public static IEnumerable<string> FindCombinations(IEnumerable<string> words, int requestedLength)
    {
        // Requested length = 8? We'll only keep of words of length 2-6 
        var wordGraphsPerLength = new WordGraph[requestedLength - 3];
        for (int i = 0; i < wordGraphsPerLength.Length; i++)
        {
            var length = i + 2;
            wordGraphsPerLength[i] = new WordGraph(length, ' ');
        }

        WordGraph GetWordGraph(int length)
        {
            return wordGraphsPerLength[length - 2];
        }

        var wordsWithRequestedLength = new List<string>();

        foreach (var word in words)
        {
            var lowerWord = word.ToLower(CultureInfo.InvariantCulture);
            var wordLength = lowerWord.Length;
            if (wordLength == requestedLength)
            {
                wordsWithRequestedLength.Add(lowerWord);
                continue;
            }

            if (wordLength < 2 || wordLength > requestedLength - 2)
            {
                continue;
            }

            var wordGraph = GetWordGraph(wordLength);
            for (var characterIndex = 0; characterIndex < wordLength; characterIndex++)
            {
                var character = lowerWord[characterIndex];
                wordGraph = wordGraph.GetOrCreateNode(character);
            }
        }

        var paths = new List<WordGraphPath>(8);
        for (int lengthOfFirstWord = 2; lengthOfFirstWord < requestedLength - 1; lengthOfFirstWord++)
        {
            var lengthOfSecondWord = requestedLength - lengthOfFirstWord;
            var firstWordGraph = GetWordGraph(lengthOfFirstWord);
            var secondWordGraph = GetWordGraph(lengthOfSecondWord);
            var path = new WordGraphPath(firstWordGraph, secondWordGraph);
            paths.Add(path);
        }

        for (var w = 0; w < wordsWithRequestedLength.Count; w++)
        {
            var word = wordsWithRequestedLength[w];
            for (var p = 0; p < paths.Count; p++)
            {
                var path = paths[p];
                var wordCombination = path.Walk(word, requestedLength);
                if (wordCombination != null)
                    yield return wordCombination;
            }
        }
    }
}
