using System;
using Wordlist;

var words = WordlistReader.ReadWords();
var combinations = WordCombinationsFinder.FindCombinations(words, 6);
foreach (var combination in combinations)
{
    Console.WriteLine(combination);
}
