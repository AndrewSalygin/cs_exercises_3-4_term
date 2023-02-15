using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise17
{
    class Rectangle
    {
        // 1 пункт
        int a, b;

        // 2 пункт
        public Rectangle(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                this.a = 0;
                this.b = 0;
                Console.WriteLine("Стороны должны быть больше 0! Присвоены нулевые значения.");
            }
            else
            {
                this.a = a;
                this.b = b;
            }
        }

        // 3 пункт
        public override string ToString()
        {
            return a.ToString() + " " + b.ToString();
        }
        public int Perimeter()
        {
            return 2*(a + b);
        }
        public int Area()
        {
            return a * b;
        }

        //4 пункт
        public int A 
        { 
            get
            {
                return a;
            }
        
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Сторона должна быть больше 0! Присвоено нулевое значение.");
                }
                else
                {
                    a = value;
                }
            }
        }

        public int B
        {
            get
            {
                return b;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Сторона должна быть больше 0! Присвоено нулевое значение.");
                }
                else
                {
                    b = value;
                }
            }
        }

        public bool IsSquare
        {
            get 
            {
                return a == b;
            }
        }
        
        // 5 пункт
        public int this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return a;
                }
                else if (i == 1)
                {
                    return b;
                }
                else
                {
                    Console.WriteLine("Неправильный индекс.");
                    return -1;
                }
            }
            set
            {
                if (i == 0 && value > 0)
                {
                    a = value;
                }
                else if (i == 1 && value >= 0)
                {
                    b = value;
                }
                else if (i == 0 || i == 1)
                {
                    Console.WriteLine("Значение должно быть больше 0.");
                }
                else
                {
                    Console.WriteLine("Неправильный индекс.");
                }
            }
        }
        
        // 6 пункт
        public static Rectangle operator ++(Rectangle obj)
        {
            return new Rectangle(++obj.a, ++obj.b);
        }
        
        public static Rectangle operator --(Rectangle obj)
        {
            if (obj.a == 1 || obj.b == 1)
            {
                Console.WriteLine("Нельзя сторону сделать равной 0.");
            }
            return new Rectangle(--obj.a, --obj.b);
        }

        public static bool operator true(Rectangle obj)
        {
            return obj.IsSquare;
        }

        public static bool operator false(Rectangle obj)
        {
            return !obj.IsSquare;
        }

        public static Rectangle operator *(Rectangle obj, int lambda)
        {
            if (lambda < 0)
            {
                Console.WriteLine("Множитель должен быть больше нуля.");
                return obj;
            }
            else
            {
                return new Rectangle(obj.a * lambda, obj.b * lambda);
            }
        }
    }
}
