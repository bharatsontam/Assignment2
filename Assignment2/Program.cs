using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Value of Monday: " + (int)Weekdays.Monday);

            Console.WriteLine(Enum.GetName(typeof(Weekdays), 3));

            foreach (string str in Enum.GetNames(typeof(Weekdays)))
            {
                Console.WriteLine(str);
            }

            Employee emp1 = new Employee();
            Console.WriteLine("Enter employee firstname: ");
            emp1.FirstName = Console.ReadLine();
            Console.WriteLine("Enter employee Lastname: ");
            emp1.LastName = Console.ReadLine();
            Console.WriteLine("Enter employee type from the following types: ");
            Console.WriteLine(string.Join(",", Enum.GetNames(typeof(EmployeeType)).ToList()));
            
            emp1.Type = (EmployeeType)Enum.Parse(typeof(EmployeeType), Console.ReadLine());
            Console.WriteLine("-----------------------");
            Console.WriteLine("Entered Employee details are as follows: ");
            Console.WriteLine(string.Format("Full Name={0} {1}, EmployeeType={2}", emp1.FirstName, emp1.LastName, emp1.Type));



            Console.ReadKey();
        }
    }

    enum Weekdays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum EmployeeType
    {
        Trainee,
        FullTime,
        ContractToDirectHire,
        CorpToCorp
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType Type { get; set; }
    }
}
