using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine());

            double comission = 0;

            if (sales >= 0 && sales <= 500)
            {
                switch (town)
                {
                    case "sofia":
                        comission = sales * 0.05;
                        break;
                    case "varna":
                        comission = sales * 0.045;
                        break;
                    case "plovdiv":
                        comission = sales * 0.055;
                        break;
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                switch (town)
                {
                    case "sofia":
                        comission = sales * 0.07;
                        break;
                    case "varna":
                        comission = sales * 0.075;
                        break;
                    case "plovdiv":
                        comission = sales * 0.08;
                        break;
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                switch (town)
                {
                    case "sofia":
                        comission = sales * 0.08;
                        break;
                    case "varna":
                        comission = sales * 0.1;
                        break;
                    case "plovdiv":
                        comission = sales * 0.12;
                        break;
                }
            }
            else if (sales > 10000)
            {
                switch (town)
                {
                    case "sofia":
                        comission = sales * 0.12;
                        break;
                    case "varna":
                        comission = sales * 0.13;
                        break;
                    case "plovdiv":
                        comission = sales * 0.145;
                        break;
                }
            }
            if (comission != 0)
            {
                Console.WriteLine(comission.ToString("0.00"));
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
