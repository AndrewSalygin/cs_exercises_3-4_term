using System;

/*
n = 3
x = 100

Исходный массив:
13 10 11
50 12 50
12 14 22
Полученный массив:
50 12 50

Использовать  ступенчатый массив выгоднее, чем двумерный, так как 
нужно работать отдельно со строками массива.
*/

class practice
{
    static int[][] InputMatrix(int n, int m)
    {
        int[][] arr = new int[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                Console.Write("a[{0},{1}] = ", i, j);
                arr[i][j] = int.Parse(Console.ReadLine());
            }
        }

        return arr;
    }

    static void PrintMatrix(int[][] arr, int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0} ", arr[i][j]);
            }
            Console.WriteLine();
        }
    }

    static void RemoveRow(int[][] arr, int index, ref int n)
    {
        for (int i = index; i < n - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        --n;
    }
    
    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        int m = n;
        Console.WriteLine("Введите число x:");
        int x = int.Parse(Console.ReadLine());

        // Заполняем массив n×n
        Console.WriteLine("Заполняем массив NxN:");
        int[][] arr = InputMatrix(n, n);
        
        Console.WriteLine("Исходный массив:");
        PrintMatrix(arr, n, m);

        int sum;
        int row = 0;
        while (row < n)
        {
            sum = 0;
            
            // j - это элемент массива
            Array.ForEach(arr[row], j => sum += j);
            if (sum <= x)
            {
                RemoveRow(arr, row, ref n);
            }
            else
            {
                row++;
            }
        }

        Console.WriteLine("Полученный массив:");
        PrintMatrix(arr, n, m);
    }
}

// В лямбда-выражениях лямбда-оператор => отделяет входные 
// параметры в левой части от тела лямбда-выражения в правой части.
