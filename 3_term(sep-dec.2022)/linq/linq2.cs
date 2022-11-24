using System;
using System.IO;
using System.Linq;

public class Program
{
    struct Student
    {
        public string name;
        public int group;
        public int[] marks;
        public bool isSuccess;
        
        public Student(string name, int group, int[] marks)
        {
            this.name = name;
            this.group = group;
            this.marks = new int[3];
            isSuccess = true;
            foreach (var mark in marks)
            {
                if (mark < 3 || mark > 5)
                {
                    isSuccess = false;
                }
            }

            Array.Copy(marks, this.marks, 3);
        }
        
        
    }

    public static void Main()
    {
        Student[] students;
        using (StreamReader fileIn = new StreamReader("input15-2.txt"))
        {
            int n = int.Parse(fileIn.ReadLine());
            
            students = new Student[n];
            string[] student;
            int[] marks;
            
            for (int i = 0; i < n; i++)
            {
                student = fileIn.ReadLine().Split(' ');
                marks = new int[3] {int.Parse(student[4]), int.Parse(student[5]), int.Parse(student[6])};

                students[i] = new Student(student[0] + ' ' + student[1] + ' ' + student[2], int.Parse(student[3]), marks);
            }
        }

        var result_students =
            from stud in students
            where stud.isSuccess
            orderby stud.@group
            select stud;
        
        using (StreamWriter fileOut = new StreamWriter("output.txt", false))
        {
            foreach (Student stud in result_students)
            {
                fileOut.Write("{0} {1} ", stud.name, stud.group);
                foreach (var mark in stud.marks)
                {
                    fileOut.Write("{0} ", mark);
                }
                fileOut.WriteLine();
            }
           
        }
    }
}
