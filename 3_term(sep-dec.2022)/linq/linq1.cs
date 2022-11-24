using System;
using System.IO;
using System.Linq;

public class Program
{

    public static void Main()
    {
        int a, b, n;
        int[] numbers;


        using (StreamReader fileIn = new StreamReader("input15-1.txt"))
        {
            // Select - Linq метод, который проецирует каждый элемент последовательности в новую форму.
            int[] parameters = Array.ConvertAll(fileIn.ReadLine().Split(' '), s => int.Parse(s));
            a = parameters[0];
            b = parameters[1];
            n = int.Parse(fileIn.ReadLine());
            numbers = fileIn.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }


        var result_numbers =
            from elem in numbers
            where elem >= a && elem <= b
            orderby elem
            select elem;

        using (StreamWriter fileOut = new StreamWriter("output.txt", false))
        {
            foreach (int num in result_numbers)
            {
                fileOut.Write("{0} ", num);
            }
        }
    }
}
