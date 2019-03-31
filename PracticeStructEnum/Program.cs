using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeCount = 0;
            SortedList<string, int> PostAndCount = new SortedList<string, int>();

            Console.Write("Введите количество сотрудников:\n\n");
            
            foreach (var item in Enum.GetNames(typeof(Positions)))
            {
                Console.Write($"{item}: ");
                if(item == (Positions.Boss).ToString())
                {
                    PostAndCount.Add(item, 1);
                    Console.WriteLine(PostAndCount[item]);
                    employeeCount += PostAndCount[item];
                    continue;
                }
                PostAndCount.Add(item, int.Parse(Console.ReadLine()));
                employeeCount += PostAndCount[item];
            }
            
            Employee[] employees = new Employee[employeeCount];
            DataEntry(employees, PostAndCount);

            while (true)
            {
                Console.Write("Выберите необходимую информацию" +
                "\n1) Полная информация о сотрудниках" +
                "\n2) Менеджеры, зарплата которых больше ср. зарплаты клерков" +
                "\n3) Сотрудники принятые на работу позже босса" +
                "\n\nВыбор: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1: // Полная информация о сотрудниках
                        for (int i = 0; i < employees.Length; i++)
                        {
                            employees[i].Show();
                            Console.WriteLine("\n");
                        }
                        break;
                    case 2: // Менеджеры, зарплата которых больше ср. зарплаты клерков
                        TopManagers(employees, PostAndCount[(Positions.Clerk).ToString()]);
                        break;
                    case 3:  // Сотрудники принятые на работу позже босса
                        WorkersEngagedAfterBoss(employees, employees[0].DateOfEngagement);
                        break;
                    default:
                        Console.WriteLine("Ошибочный выбор! Введите заново...");
                        break;
                }
                Console.Write("Нажмите Enter чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            } 
        }
        public static void DataEntry(Employee[] employees, SortedList<string, int> PostAndCount)
        {
            int iterator = 0;
            for (int i = 0; i < PostAndCount.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("Введите данные  сотрудника");
                for (int j = 0; j < PostAndCount[((Positions)i).ToString()]; j++)
                {
                    Console.Write($"\nДолжность:\t{(Positions)i}\n"); employees[iterator].Post = (Positions)i;
                    Console.Write("Полное имя:\t"); employees[iterator].Name = Console.ReadLine();
                    Console.Write("Зарплата:\t"); employees[iterator].Salary = int.Parse(Console.ReadLine());
                    Console.Write("Дата приема\n(dd.mm.yyyy):\t"); employees[iterator].DateOfEngagement = DateTime.Parse(Console.ReadLine());
                    iterator++;
                }
                Console.WriteLine();
            }
        }
        public static void TopManagers(Employee[] employees, int clerksCount)
        {
            int totalClerkSalary = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Post == Positions.Clerk)
                {
                    totalClerkSalary += employees[i].Salary;
                }
            }
            double averageClerkSalary = totalClerkSalary / clerksCount;
            
            Array.Sort(employees, new SortByName());
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Post == Positions.Manager)
                    if (employees[i].Salary > averageClerkSalary)
                    {
                        employees[i].Show();
                        Console.WriteLine("\n");
                    }
            }
        }
        public static void WorkersEngagedAfterBoss(Employee[] employees, DateTime bossDateOfEngagement)
        {
            Array.Sort(employees, new SortByName());
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].DateOfEngagement > bossDateOfEngagement)
                    employees[i].Show();
                Console.WriteLine("\n");
            }
        }
    }
}
