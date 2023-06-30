using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Wordlist;

public static class WordlistReader
{
    public static string[] ReadWords()
    {
        return File.ReadAllLines("./wordlist.txt");
    }

}
