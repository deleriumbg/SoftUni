using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentInput = Console.ReadLine().Split();
                string studentFirstName = studentInput[0];
                string studentLastName = studentInput[1];
                string faculcyNumber = studentInput[2];
                Student student = new Student(studentFirstName, studentLastName, faculcyNumber);

                string[] workerInput = Console.ReadLine().Split();
                string workerFirstName = workerInput[0];
                string workerLastName = workerInput[1];
                decimal weeklySalary = decimal.Parse(workerInput[2]);
                double workHoursPerDay = double.Parse(workerInput[3]);
                Worker worker = new Worker(workerFirstName, workerLastName, weeklySalary, workHoursPerDay);

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (Exception argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
