// To show creativity: I included mood tracking
using System;

namespace JournalApp
{
    public class Entry
    {
        // Private fields to demonstrate encapsulation
        private string _prompt;
        private string _response;
        private string _date;
        private string _mood; 

        // Public properties to access data safely
        public string Prompt 
        { 
            get { return _prompt; } 
            set { _prompt = value; } 
        }
        
        public string Response 
        { 
            get { return _response; } 
            set { _response = value; } 
        }
        
        public string Date 
        { 
            get { return _date; } 
            set { _date = value; } 
        }

        public string Mood 
        { 
            get { return _mood; } 
            set { _mood = value; } 
        }

        // Constructor
        public Entry(string prompt, string response, string date, string mood)
        {
            _prompt = prompt;
            _response = response;
            _date = date;
            _mood = mood;
        }

        // To display the entry to the screen
        public void Display()
        {
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Mood: {_mood}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Response: {_response}");
            Console.WriteLine($"----------------------------------------\n");
        }

        // Abstraction of file format, converting entry to a string for saving to file
        public string ToFileString()
        {
            // To replace newlines in the response and keep the file structure simple
            string safeResponse = _response.Replace(Environment.NewLine, " ");
            return $"{_date}~|~{_mood}~|~{_prompt}~|~{safeResponse}";
        }

        // Abstraction of parsing logic to create an Entry from a file string
        public static Entry FromFileString(string line)
        {
            string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
            
            if (parts.Length >= 4)
            {
                return new Entry(parts[2], parts[3], parts[0], parts[1]);
            }
            return null;
        }
    }
}