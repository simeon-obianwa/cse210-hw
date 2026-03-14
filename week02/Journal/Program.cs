// Creativity: I included mood tracking, by addeding a Mood field to the Entry class
// At every new entry, the user is prompted to state their current mood, the response is saved along with the date, prompt, and response.
using System;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool showMenu = true;

            Console.WriteLine("Welcome to the Daily Journal Program!");

            while (showMenu)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewEntry(journal);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        SaveJournal(journal);
                        break;
                    case "4":
                        LoadJournal(journal);
                        break;
                    case "5":
                        showMenu = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Please choose an option: ");
        }

        static void CreateNewEntry(Journal journal)
        {
            // Abstraction applied - To getting random prompt from Journal 
            string prompt = journal.GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            
            Console.Write("Your Response: ");
            string response = Console.ReadLine();

            // To show creativity: Ask for mood
            Console.Write("How are you feeling today? (Mood): ");
            string mood = Console.ReadLine();

            // To meet simplification requirement - Current date as string
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Create Entry object
            Entry entry = new Entry(prompt, response, date, mood);
            
            // Abstraction applied - Add to Journal 
            journal.AddEntry(entry);
            Console.WriteLine("Entry added successfully.");
        }

        static void SaveJournal(Journal journal)
        {
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine();
            // Abstraction applied - Journal handles the actual writing 
            journal.SaveToFile(filename);
        }

        static void LoadJournal(Journal journal)
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();
            // Abstraction applied - Journal handles the actual reading and replacing list
            journal.LoadFromFile(filename);
        }
    }
}