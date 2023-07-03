using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Wordlist;
using Wordlist.Solutions.Graph;
using Wordlist.Solutions.HashSets;

BenchmarkRunner.Run<Benchmarks>();

[MemoryDiagnoser]
public class Benchmarks
{
    private string[] _words = null!;
    private Func<List<string>> _graph;
    private Func<IList<string>> _hashSet;

    [Params(6,8,10,12)] 
    public int Length { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _words = WordlistReader.ReadWords();
        _graph = GraphCombinationsFinder.Find(_words, Length);
        _hashSet = HashSetsCombinationsFinder.Find(_words, Length);
    }

    [Benchmark]
    public List<string> Graph()
    {
        return _graph();
    }

    [Benchmark]
    public IList<string> HashSet()
    {
        return _hashSet();
    }
}

