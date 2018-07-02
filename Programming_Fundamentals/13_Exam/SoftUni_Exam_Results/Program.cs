using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results 
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> pointsByUser = new Dictionary<string, int>();
            Dictionary<string, int> submissionsByLanguage = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] inputArgs = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                switch (inputArgs.Length)
                {
                    case 3:
                        string userName = inputArgs[0];
                        string language = inputArgs[1];
                        int points = int.Parse(inputArgs[2]);
                        if (!pointsByUser.ContainsKey(userName))
                        {
                            pointsByUser[userName] = points;
                        }
                        else
                        {
                            if (points > pointsByUser[userName])
                            {
                                pointsByUser[userName] = points;
                            }
                        }

                        if (!submissionsByLanguage.ContainsKey(language))
                        {
                            submissionsByLanguage[language] = 0;
                        }
                        submissionsByLanguage[language] += 1;
                        break;
                    case 2:
                        string bannedUser = inputArgs[0];
                        if (pointsByUser.ContainsKey(bannedUser))
                        {
                            pointsByUser.Remove(bannedUser);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var user in pointsByUser.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissionsByLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
