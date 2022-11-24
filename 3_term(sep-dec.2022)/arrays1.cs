using System;

/*
n = 4
 
X: (0, 0, 0, 0)

Исходный массив:
1 2 3 4
5 6 7 8
9 1 2 3
4 5 6 7
Полученный массив:
1 0 3 0
5 0 7 0
9 0 2 0
4 0 6 0

Использовать двумерный массив выгоднее, чем ступенчатый, так как 
не нужно работать отдельно со строками массива.
*/

class practice
{
    static void Input(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("a[{0},{1}] = ", i, j);
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    static void Print(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("{0} ", arr[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        
        int[,] arr = new int[n, n];
        int[] X = new int[n];
        
        Console.WriteLine("Введите вектор X:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("X[{0}] = ", i);
            X[i] = int.Parse(Console.ReadLine());
        }

        // Заполняем массив n×n
        Input(arr);
        Console.WriteLine("Исходный массив:");
        Print(arr);

        for (int j = 1; j < n; j += 2)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i, j] = X[i];
            }
        }    
        
        Console.WriteLine("Полученный массив:");
        Print(arr);
    }
}