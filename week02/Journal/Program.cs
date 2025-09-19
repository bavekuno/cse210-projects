//I improved the process of saving and loading to save as a .csv file that could be opened in Excel 

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

// Entry.cs
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}

// Journal.cs
public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What's a new skill or piece of knowledge I gained today?",
            "Describe a moment of peace or tranquility from today.",
            "What is a small act of kindness I witnessed or performed today?"
        };
    }

    public void AddEntry()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomPrompt = _prompts[index];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response: ");
        string userResponse = Console.ReadLine();

        string currentDate = DateTime.Now.ToShortDateString();
        Entry newEntry = new Entry(currentDate, randomPrompt, userResponse);
        _entries.Add(newEntry);
        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
        }
        else
        {
            Console.WriteLine("--- Your Journal Entries ---");
            foreach (var entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("-----------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename, false, new UTF8Encoding(true)))
            {
                // Write the CSV header
                outputFile.WriteLine("Date,Prompt,Response");

                // Write each entry to the file, handling commas and quotes
                foreach (var entry in _entries)
                {
                    string date = EscapeCsvValue(entry.Date);
                    string prompt = EscapeCsvValue(entry.Prompt);
                    string response = EscapeCsvValue(entry.Response);
                    outputFile.WriteLine($"{date},{prompt},{response}");
                }
            }
            Console.WriteLine($"Journal saved to {filename} in CSV format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear(); // Clear current entries before loading new ones
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. No entries were loaded.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            // Skip the header row if it exists
            if (lines.Length > 0 && lines[0].Trim().ToLower() == "date,prompt,response")
            {
                lines = lines[1..];
            }

            foreach (string line in lines)
            {
                string[] parts = ParseCsvLine(line);
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    Entry loadedEntry = new Entry(date, prompt, response);
                    _entries.Add(loadedEntry);
                }
                else
                {
                    Console.WriteLine($"Skipping malformed line: {line}");
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
    }

    private string EscapeCsvValue(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
        {
            string escapedValue = value.Replace("\"", "\"\"");
            return $"\"{escapedValue}\"";
        }
        return value;
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuote = false;
        StringBuilder currentPart = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                if (inQuote && i + 1 < line.Length && line[i + 1] == '"')
                {
                    // It's an escaped double quote
                    currentPart.Append('"');
                    i++; // Skip the next character
                }
                else
                {
                    // It's a field delimiter quote
                    inQuote = !inQuote;
                }
            }
            else if (c == ',' && !inQuote)
            {
                parts.Add(currentPart.ToString());
                currentPart.Clear();
            }
            else
            {
                currentPart.Append(c);
            }
        }
        parts.Add(currentPart.ToString());
        return parts.ToArray();
    }
}

// Program.cs
public class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save to (e.g., journal.csv): ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from (e.g., journal.csv): ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}