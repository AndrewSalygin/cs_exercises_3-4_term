using System;
using System.IO;
using MyProgram;

namespace MyProgram
{
    public struct SPoint : IComparable<SPoint>
    {
        public double x, y;

        public SPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show2D(StreamWriter fileOut)
        {
            fileOut.WriteLine("({0}, {1})", x, y);
        }

        public int CompareTo(SPoint obj)
        {
            double first_distance = this.Distance();
            double second_distance = obj.Distance();
            if (first_distance == second_distance)
            {
                return 0;
            }
            else if (first_distance > second_distance)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public double Distance()
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}


public class Program
{
    static public SPoint[] Input(string name)
    {
        using (StreamReader fileIn = new StreamReader(name))
        {
            int n = int.Parse(fileIn.ReadLine());
            SPoint[] arr = new SPoint[n]; // описание массива структур
            for (int i = 0; i < n; i++)
            {
                string[] coordinates = fileIn.ReadLine().Split(' ');

                arr[i] = new SPoint(double.Parse(coordinates[0]), double.Parse(coordinates[1]));
            }
            return arr;
        }
    }

    public static void Main()
    {
        SPoint[] arr = Input("input14-1.txt");
        Array.Sort(arr);
        using (StreamWriter fileOut = new StreamWriter("output.txt", false))
        {
            fileOut.WriteLine("Точка, которая наименее удалена от начала координат:");
            arr[0].Show2D(fileOut);
        }

    }
}