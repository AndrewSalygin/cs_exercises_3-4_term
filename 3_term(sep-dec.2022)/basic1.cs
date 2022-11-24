/*
Примеры:
3
5
4
3+5+4=12

7
-5
1
7+(-5)+1=3

-3
0
4
-3+0+4=1
*/


using System;
class practice
{
    static void Main()
    {
        Console.Write("a=");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        int b = int.Parse(Console.ReadLine());
        Console.Write("c=");
        int c = int.Parse(Console.ReadLine());
        Console.Write("{0}" + "+" + (b >= 0 ? "{1}" : "({1})")
        + "+" + (c >= 0 ? "{2}" : "({2})") + "=" + (a + b + c), a, b, c);
    }
}

