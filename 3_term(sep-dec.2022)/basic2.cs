/*

�������:
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
        Console.WriteLine("������� �����:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("������� ����� A:");
        int A = int.Parse(Console.ReadLine());
        Console.WriteLine((A == (Math.Abs(num) % 10)) ? "Yes" : "No");
    }
}

