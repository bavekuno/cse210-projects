//I had my program work with a library of scriptures rather than a single one thus choose scriptures at random to present to the user.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    public class Programs
    {
        public static void Main(string[] args)
        {
            // Create a library of scriptures.
            var scriptureLibrary = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Moroni", 10, 4), "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."),
                new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he hath commanded them.")
            };

            // Use a Random object to select a scripture from the library.
            Random random = new Random();
            int randomIndex = random.Next(0, scriptureLibrary.Count);
            Scripture currentScripture = scriptureLibrary[randomIndex];


            while (!currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());

                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Randomly hide a few words..
                currentScripture.HideRandomWords(3);
            }

            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nAll words are now hidden. Program ended.");
        }
    }

    public class Word
    {
        private string _text;
        private bool _isHidden;

        // Constructor to initialize a new word
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // Hides the word by setting its hidden status to true.
        public void Hide()
        {
            _isHidden = true;
        }

        // Checks if the word is currently hidden.
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Returns the word's text or underscores if it is hidden.
        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }

    // The Reference class manages the scripture reference details.
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;

        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        // Gets the formatted display text for the reference.
        public string GetDisplayText()
        {
            if (_startVerse == _endVerse)
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
        }
    }

    // The Scripture class manages the scripture text and its words.
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // to split the text into words and create Word objects
            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string wordText in wordArray)
            {
                _words.Add(new Word(wordText));
            }
        }

        // to hide a specified number of words that are not already hidden.
        public void HideRandomWords(int numberToHide)
        {
            // Get a list of words that are not currently hidden
            List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

            if (unhiddenWords.Count == 0)
            {
                return;
            }

            // Hide up to `numberToHide` words
            int countToHide = Math.Min(numberToHide, unhiddenWords.Count);

            for (int i = 0; i < countToHide; i++)
            {
                // Select a random index from the unhidden words list
                int randomIndex = _random.Next(0, unhiddenWords.Count);

                // Hide the selected word and remove it from the temporary list
                unhiddenWords[randomIndex].Hide();
                unhiddenWords.RemoveAt(randomIndex);
            }
        }

        // to returns the complete scripture text for display, including the reference.
        public string GetDisplayText()
        {
            string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()} {text}";
        }

        // Checks if all words in the scripture have been hidden.
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}