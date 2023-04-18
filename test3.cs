using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Указываем путь к входному файлу
            string inputFilePath = @"C:\test task\lermontow_m_j-text_0410.txt";

            // Указываем путь к выходному файлу
            string outputFilePath = @"C:\test task\OutputFile.txt";

            // Читаем весь текст из входного файла
            string text = File.ReadAllText(inputFilePath);

            // Разбиваем текст на слова
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}', '<', '>', '/', '\\', '|', '@', '#', '$', '%', '^', '&', '*', '-', '_', '+', '=', '"', '\'', '`' }, StringSplitOptions.RemoveEmptyEntries);

            // Создаем словарь для подсчета уникальных слов и их количество употреблений
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // Подсчитываем количество употреблений каждого слова
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            // Сортируем слова по убыванию количества употреблений
            List<KeyValuePair<string, int>> sortedWordCount = wordCount.ToList();
            sortedWordCount.Sort((x, y) => y.Value.CompareTo(x.Value));

            // Создаем выходной файл и записываем в него результат
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (KeyValuePair<string, int> word in sortedWordCount)
                {
                    writer.WriteLine(word.Key + "\t\t" + word.Value);
                }
            }

            Console.WriteLine("Done!");
        }
    }
}