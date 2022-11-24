using System;
using System.Globalization;
using System.IO;
using System.Text;


public class Example
{
    public static void Main()
    {
        // Записываем в temp файл данные из первого файла
        using (StreamReader fileIn1 = new StreamReader("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/11-1.txt"))
        {
            using (StreamWriter fileOutTemp = new StreamWriter("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/~11.txt", false))
            {
                string line;
                while ((line = fileIn1.ReadLine()) != null)
                {
                    fileOutTemp.WriteLine(line);
                }
            }
        }
      
        // Записываем данные из второго файла в первый
        using (StreamReader fileIn2 = new StreamReader("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/11-2.txt"))
        {
            using (StreamWriter fileOut1 = new StreamWriter("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/11-1.txt", false))
            {
                string line;
                while ((line = fileIn2.ReadLine()) != null)
                {
                    fileOut1.WriteLine(line);
                }
            }
        }
      
        // Записываем данные во второй файл из временного
        using (StreamReader fileInTemp = new StreamReader("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/~11.txt"))
        {
            using (StreamWriter fileOut2 = new StreamWriter("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/11-2.txt", false))
            {
                string line;
                while ((line = fileInTemp.ReadLine()) != null)
                {
                    fileOut2.WriteLine(line);
                }
            }
        }
      
        // Проблем, вроде, не должно быть
        File.Delete("E:/Rider_Projects/ConsoleApp2/ConsoleApp2/~11.txt");
    }
}