/*

Примеры:
523
1
Answer: No

45
5
Answer: Yes

-52
2
Answer: Yes
*/

using System;
class practice
{
    static void Main()
    {
        Console.WriteLine("Введите число:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число A:");
        int A = int.Parse(Console.ReadLine());
        Console.WriteLine((A == (Math.Abs(num) % 10)) ? "Yes" : "No");
    }
}

