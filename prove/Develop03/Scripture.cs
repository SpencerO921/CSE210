public class Scripture
{
    private string _reference;
    private List<Verse> _verses;
    public Scripture(string reference, List<string> verses)
    {
        _reference = reference;

        _verses = new List<Verse>();
        foreach (string verse in verses)
        {
            Verse verseObj = new Verse(verse);
            _verses.Add(verseObj);

            _verses.Add(new Verse(verse));
        }
    }

    public Scripture(StreamReader reader)
    {
        _reference = reader.ReadLine().Trim();

        _verses = new List<Verse>();
        while (reader.EndOfStream == false)
        {
            string text = reader.ReadLine().Trim();
            _verses.Add(new Verse(text));
        }
    }
}