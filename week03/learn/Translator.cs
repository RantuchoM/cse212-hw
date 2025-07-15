public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");
        Console.WriteLine(englishToGerman.Translate("Car")); // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// For example, in a english to german dictionary:
    /// 
    /// my_translator.AddWord("book","buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    /// <returns>fixed array of divisors</returns>
    public void AddWord(string fromWord, string toWord)
    {
        if (string.IsNullOrWhiteSpace(fromWord) || string.IsNullOrWhiteSpace(toWord))
        {
            throw new ArgumentException("Words cannot be null or empty.");
        }
        else if (this._words.ContainsKey(fromWord))
        {
            throw new ArgumentException($"The word '{fromWord}' is already added.");
        }
        else
        {
            this._words[fromWord] = toWord;
            Console.WriteLine($"Added translation: {fromWord} -> {toWord}");
        }
        // ADD YOUR CODE HERE
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        if (string.IsNullOrWhiteSpace(fromWord))
        {
            throw new ArgumentException("Word cannot be null or empty.");
        }
        else if (this._words.ContainsKey(fromWord))
        {
            return this._words[fromWord];
        }
        else
        {
            return "???";
        }
        
    }
}