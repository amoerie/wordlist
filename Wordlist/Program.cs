using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wordlist
{
    public class Program
    {
        const int requestedLength = 6;
        static readonly Stopwatch stopwatch = new Stopwatch();
        public static void Main(string[] args)
        {
            //IList<IWord> words = ReadWords().ToList();
            string[] words = ReadWords().ToArray();
            
            for(var i = 0; i < 10; i++)
            {
                stopwatch.Start();
                var combinations = GraphCompute(words);
                stopwatch.Stop();
                Console.WriteLine("Combinations: " + combinations.Count);
                Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + "ms");
                //Console.WriteLine("Press enter to see combinations");
                //Console.ReadLine();
                //foreach (var combination in combinations)
                //{
                //    Console.WriteLine(combination);
                //}
                stopwatch.Reset();
            }
            Console.ReadLine();
        }

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

            public string Walk(string word)
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

        public static List<string> GraphCompute(string[] words)
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

            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                var word = words[wordIndex].ToLower();
                var wordLength = word.Length;
                if (wordLength == requestedLength)
                {
                    wordsWithRequestedLength.Add(word);
                    continue;
                }

                if (wordLength < 2 || wordLength > requestedLength - 2)
                {
                    continue;
                }

                var wordGraph = GetWordGraph(wordLength);
                for (var characterIndex = 0; characterIndex < wordLength; characterIndex++)
                {
                    var character = word[characterIndex];
                    wordGraph = wordGraph.GetOrCreateNode(character);
                }
            }
            
            //stopwatch.Reset();
            //stopwatch.Start();

            var paths = new List<WordGraphPath>(8);
            for (int lengthOfFirstWord = 2; lengthOfFirstWord < requestedLength - 1; lengthOfFirstWord++)
            {
                var lengthOfSecondWord = requestedLength - lengthOfFirstWord;
                var firstWordGraph = GetWordGraph(lengthOfFirstWord);
                var secondWordGraph = GetWordGraph(lengthOfSecondWord);
                var path = new WordGraphPath(firstWordGraph, secondWordGraph);
                paths.Add(path);
            }
            
            var combinations = new List<string>(512);
            for (var w = 0; w < wordsWithRequestedLength.Count; w++)
            {
                var word = wordsWithRequestedLength[w];
                for (var p = 0; p < paths.Count; p++)
                {
                    var path = paths[p];
                    var wordCombination = path.Walk(word);
                    if (wordCombination != null)
                        combinations.Add(wordCombination);
                }
            }

            return combinations;
        }

        private static IEnumerable<string> ReadWords()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Wordlist.wordlist.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //yield return new Word(line);
                        yield return line;
                    }
                }
            }
        }
    }
}