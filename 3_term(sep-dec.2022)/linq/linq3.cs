using System;
using System.IO;
using System.Linq;

public class Program
{

    public static void Main()
    {
        int a, b, n;
        int[] numbers;


        using (StreamReader fileIn = new StreamReader("input15-3.txt"))
        {
            // Select - Linq метод, который проецирует каждый элемент последовательности в новую форму.
            int[] parameters = Array.ConvertAll(fileIn.ReadLine().Split(' '), s => int.Parse(s));
            a = parameters[0];
            b = parameters[1];
            n = int.Parse(fileIn.ReadLine());
            numbers = fileIn.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }


        var result_numbers = numbers.Where(elem => elem < a || elem > b).OrderByDescending(elem => elem)
            .Select(elem => elem);

        using (StreamWriter fileOut = new StreamWriter("output.txt", false))
        {
            foreach (int num in result_numbers)
            {
                fileOut.Write("{0} ", num);
            }
        }
    }
}
