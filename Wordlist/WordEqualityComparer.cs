using System;
using System.Collections.Generic;

namespace Wordlist {
  public class WordEqualityComparer : IEqualityComparer<IWord> {
    public bool Equals(IWord x, IWord y) {
      return x.Length == y.Length && string.Equals(x.Content, y.Content, StringComparison.OrdinalIgnoreCase);
    }

    public int GetHashCode(IWord word) {
      return word.Content.GetHashCode();
    }
  }
}