/*
�������:
1
1
�����: 1 + 1 + 2 = 4

3
5
�����: (1 + 3)*3/2 + (1 + 10)*10/2 = 61

8
4
�����: (1 + 8)*8/2 + (1 + 8)*8/2 = 72
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
        Console.Write("������� m: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("������� k: ");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(func(m) + func(2 * k));
    }
}
