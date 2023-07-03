using System;
using System.Collections.Generic;
using System.Text;

namespace Wordlist.Solutions.HashSets;

public static class HashSetsCombinationsFinder
{
    private static readonly StringBuilder StringBuilder = new StringBuilder();

    public static Func<IList<string>> Find(string[] words, int length)
    {
        var lengthMin2 = length - 2;
        var parts = new HashSet<string>(2000, StringComparer.OrdinalIgnoreCase);
        var wordsWithDesiredLength = new List<string>(2000);
        foreach (var word in words)
        {
            if (word.Length == length)
            {
                wordsWithDesiredLength.Add(word);
                continue;
            }

            if (word.Length > 1 && word.Length <= lengthMin2)
            {
                parts.Add(word);
            }
        }


        return () =>
        {
            var results = new List<string>(2000);
            for (var i = 2; i <= lengthMin2; i++)
            {
                var lengthMinI = length - i;
                foreach (var word in wordsWithDesiredLength)
                {
                    var part1 = word.Substring(0, i);
                    var part2 = word.Substring(i, lengthMinI);
                    if (parts.Contains(part1) && parts.Contains(part2))
                    {
                        StringBuilder.Append(word.AsSpan(0, i));
                        StringBuilder.Append(" + ");
                        StringBuilder.Append(word.AsSpan(i, lengthMinI));
                        StringBuilder.Append(" = ");
                        StringBuilder.Append(word);
                        var combination = StringBuilder.ToString();
                        StringBuilder.Clear();
                        results.Add(combination);
                    }
                }
            }

            return results;
        };
    }
}
