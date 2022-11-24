/*
Примеры:
241
Ответ: 1

62
Ответ: 31

15
Ответ: 5
*/

using System;

class practice
{
    static void Main()
    {
        Console.Write("Введите число N:");
        int N = int.Parse(Console.ReadLine());

        int i = N / 2;
        for (; i >= 1; i--)
        {
            if (N % i == 0)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}