using System;
using System.Diagnostics;
using System.Linq;
using Wordlist;
using Wordlist.Solutions.Graph;

var start = Stopwatch.GetTimestamp();
var words = WordlistReader.ReadWords();
var results = GraphCombinationsFinder.Find(words, 6)();
var elapsed = Stopwatch.GetElapsedTime(start);
Console.WriteLine($"Done in {elapsed:c}, {results.Count} results");
