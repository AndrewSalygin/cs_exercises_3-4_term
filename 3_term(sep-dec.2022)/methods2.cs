/*
Примеры:
1
1
Ответ: 1 + 1 + 2 = 4

3
5
Ответ: (1 + 3)*3/2 + (1 + 10)*10/2 = 61

8
4
Ответ: (1 + 8)*8/2 + (1 + 8)*8/2 = 72
*/

using System;
using System.Collections.Generic;

class practice
{
    static int func(int num)
    {
        if (num == 1)
        {
            return 1;
        }
        else
        {
            return num + func(num - 1);
        }
    }
    static void Main()
    {
        Console.Write("Введите m: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Введите k: ");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(func(m) + func(2 * k));
    }
}
