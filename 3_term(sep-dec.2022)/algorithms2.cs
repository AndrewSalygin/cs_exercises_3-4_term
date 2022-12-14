using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

/*
 Всякое нечетное составное число n представимо 
в виде произведения двух натуральных нечетных 
чисел больше единицы:
    n = (2*i + 1)*(2*j + 1), (1)

Запишем нечетное n в виде 2*m + 1, подставим в (1), и получим
выражение для m:

(2) m = 2*i*j + i + j.

выражение (2) при этом примет свое максимальное значение:

mmax = 2*imax*imax + imax + imax,
imax^2 + imax — mmax/2 = 0.

Решив это квадратное уравнение, получим: imax = (√(2*mmax+1)-1)/2
Ограничение для счетчика внутреннего цикла jmax ≥ j найдем из неравенства
mmax ≥ 2*i*j + i + j, откуда получаем: jmax = (mmax – i)/(2*i + 1).

----
это поясняет, что единственное различие между этими двумя алгоритмами заключается в том, 
что сито Сундарама отбирает составные числа, используя все нечетные числа в качестве 
базовых значений, тогда как сито Эратосфена, учитывающее только шансы, использует в 
качестве базовых значений только нечетные простые числа с обоими диапазонами базовых значений. 
значения, ограниченные квадратным корнем диапазона.

Решето Сундарама оптимизация:
Эквивалент решета Эратосфена на шаге 2 выше, начиная со следующего простого числа в квадрате, начинается со 2f^2+2f следующего индекса f
https://artofproblemsolving.com/wiki/index.php/Sieve_of_Sundaram

Решето Эратосфена оптимизация:
Четные числа можно вообще не рассматривать.

Алгоритм Эратосфена фактически оперирует с n битами памяти. Следовательно, можно существенно 
сэкономить потребление памяти, храня n переменных булевского типа не как 
n байт, а как n бит, то есть n/8 байт памяти.
Такой подход — «битовое сжатие» — усложняет оперирование этими битами. 
Любое чтение или запись бита будут представлять собой несколько арифметических операций. Но с другой стороны существенно улучшается компактность в памяти. Бо́льшие интервалы умещаются в кэш-память которая работает гораздо быстрее обычной так что при работе по-сегментно общая скорость увеличивается.
 */

class practice
{

    static void Main()
    {
        // РЕШЕТО ЭРАТОСФЕНА
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        bool[] answer1 = new bool[n + 1];
        for (int i = 0; i <= n; i++)
        {
            answer1[i] = true;
        }
        //блок поиска простых чисел
        for (int i = 2; i * i <= n; i++)
        {
            if (answer1[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    answer1[j] = false;
                }
            }
        }
        stopwatch.Stop();
        var elapsedTime1 = stopwatch.ElapsedTicks;
        Console.WriteLine(elapsedTime1);
        /*
        for (int i = 2; i <= n; i++) //вывод простых чисел на экран
        {
            if (answer1[i])
            {
                Console.Write("{0} ", i);
            }
        }
        */
        Console.WriteLine();
        
        // РЕШЕТО СУНДАРАМА

        stopwatch.Restart();
        bool[] answer2 = new bool[n + 1];
        for (int i = 0; i <= n; i++)
        {
            answer2[i] = true;
        }
        //блок поиска простых чисел
        int m = ((int)Math.Sqrt(2 * n + 1) - 1) / 2;
        for (int i = 1; i <= m; i++)
        {
            int k = (n - i) / (2 * i + 1);
            for (int j = i; j <= k; j++) //вычеркивание чисел шага 2
            {
                answer2[i + j + 2 * i * j] = false;
            }
        }

        stopwatch.Stop();
        var elapsedTime2 = stopwatch.ElapsedTicks;
        Console.WriteLine(elapsedTime2);
        
        //вывод на экран простых чисел, согласно шагу 3
        /*
        Console.Write("2 ");
        for (int i = 1; i < n; i++)
        {
            if (answer2[i])
            {
                Console.Write("{0} ", 2 * i + 1);
            }
        }
        */
    }
}

