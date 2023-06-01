using System;

class Student
{
    public int studentID;
    public string name;
    public float[] grades = new float[5];
    public void Display()
    {
        Console.WriteLine("Student ID: " + studentID);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Grades: ");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(" - Grade " + (i + 1) + ": " + grades[i]);
        }
    }
    public float CalculateGPA()
    {
        float sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum += grades[i];
        }
        return sum / 5;
    }
    public float GetMaxGrade()
    {
        float max = grades[0];
        for (int i = 1; i < 5; i++)
        {
            if (grades[i] > max)
            {
                max = grades[i];
            }
        }
        return max;
    }
    public float GetMinGrade()
    {
        float min = grades[0];
        for (int i = 1; i < 5; i++)
        {
            if (grades[i] < min)
            {
                min = grades[i];
            }
        }
        return min;
    }
    public static float GetMaxGrade(Student[] students)
    {
        float max = students[0].grades[0];
        for (int i = 0; i < students.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (students[i].grades[j] > max)
                {
                    max = students[i].grades[j];
                }
            }
        }
        return max;
    }
    public static float GetMinGrade(Student[] students)
    {
        float min = students[0].grades[0];
        for (int i = 0; i < students.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (students[i].grades[j] < min)
                {
                    min = students[i].grades[j];
                }
            }
        }
        return min;
    }
    static void Main(string[] args)
    {
        Student[] students = new Student[10];

        for (int i = 0; i < 10; i++)
        {
            students[i] = new Student();

            Console.WriteLine("Enter student " + (i + 1) + " information:");

            Console.Write(" - Student ID: ");
            students[i].studentID = int.Parse(Console.ReadLine());

            Console.Write(" - Name: ");
            students[i].name = Console.ReadLine();

            Console.WriteLine(" - Grades:");
            for (int j = 0; j < 5; j++)
            {
                Console.Write("   - Grade " + (j + 1) + ": ");
                students[i].grades[j] = float.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("Enter the operation you want to perform:");
        Console.WriteLine("1- Display student information");
        Console.WriteLine("2- Calculate GPA");
        Console.WriteLine("3- Get maximum grade");
        Console.WriteLine("4- Get minimum grade");
        Console.WriteLine("5- Get overall maximum grade");
        Console.WriteLine("6- Get overall minimum grade");
        Console.WriteLine("7- Sort students by name");
        Console.WriteLine("8- Search for a student by ID");

        int operation = int.Parse(Console.ReadLine());

        switch (operation)
        {
            case 1:
                Console.WriteLine("Enter student number (1-10): ");
                int studentNumber = int.Parse(Console.ReadLine());
                students[studentNumber - 1].Display();
                break;
            case 2:
                Console.WriteLine("Enter student number (1-10): ");
                int studentNumber2 = int.Parse(Console.ReadLine());
                Console.WriteLine("GPA: " + students[studentNumber2 - 1].CalculateGPA()); break;
            case 3:
                Console.WriteLine("Enter student number (1-10): ");
                int studentNumber3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Maximum grade: " + students[studentNumber3 - 1].GetMaxGrade());
                break;
            case 4:
                Console.WriteLine("Enter student number (1-10): ");
                int studentNumber4 = int.Parse(Console.ReadLine());
                Console.WriteLine("Minimum grade: " + students[studentNumber4 - 1].GetMinGrade());
                break;
            case 5:
                Console.WriteLine("Overall maximum grade: " + Student.GetMaxGrade(students));
                break;
            case 6:
                Console.WriteLine("Overall minimum grade: " + Student.GetMinGrade(students));
                break;
            case 7:
                Array.Sort(students, (s1, s2) => s1.name.CompareTo(s2.name));
                Console.WriteLine("Sorted list of students:");
                foreach (Student s in students)
                {
                    Console.WriteLine(s.name);
                }
                break;
            case 8:
                Console.WriteLine("Enter student ID: ");
                int studentID = int.Parse(Console.ReadLine());
                for (int i = 0; i < 10; i++)
                {
                    if (students[i].studentID == studentID)
                    {
                        students[i].Display();
                        break;
                    }
                }
                break;
            default:
                Console.WriteLine("Invalid operation.");
                break;
        }
        Console.ReadKey();
    }
}