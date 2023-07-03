using FluentAssertions;
using Wordlist.Solutions.Graph;
using Wordlist.Solutions.HashSets;

namespace Wordlist.Tests;

public class CombinationsFinderTests
{
    [Theory]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    [InlineData(12)]
    public void AlgorithmsShouldReturnCorrectNumberOfResults(int requestedLength)
    {
        // Arrange
        var wordlist = WordlistReader.ReadWords();
        
        // Act
        var graphCombinations = GraphCombinationsFinder.Find(wordlist, requestedLength)();
        var hashSetsCombinations = HashSetsCombinationsFinder.Find(wordlist, requestedLength)();

        var expectedLength = 0;
        switch (requestedLength)
        {
            case 6:
                expectedLength = 1536;
                break;
            case 8:
                expectedLength = 2439;
                break;
            case 10:
                expectedLength = 1579;
                break;
            case 12:
                expectedLength = 669;
                break;
        }
        
        // Assert
        graphCombinations.Count.Should().Be(expectedLength);
        hashSetsCombinations.Count.Should().Be(expectedLength);
    }
}
