using System;
class practice
{
    static void Main()
    {
        Console.WriteLine("������� ����� A:");
        int A = int.Parse(Console.ReadLine());
        Console.WriteLine("������� ����� B:");
        int B = int.Parse(Console.ReadLine());

        if (B % 2 == 0)
        {
            B--;
        }
        for (int i = B; i >= A; i -= 2)
        {
            Console.Write("{0} ", i * i * i);
        }
    }
}

