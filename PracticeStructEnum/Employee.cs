using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStructEnum
{
    public struct Employee
    {
        public string Name { get; set; }
        public Positions Post { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfEngagement { get; set; }
        
        public Employee(string name, Positions post, int salary, DateTime dateOfEngagement)
        {
            Name = name;
            Post = post;
            Salary = salary;
            DateOfEngagement = dateOfEngagement;
        }
        public void Show()
        {
            Console.Write($"Name: {Name}" +
                $"\nPosition: {Post}" +
                $"\nSalary: {Salary}" +
                $"\nDateOfEngagement: {DateOfEngagement.ToString("dd-MM-yyyy")}");
        }
    }
}
