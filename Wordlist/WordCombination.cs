namespace Wordlist {
  public class WordCombination : IWord {
    private IWord Left { get;  }
    private IWord Right { get; }
    public int Length { get; }
    public string Content { get; }

    public WordCombination(string left, string right)
    {
      Left = new Word(left);
      Right = new Word(right);
      Content = Left.Content + Right.Content;
      Length = Content.Length;
    }

    public WordCombination(IWord left, IWord right) {
      Left = left;
      Right = right;
      Content = left.Content + right.Content;
      Length = Content.Length;
    }

    public override string ToString() {
      return $"{Left.Content} + {Right.Content} = {Content}";
    }

    public WordCombination Reverse() {
      return new WordCombination(Right, Left);
    }
  }
}