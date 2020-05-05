using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, int>>();

            string contestInput = Console.ReadLine();
            while (contestInput != "end of contests")
            {
                string[] contestInfo = contestInput.Split(':');
                string contestName = contestInfo[0];
                string contestPassword = contestInfo[1];
                contests.Add(contestName, contestPassword);

                contestInput = Console.ReadLine();
            }

            string submissionsInput = Console.ReadLine();
            while (submissionsInput != "end of submissions")
            {
                string[] submissionInfo = submissionsInput.Split("=>");
                string contest = submissionInfo[0];
                string password = submissionInfo[1];
                string student = submissionInfo[2];
                int points = int.Parse(submissionInfo[3]);

                if (ContainsKeyValue(contests, contest, password))
                {
                    if (!students.ContainsKey(student))
                    {
                        students.Add(student, new Dictionary<string, int>());
                    }

                    if (!students[student].ContainsKey(contest))
                    {
                        students[student].Add(contest, points);
                    }

                    if (students[student][contest] < points)
                    {
                        students[student][contest] = points;
                    }
                }

                submissionsInput = Console.ReadLine();
            }


            var bestStudent = students.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();
            Console.WriteLine($"Best candidate is {bestStudent.Key} with total {bestStudent.Value.Values.Sum()} points.\r\nRanking: ");

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        public static bool ContainsKeyValue(Dictionary<string, string> dictionary,
            string expectedKey, string expectedValue)
        {
            return dictionary.TryGetValue(expectedKey, out string actualValue) &&
                   actualValue == expectedValue;
        }
    }
}
