/// I added a program that displays four available scriptures rather than one, user selects the scriptures at random to memorize
/// I included a word counter that decreases during scriptures word memorization. 
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// This represents a single word in the scripture with hide/show functionality.
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _isHidden = false;
        }

        public void Hide() => _isHidden = true;
        public bool IsHidden() => _isHidden;

        public string GetDisplayText()
        {
            return _isHidden 
                ? new string(_text.Select(c => char.IsLetter(c) ? '_' : c).ToArray()) 
                : _text;
        }
    }

    /// This represents a scripture reference
    public class Reference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _verseStart;
        private readonly int _verseEnd;

        public Reference(string book, int chapter, int verseStart, int verseEnd = 0)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd == 0 ? verseStart : verseEnd;
        }

        public string GetDisplayText()
        {
            return _verseStart == _verseEnd 
                ? $"{_book} {_chapter}:{_verseStart}" 
                : $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }

    /// This represents a complete scripture with reference and collection of words.
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private static readonly Random _random = new Random();

        public Scripture(string referenceText, string scriptureText)
        {
            _reference = ParseReference(referenceText);
            _words = ParseWords(scriptureText);
        }

        private static Reference ParseReference(string refText)
        {
            var parts = refText.Split(' ');
            var book = parts[0];
            var verseParts = parts[1].Split(':');
            var chapter = int.Parse(verseParts[0]);

            if (verseParts[1].Contains("-"))
            {
                var verses = verseParts[1].Split('-');
                return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            return new Reference(book, chapter, int.Parse(verseParts[1]));
        }

        private static List<Word> ParseWords(string text)
        {
            return text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(w => new Word(w))
                       .ToList();
        }

        public void HideRandomWords(int count)
        {
            var unhiddenIndices = _words
                .Select((word, index) => new { word, index })
                .Where(x => !x.word.IsHidden())
                .Select(x => x.index)
                .ToList();

            int toHide = Math.Min(count, unhiddenIndices.Count);
            
            for (int i = 0; i < toHide; i++)
            {
                int randomIndex = _random.Next(unhiddenIndices.Count);
                int wordIndex = unhiddenIndices[randomIndex];
                _words[wordIndex].Hide();
                unhiddenIndices.RemoveAt(randomIndex);
            }
        }

        public string GetDisplayText()
        {
            return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
        }

        public bool IsCompletelyHidden() => _words.All(w => w.IsHidden());
        public int GetVisibleWordCount() => _words.Count(w => !w.IsHidden());
        public string GetReference() => _reference.GetDisplayText();
    }

    /// This repository manages available scriptures.
    public static class ScriptureRepository
    {
        private static readonly Dictionary<string, string> _scriptures = new()
        {
            { "Proverbs 3:5-6", "Trust in the Lord with all thine heart and lean not unto thy own understanding." },
            { "John 3:16", "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life." },
            { "Romans 8:28", "And we know that all things work together for good to them that love God to them who are the called according to his purpose." },
            { "Psalm 23:1", "The Lord is my shepherd; I shall not want." }
        };

        private static readonly Random _random = new Random();
        private static readonly List<string> _keys = _scriptures.Keys.ToList();

        public static Scripture GetRandomScripture()
        {
            var randomKey = _keys[_random.Next(_keys.Count)];
            return new Scripture(randomKey, _scriptures[randomKey]);
        }

        public static Scripture GetScriptureByReference(string reference)
        {
            return _scriptures.TryGetValue(reference, out var text) 
                ? new Scripture(reference, text) 
                : null;
        }

        public static List<string> GetAllReferences() => new List<string>(_scriptures.Keys);
        public static int GetTotalScriptures() => _scriptures.Count;
    }

    /// To handles user input validation and prompts.
    public static class UserInputHandler
    {
        public static string ReadYesNoQuitPrompt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input == "yes" || input == "y")
                    return "yes";
                if (input == "no" || input == "n")
                    return "no";
                if (input == "quit" || input == "q")
                    return "quit";

                Console.WriteLine("Invalid input. Please enter 'Yes', 'No', or 'quit'.");
            }
        }

        public static string ReadContinuePrompt()
        {
            Console.Write("Press ENTER to continue or type 'quit' to finish: ");
            var input = Console.ReadLine()?.Trim().ToLower();
            return input == "quit" ? "quit" : "continue";
        }
    }

    /// Main application entry point.
    class Program
    {
        private const int WordsToHidePerTurn = 3;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool appRunning = true;

            while (appRunning)
            {
                DisplayWelcomeMessage();
                var scripture = ScriptureRepository.GetRandomScripture();
                RunMemorizationLoop(scripture);
                
                // Ask if user wants another scripture
                var response = UserInputHandler.ReadYesNoQuitPrompt(
                    "\nWould you like to practice another scripture? (Yes/No/quit): ");
                
                if (response == "quit" || response == "no")
                {
                    appRunning = false;
                }
                // If "yes", loop continues and loads a new random scripture
            }
            
            DisplayFarewellMessage();
        }

        private static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("=== Scripture Memorization Tool ===");
            Console.WriteLine($"Available scriptures: {string.Join(", ", ScriptureRepository.GetAllReferences())}");
            Console.WriteLine("\nPress ENTER to reveal fewer words, or type 'quit' to exit the current scripture.");
            Console.WriteLine("Press ENTER to begin...");
            Console.ReadLine();
        }

        private static void RunMemorizationLoop(Scripture scripture)
        {
            Console.Clear();
            Console.WriteLine($"Loading: {scripture.GetReference()}\n");
            Console.WriteLine("Memorize this scripture by pressing ENTER to hide words...\n");
            Console.WriteLine("Press ENTER to start...");
            Console.ReadLine();

            bool scriptureRunning = true;

            while (scriptureRunning)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine($"\n[Words remaining: {scripture.GetVisibleWordCount()}]");

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\n✓ Congratulations! You have memorized this scripture!");
                    break;
                }

                var input = UserInputHandler.ReadContinuePrompt();

                if (input == "quit")
                {
                    scriptureRunning = false;
                }
                else
                {
                    scripture.HideRandomWords(WordsToHidePerTurn);
                }
            }
        }

        private static void DisplayFarewellMessage()
        {
            Console.Clear();
            Console.WriteLine("\n=== Thank you for practicing! ===");
            Console.WriteLine("May these words remain in your heart. Goodbye!");
        }
    }
}