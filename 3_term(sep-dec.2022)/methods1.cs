using System;
using System.Collections.Generic;

/*
�������:
1
15

1 ����� 1 �������� ����
2 ����� 0 �������� ����
3 ����� 1 �������� ����
4 ����� 0 �������� ����
5 ����� 1 �������� ����
6 ����� 0 �������� ����
7 ����� 1 �������� ����
8 ����� 0 �������� ����
9 ����� 1 �������� ����
10 ����� 1 �������� ����
11 ����� 2 �������� ����
12 ����� 1 �������� ����
13 ����� 2 �������� ����
14 ����� 1 �������� ����
15 ����� 2 �������� ����
B
��� �����, ������� �� ����� �������� ���� � �����:
2
4
6
8
C
�����, � ������� ����� �������� �����������:
15
13
11


202
3
311

-202
3
-311

100
1


*/

class practice
{
    static int count_of_odd(int number)
    {
        int count = 0;
        number = Math.Abs(number);
        while (number > 0)
        {
            int digit = number % 10;
            if (digit % 2 == 1)
            {
                count++;
            }
            number /= 10;
        }

        return count;
    }

    static int count_of_digits(int number)
    {
        int count = 0;

        while (number > 0)
        {
            count++;
            number /= 10;
        }

        return count;
    }
    static void Main()
    {
        Console.Write("������� ������ �������: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("������� ����� �������: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("A");
        for (int i = a; i <= b; i++)
        {
            Console.WriteLine("{0} ����� {1} �������� ����", i, count_of_odd(i));
        }

        // B
        Console.WriteLine("B");
        Console.WriteLine("��� �����, ������� �� ����� �������� ���� � �����:");

        int j = a;
        if (a % 2 == 1)
        {
            j++;
        }

        for (; j <= b; j += 2)
        {
            if (count_of_odd(j) == 0)
            {
                Console.WriteLine(j);
            }
        }

        // C
        Console.WriteLine("C");
        Console.WriteLine("�����, � ������� ����� �������� �����������:");

        int max = 0;
        List<int> numbers = new List<int>();

        j = b;
        if (b % 2 == 0)
        {
            max = count_of_odd(j);
            numbers.Add(j);
            j--;
        }

        for (; j >= a; j -= 2)
        {
            int local_max = count_of_odd(j);
            if (local_max > max)
            {
                max = local_max;
                numbers = new List<int>();
            }
            if (local_max == max)
            {
                numbers.Add(j);
            }
        }

        foreach (int num in numbers)
            Console.WriteLine(num);


        // D
        Console.WriteLine("D");
        Console.Write("������� A:");
        int A = int.Parse(Console.ReadLine());
        Console.Write("������� B:");
        int B = int.Parse(Console.ReadLine());

        // ����� ��������� �����
        int C = Math.Abs(A) + 1;

        // ����� �������� ����� �����
        List<int> C_digits = new List<int>();

        
        int count_of_digits_C = count_of_digits(C);
        int odds = count_of_odd(C);

        // ��������� ����������� ������
        if (odds == B)
        {
            Console.WriteLine(C);
        }
        else if (count_of_digits_C < B)
        {
            Console.WriteLine(new string('1', B));
        }
        else
        {
            // ������� ����� � ������
            int copy_C = C;
            while (copy_C > 0)
            {
                C_digits.Add(copy_C % 10);
                copy_C /= 10;
            }

            int pointer = 0;

            while (odds != B)
            {
                if (odds < B)
                {
                    if (C_digits[pointer] % 2 == 0)
                    {
                        C_digits[pointer]++;
                        odds++;
                    }
                    pointer++;
                }
                else
                {
                    // ��������� ������� �� ������ ������
                    C_digits[pointer]++;
                    if (C_digits[pointer] == 10)
                    {
                        C_digits[pointer] = 0;
                        C_digits[pointer + 1]++;
                    }
                    // ������������� ���������� ��������
                    odds = count_of_odd(++C);
                }

            }

            // ���� �������� ����� ����� �����, ��������� ������
            // ����� �������� �� �������, ��� ����� ����������
            // ��������� �����
            for (int i = 0; i < pointer - 1; i++)
            {
                C_digits[i] = 1;
            }

            // ���� ����� ���� ���������� �������������
            if (A < 0)
                Console.Write("-");

            // ������� �������� �����
            for (int i = C_digits.Count - 1; i >= 0; i--)
            {
                Console.Write("{0}", C_digits[i]);
            }
        }
    }
}

