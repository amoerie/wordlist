using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Wordlist;

public static class WordlistReader
{
    public static IEnumerable<string> ReadWords()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "Wordlist.wordlist.txt";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            throw new InvalidOperationException("Wordlist not properly embedded");
        }
        
        using var reader = new StreamReader(stream, Encoding.UTF8);
        while (reader.ReadLine() is { } line)
        {
            yield return line;
        }
    }

}
