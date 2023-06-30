using System;
using System.Diagnostics;
using System.Linq;
using Wordlist;

var start = Stopwatch.GetTimestamp();
var words = WordlistReader.ReadWords();
var results = WordCombinationsFinder.FindCombinations(words, 6);
var elapsed = Stopwatch.GetElapsedTime(start);
Console.WriteLine($"Done in {elapsed:c}, {results.Count} results");
