using System;
using System.IO;
using sem4_1.Properties;
using System.IO; 

namespace sem4_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                string line = fileIn.ReadToEnd();
                string[] data = line.Split(' '); 
                foreach (string item in data)
                {
                    tree.Add(int.Parse(item));
                } 
            }

            using (StreamWriter fileOut = new StreamWriter("output.txt"))
            {
                // #1
                fileOut.WriteLine(tree.CountNodeOneLeftSon());
            }

            // #2
                tree.PrintLevels();
                
                // #3
             //   tree.DelNodesAndCheckPerfectlyBalancedTree();

        }
    }
}

