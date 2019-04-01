namespace Wordlist {
  public class Word : IWord {
    public string Content { get; }
    public int Length { get; }

    public Word(string content) {
      Content = content;
      Length = content.Length;
    }
  }
}
