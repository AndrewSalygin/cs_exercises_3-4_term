using System;
using System.Globalization;

// Перечисление StringSplitOptions указывает, должен ли элемент, содержащий пустую строку,
// включаться в возвращенный массив.

// Поле RemoveEmptyEntries - Исключить элементы массива, содержащие пустые строки, из результата.
public class Example
{
    public static void Main()
    {
        string input = "На улице было жарко, однако мы пошли гулять с: Лёшей, Петей, а также Машей.";
        char[] delimiterChars = { ' ', ',', '.', ':', ';', '!', '?', '\t' };
        string[] words = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
        // UnicodeCategory определяет категорию Unicode символа.
        UnicodeCategory category = UnicodeCategory.UppercaseLetter;
      
        Console.WriteLine("Слова сообщения, которые начинаются с прописной буквы:");
        foreach (var word in words)
        {
            // Получаем Unicode категорию  символа Unicode.
            if (CharUnicodeInfo.GetUnicodeCategory(word[0]) == category)
            {
                Console.WriteLine(word);
            }
        }
    }
}