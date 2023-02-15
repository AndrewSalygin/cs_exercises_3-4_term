using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LastEx
{
    internal class Program
    {
        // поиск просроченного товара
        internal static Goods[] FindIsntFresh(Goods[] goods, DateTime now, int n)
        {
            Goods[] temp = new Goods[n];
            
            // проверка каждого товара из базы
            // второй индекс вводится, чтобы в результирующем массиве не было пустот
            for(int i = 0, j = 0; i < goods.Length; i++)
            {
                if (!goods[i].IsFresh(now))
                {
                    temp[j] = goods[i];
                    j++;
                }
            }

            return temp;
        }

        public static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());

                // база товаров
                Goods[] goods = new Goods[n];

                // дата для проверки свежести товара
                DateTime date = new DateTime(2023, 10, 23);

                string line;
                
                // счётчик заносимого в базу элемента
                int index = 0;
                
                // счётчик строчки для ошибки типа
                int k = 2;

                string name;
                double price;
                int count;
                DateTime productionDate;
                TimeSpan shelfLife;
                int[] dateLocal = new int[3];
                int productsIndex;
                string[] dateForCycle;
                
                while ((line = fileIn.ReadLine()) != null)
                {
                    // формируем список с удобным представлением данных 
                    List<string> data = new List<string>(line.Split(','));

                    name = data[1];
                    price = double.Parse(data[2]);
                    
                    if (data[0] == "Комплект")
                    {
                        // парсятся продукты
                        string[] products = data[3].Substring(1, data[3].Length - 2).Split(';');
                        
                        // делится на 4, так как всего полей 4 и для того, чтобы циклически записывать список продуктов
                        Product[] listOfProducts = new Product[ (products.Length - 1) / 4];
                        
                        // индекс для полей цикла различных продуктов, так как все поля находятся в одном массиве products
                        productsIndex = 0;
                        
                        // заносятся в перечень продуктов
                        while (productsIndex < products.Length - 1)
                        {
                            dateForCycle = products[productsIndex + 2].Split('-'); 
                            
                            // распарсим дату
                            for (int i = 0; i < 3; i++)
                            {
                                dateLocal[i] = int.Parse(dateForCycle[i]);
                            }
                            productionDate = new DateTime(dateLocal[0], dateLocal[1], dateLocal[2]);
                            
                            // укажем количество дней свежести товара
                            shelfLife = new TimeSpan(int.Parse(products[productsIndex + 3]), 0, 0, 0);
                            
                            listOfProducts[productsIndex / 4] = new Product(products[productsIndex], 
                                double.Parse(products[productsIndex + 1]), productionDate, shelfLife);
                            
                            // переходим к другому продукту из комплекта 
                            productsIndex += 4;
                        }
                        
                        // заносится товар в базу
                        goods[index] = new Set(name, price, listOfProducts);
                        
                        // переход к следующему товару
                        index++;
                    }
                    else if (data[0] == "Продукт" || data[0] == "Партия")
                    {
                        dateForCycle = data[3].Split('-');
                        
                        // распарсим дату
                        for (int i = 0; i < 3; i++)
                        {
                            dateLocal[i] = int.Parse(dateForCycle[i]);
                        }
                        productionDate = new DateTime(dateLocal[0], dateLocal[1], dateLocal[2]);
                        
                        // укажем количество дней свежести товара
                        shelfLife = new TimeSpan(int.Parse(data[4]), 0, 0, 0);

                        // заносится товар в базу
                        if (data[0] == "Продукт")
                        {
                            goods[index] = new Product(name, price, productionDate, shelfLife);
                        }
                        else if (data[0] == "Партия")
                        {
                            count = int.Parse(data[5]);
                            goods[index] = new Batch(new Product(name, price, productionDate, shelfLife), count);
                        }
                        
                        // переход к следующему товару
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка типа на {0}-той строчке", k);
                    }
                    
                    k++;
                }
                
                // убираются элементы с ошибкой типа
                goods = goods.Where(x => x != null).ToArray();
                
                // вывод базы
                foreach (var item in goods)
                {
                    item.PrintInfo();
                }

                Console.WriteLine();
                
                Console.WriteLine("Несвежие товары:");
                Goods[] listInsntFresh = FindIsntFresh(goods, date, index); 
                listInsntFresh = listInsntFresh.Where(x => x != null).ToArray();
                
                foreach (var item in listInsntFresh)
                {
                    item.PrintInfo();
                }

                Console.WriteLine();
                
                Console.WriteLine("Отсортированные товары:");
                Array.Sort(goods);
                foreach (var item in goods)
                {
                    item.PrintInfo();
                }
            }
        }
    }
}

/*
   Batch temp = (Batch)((Batch)goods[3]).Clone();
    
    Console.WriteLine("-------- {0}", ((Batch)goods[3]).Count);
    Console.WriteLine("-------- {0}", temp.Count);
    temp.Count = 2;

    Console.WriteLine("-------- {0}", ((Batch)goods[3]).Count);
    Console.WriteLine("-------- {0}", temp.Count);
*/

/*
                    Set temp = (Set)((Set)goods[0]).Clone();
                
                foreach (var item in ((Set)goods[0]).ListOfProducts)
                {
                    Console.WriteLine("-------- {0}", item.Name);
                }
                foreach (var item in temp.ListOfProducts)
                {
                    Console.WriteLine("-------- {0}", item.Name);
                }
                
                Console.WriteLine();
                temp.ListOfProducts = new Product[]{(Product)goods[2]};

                foreach (var item in ((Set)goods[0]).ListOfProducts)
                {
                    Console.WriteLine("-------- {0}", item.Name);
                }
                foreach (var item in temp.ListOfProducts)
                {
                    Console.WriteLine("-------- {0}", item.Name);
                }
*/