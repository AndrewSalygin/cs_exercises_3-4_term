using System;
using System.IO;
using System.Text;

namespace Exercise17
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader text = new StreamReader("input.txt"))
            {
                // 1 и 2 пункт
                string parameters = text.ReadLine();

                int a = int.Parse(parameters.Split(' ')[0]);
                int b = int.Parse(parameters.Split(' ')[1]);
                int lambda = int.Parse(parameters.Split(' ')[2]);

                Rectangle rectangle = new Rectangle(a, b);

                // 3 пункт
                Console.WriteLine("Прямоугольник: {0}", rectangle);
                Console.WriteLine("Периметр прямоугольника: {0}", rectangle.Perimeter());
                Console.WriteLine("Площадь прямоугольника: {0}", rectangle.Area());

                // 4 пункт
                rectangle.A = 10;
                rectangle.B = 10;
                if (rectangle.IsSquare)
                {
                    Console.WriteLine("Прямоугольник является квадратом");
                }
                else
                {
                    Console.WriteLine("Прямоугольник не является квадратом");
                }

                // 5 пункт
                Console.WriteLine("Текущие стороны: {0}, {1}", rectangle[0], rectangle[1]);
                
                // 6 пункт
                rectangle++;
                Console.WriteLine("увеличенный прямоугольник {0}", rectangle);
                rectangle--;
                Console.WriteLine("уменьшенный прямоугольник {0}", rectangle);
                if (rectangle)
                    Console.WriteLine("Прямоугольник - это квадрат");
                else
                    Console.WriteLine("Прямоугольник - это не квадрат");
                rectangle *= lambda;
                Console.WriteLine("Увеличенный прямоугольник на lambda {0}", rectangle);
            }
        }
    }
}
