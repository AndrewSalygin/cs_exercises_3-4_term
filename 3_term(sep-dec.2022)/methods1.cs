using System;
using System.Collections.Generic;

/*
Примеры:
1
15

1 имеет 1 нечетных цифр
2 имеет 0 нечетных цифр
3 имеет 1 нечетных цифр
4 имеет 0 нечетных цифр
5 имеет 1 нечетных цифр
6 имеет 0 нечетных цифр
7 имеет 1 нечетных цифр
8 имеет 0 нечетных цифр
9 имеет 1 нечетных цифр
10 имеет 1 нечетных цифр
11 имеет 2 нечетных цифр
12 имеет 1 нечетных цифр
13 имеет 2 нечетных цифр
14 имеет 1 нечетных цифр
15 имеет 2 нечетных цифр
B
Все числа, которые не имеют нечётных цифр в числе:
2
4
6
8
C
Числа, в которых число нечётных максимально:
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
        Console.Write("Введите начало отрезка: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите конец отрезка: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("A");
        for (int i = a; i <= b; i++)
        {
            Console.WriteLine("{0} имеет {1} нечетных цифр", i, count_of_odd(i));
        }

        // B
        Console.WriteLine("B");
        Console.WriteLine("Все числа, которые не имеют нечётных цифр в числе:");

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
        Console.WriteLine("Числа, в которых число нечётных максимально:");

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
        Console.Write("Введите A:");
        int A = int.Parse(Console.ReadLine());
        Console.Write("Введите B:");
        int B = int.Parse(Console.ReadLine());

        // Берем следующее число
        int C = Math.Abs(A) + 1;

        // Здесь хранятся цифры числа
        List<int> C_digits = new List<int>();

        
        int count_of_digits_C = count_of_digits(C);
        int odds = count_of_odd(C);

        // Проверяем тривиальный случай
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
            // Заносим цифры в список
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
                    // Учитываем переход на другой разряд
                    C_digits[pointer]++;
                    if (C_digits[pointer] == 10)
                    {
                        C_digits[pointer] = 0;
                        C_digits[pointer + 1]++;
                    }
                    // Пересчитываем количество нечетных
                    odds = count_of_odd(++C);
                }

            }

            // Если поменяли более одной цифры, остальные справа
            // нужно заменить на единицы, так будет получаться
            // ближайшее число
            for (int i = 0; i < pointer - 1; i++)
            {
                C_digits[i] = 1;
            }

            // Если число было изначально отрицательным
            if (A < 0)
                Console.Write("-");

            // Выводим итоговое число
            for (int i = C_digits.Count - 1; i >= 0; i--)
            {
                Console.Write("{0}", C_digits[i]);
            }
        }
    }
}

