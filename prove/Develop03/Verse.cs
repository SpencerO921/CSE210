public class Verse
{
    private List<Word> _words;
    public Verse(string text)
    {
        //Split text into individual words
        string[] parts = text.Split();
        
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);

           // _words.Add(new Word(part));
        }
    }
}