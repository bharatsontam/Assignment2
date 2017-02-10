using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of students you want to create:");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());
            Student[] studentArray = Student.GetStudentArray(numberOfStudents);
            for (short i = 0; i < numberOfStudents; i++)
            {
                studentArray[i] = new Student();
                studentArray[i].Id = i + 1;
                Console.WriteLine("Enter Student First Name for student {0}:", i + 1);
                studentArray[i].FirstName = Console.ReadLine();
                Console.WriteLine("Enter Student Last Name for student {0}:", i + 1);
                studentArray[i].LastName = Console.ReadLine();
                Console.WriteLine("Enter Student DOB for student {0}:(yyyy/mm/dd)", i + 1);
                studentArray[i].DOB = Convert.ToDateTime(Console.ReadLine());
            }

            ArrayList oddStudentArrayList = new ArrayList();
            ArrayList eventStudentArrayList = new ArrayList();
            foreach (var student in studentArray)
            {
                int age = student.GetStudentAge();
                if (age % 2 == 0)
                {
                    eventStudentArrayList.Add(student);
                }
                else if (age % 2 != 0)
                {
                    oddStudentArrayList.Add(student);
                }
            }

            Hashtable studentHasTable = new Hashtable();
            studentHasTable.Add("EvenAgeStudents", eventStudentArrayList);
            studentHasTable.Add("OddAgeStudents", oddStudentArrayList);
            Console.WriteLine("-----------------------------------------------------");
            foreach (DictionaryEntry entry in studentHasTable)
            {
                Console.WriteLine(entry.Key + ":");
                ArrayList list = (ArrayList)entry.Value;
                foreach (var student in list)
                {
                    var _student = (Student)student;
                    Console.WriteLine("FullName : {0} {1} \n DOB: {2}",_student.FirstName,_student.LastName,_student.DOB.ToShortDateString());
                    Console.WriteLine("-----------------------------------------------------");
                }
                Console.WriteLine("-----------------------------------------------------");
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public static Student[] GetStudentArray(int numberOfStudents)
        {
            Student[] studentArray = new Student[numberOfStudents];
            return studentArray;
        }

        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int GetStudentAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - this.DOB.Year;

            if (now.Month < this.DOB.Month || (now.Month == this.DOB.Month && now.Day < this.DOB.Day))
                age--;

            return age;
        }
    }
}
