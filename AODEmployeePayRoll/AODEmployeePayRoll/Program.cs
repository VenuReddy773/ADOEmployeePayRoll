using System;

namespace AODEmployeePayRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!!");
            Operations pay = new Operations();
            pay.GetAllEmployees();
            pay.Display();        }
    }
}
