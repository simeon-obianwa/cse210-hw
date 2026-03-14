using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries;
        
        // List of prompts as per project specification
        private List<string> _prompts;

        public Journal()
        {
            _entries = new List<Entry>();
            _prompts = new List<string>();
            InitializePrompts();
        }

        private void InitializePrompts()
        {
            // Added at least 5 prompts as per project requirements
            _prompts.Add("Who was the first person I met at work today?");
            _prompts.Add("What was the best part of my day at work?");
            _prompts.Add("What type of food did I take for lunch today?");
            _prompts.Add("What benefit did the Lords prayer brings to my life?");
            _prompts.Add("What was the strongest emotion I felt today?");
            _prompts.Add("If I had one thing I cannot forget, what would it be?");
        }

        // Abstraction applied: Program doesn't need to know how a prompt was picked
        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void DisplayEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries in the journal yet.");
                return;
            }

            Console.WriteLine("\n=== JOURNAL ENTRIES ===");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        // Abstraction applied: Program doesn't need to know file I/O details
        public void SaveToFile(string filename)
        {
            try 
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine(entry.ToFileString());
                    }
                }
                Console.WriteLine($"Journal saved successfully to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        // Abstraction applied: Program doesn't need to know parsing details
        public void LoadFromFile(string filename)
        {
            try 
            {
                // Requirement: Replace entries currently stored
                _entries.Clear();

                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Entry entry = Entry.FromFileString(line);
                        if (entry != null)
                        {
                            _entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine($"Journal loaded successfully from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}