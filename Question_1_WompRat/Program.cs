using System;

namespace Question_1_WompRat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 500; i++)
            {
                if (i % 5 == 0 && i % 7 == 0)
                {
                    Console.WriteLine("WompRat");
                }
                else
                if (i % 7 == 0)
                {
                    Console.WriteLine("Rat");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Womp");
                }
                else
                    Console.WriteLine(i);
            }
        }
    }
}
