using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main()
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine("Sum: " + numbers.Sum());

            //TODO: Print the Average of numbers

            Console.WriteLine("Average: " + numbers.Average());

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine();
            Console.WriteLine("Numbers Ascending: ");
            numbers.OrderBy(number => number).ToList().ForEach(number => Console.WriteLine(number));

            //TODO: Order numbers in decsending order adn print to the console

            Console.WriteLine();
            Console.WriteLine("Numbers Descending: ");
            numbers.OrderByDescending(number => number).ToList().ForEach(number => Console.WriteLine(number));

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine();
            Console.WriteLine("Numbers greater than 6: ");
            numbers.Where(number => number > 6).ToList().ForEach(number => Console.WriteLine(number));

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine();
            Console.WriteLine("Only 4 numbers: ");
            var fourNumbers = numbers.Where(number => number < 4).OrderBy(number => number).ToList();
            foreach (var number in fourNumbers)
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine();
            Console.WriteLine("Descending with my age: ");
            numbers.SetValue(24, numbers[4]);
            numbers.OrderByDescending(number => number).ToList().ForEach(number => Console.WriteLine(number));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine();
            Console.WriteLine("All employee names that start with C or S: ");
            employees.Where(employee => employee.FirstName.StartsWith("C") || employee.FirstName.StartsWith("S"))
                .OrderBy(employee => employee.FirstName).ToList()
                .ForEach(number => Console.WriteLine(number.FullName));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine();
            Console.WriteLine("All employees over the age 26 sorted by age then by first name: ");
            employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age)
                .ThenBy(employee => employee.FirstName).ToList()
                .ForEach(employee => Console.WriteLine($"Name: {employee.FullName} \nAge : {employee.Age}"));
            


            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine();
            var sortedEmployees = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine($"YOE SUM of employees who have less than 10 YOE and Age is greater than 35: {sortedEmployees.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine();

            Console.WriteLine($"YOE AVERAGE of employees who have less than 10 YOE and Age is greater than 35: {sortedEmployees.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()

            var newEmployee = new Employee()
            {
                FirstName = "Joel",
                LastName = "K",
                Age = 24,
                YearsOfExperience = 1
            };

            Console.WriteLine("Adding myself to end of list not using .Add(): ");
            employees.Append(new Employee()
            {
                FirstName = "Joel",
                LastName = "K",
                Age = 24,
                YearsOfExperience = 1
            }).ToList().ForEach(employee => Console.WriteLine($"Full Name: {employee.FullName} \nAge: {employee.Age} \nYOE: {employee.YearsOfExperience}"));
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
