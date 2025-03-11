using System;

namespace clistub
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { "-name", "Michael", "-age", "68" };
            string output = $"Paramters: -name: {args[1]}  -age is {args[3]}.";
            Console.WriteLine(output);
        }
    }
}