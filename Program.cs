
using System;
using System.Collections.Generic;
using System.IO;
namespace Вопрос__2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите данные учеников в формате: ФИО, Оценка (разделяйте введеные данные  запятой  )");
        Console.WriteLine("Для окончания ввода введите пустую строку.");

        List<string> journalEntries = new List<string>();

        string input;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                journalEntries.Add(input);
            }
        } while (!string.IsNullOrWhiteSpace(input));

        // Создаем и заполняем массив/список объектов-записей в учебном журнале
        List<JournalEntry> entries = new List<JournalEntry>();
        int number = 1;
        foreach (string entryString in journalEntries)
        {
            string[] entryData = entryString.Split( ',' );
            if (entryData.Length >= 2)
            {
                string name = entryData[0];
                string grade = entryData[1];
                JournalEntry entry = new JournalEntry(number, name, grade);
                entries.Add(entry);
                number++;
            }
        }

        // Записываем результат в текстовый файл
        string outputFile = "journal.txt";
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }

        // Выводим результат на консоль
        Console.WriteLine("Результат:");
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }

        Console.WriteLine($"Результат сохранен в файле {outputFile}");
    }
}

class JournalEntry
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }

    public JournalEntry(int number, string name, string grade)
    {
        Number = number;
        Name = name;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"{Number}. {Name} - {Grade}";
    }
}
