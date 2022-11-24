/*
Примеры:
1000
1 1000 2 500 4 250 5 200 8 125 10 100 20 50 25 40

10
1 10 2 5

7
1 7
*/

using System;
using System.Collections.Generic;

class practice
{
    static void func(int num, int i = 1)
    {
        while (i * i <= num && num % i != 0)
            i++;
        if (i * i <= num)
        {
            Console.Write("{0} {1} ", i, num / i);
            func(num, i + 1);
        }
    }
    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        func(n);
    }
}
