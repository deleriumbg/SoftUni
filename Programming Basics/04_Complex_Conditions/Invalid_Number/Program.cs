﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number >= 100 && number <= 200)
            {}
            else if (number == 0)
            {}
            else
                Console.WriteLine("invalid");
        }
    }
}
