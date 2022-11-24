using System;
using System.IO;
using System.Collections.Generic;
using MyProgram;

namespace MyProgram
{
    public struct Statement : IComparable<Statement>
    {
        public string name;
        public int countOfThings;
        public double weight;
        public double average_weight; 
        
        public Statement(string name, int countOfThings, double weight)
        {
            this.name = name;
            this.countOfThings = countOfThings;
            this.weight = weight;
            average_weight = weight / countOfThings;
        }

        public int CompareTo(Statement obj)
        {
            if (countOfThings == obj.countOfThings)
            {
                return 0;
            }
            else if (countOfThings > obj.countOfThings)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}


public class Program
{
    static public Statement[] Input(string name)
    {
        using (StreamReader fileIn = new StreamReader(name))
        {
            int n = int.Parse(fileIn.ReadLine());
            Statement[] people = new Statement[n];
            for (int i = 0; i < n; i++)
            {
                string[] info = fileIn.ReadLine().Split(' ');
                Statement man = new Statement(info[0] + ' ' + info[1] + ' ' + info[2], int.Parse(info[3]), double.Parse(info[4]));

                people[i] = man;
            }

            return people;
        }
    }

    public static void Main()
    {
        Console.Write("Напишите средний вес багажа: ");
        double average_weight = double.Parse(Console.ReadLine());

        Statement[] people = Input("input14-2.txt");
        Array.Sort(people);

        using (StreamWriter fileOut = new StreamWriter("output.txt", false))
        {
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].average_weight > average_weight)
                {
                    fileOut.WriteLine("{0} {1} {2}", people[i].name, people[i].countOfThings, people[i].weight);
                }
            }
        }
    }
}