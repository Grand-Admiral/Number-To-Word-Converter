using System;
using ConverterLibrary;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine(Class1.ConvertNumbersToWords(a.ToString()));

            }
        }
    }
}
