using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning 
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commandInput = Console.ReadLine();

            while (commandInput != "course start")
            {
                string[] commandArgs = commandInput.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commandArgs[0])
                {
                    case "Add":
                        string lessonTitle = commandArgs[1];
                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        string lessonTitleToInsert = commandArgs[1];
                        int indexToInsert = int.Parse(commandArgs[2]);
                        if (indexToInsert >= 0 && indexToInsert <= lessons.Count)
                        {
                            if (!lessons.Contains(lessonTitleToInsert))
                            {
                                lessons.Insert(indexToInsert, lessonTitleToInsert);
                            }
                        }
                        break;
                    case "Remove":
                        string lessonTitleToRemove = commandArgs[1];
                        if (lessons.Contains(lessonTitleToRemove))
                        {
                            lessons.Remove(lessonTitleToRemove);
                            if (lessons.Contains($"{lessonTitleToRemove}-Exercise"))
                            {
                                lessons.Remove($"{lessonTitleToRemove}-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        string firstLessonToSwap = commandArgs[1];
                        string secondLessonToSwap = commandArgs[2];
                        if (lessons.Contains(firstLessonToSwap) && lessons.Contains(secondLessonToSwap))
                        {
                            Swap(lessons, lessons.IndexOf(firstLessonToSwap), lessons.IndexOf(secondLessonToSwap));
                            if (lessons.Contains($"{firstLessonToSwap}-Exercise") && lessons.Contains($"{secondLessonToSwap}-Exercise"))
                            {
                                Swap(lessons, lessons.IndexOf($"{firstLessonToSwap}-Exercise"), lessons.IndexOf($"{secondLessonToSwap}-Exercise"));
                            }
                            else if (lessons.Contains($"{firstLessonToSwap}-Exercise") && lessons.Contains(firstLessonToSwap))
                            {
                                int indexOfFirstLesson = lessons.IndexOf(firstLessonToSwap);
                                lessons.Remove($"{firstLessonToSwap}-Exercise");
                                lessons.Insert(indexOfFirstLesson + 1, $"{firstLessonToSwap}-Exercise");
                            }
                            else if (lessons.Contains($"{secondLessonToSwap}-Exercise") && lessons.Contains(secondLessonToSwap))
                            {
                                int indexOfSecondLesson = lessons.IndexOf(secondLessonToSwap);
                                lessons.Remove($"{secondLessonToSwap}-Exercise");
                                lessons.Insert(indexOfSecondLesson + 1, $"{secondLessonToSwap}-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        string lessonToAddExercise = commandArgs[1];
                        if (lessons.Contains(lessonToAddExercise) && !lessons.Contains($"{lessonToAddExercise}-Exercise"))
                        {
                            int indexOfLesson = lessons.IndexOf(lessonToAddExercise);
                            lessons.Insert(indexOfLesson + 1, $"{lessonToAddExercise}-Exercise");
                        }
                        if (!lessons.Contains(lessonToAddExercise))
                        {
                            lessons.Add(lessonToAddExercise);
                            lessons.Add($"{lessonToAddExercise}-Exercise");
                        }
                        break;
                }

                commandInput = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        public static void Swap(List<string> list, int indexA, int indexB)
        {
            if (indexA >= 0 && indexA < list.Count && indexB >= 0 && indexB < list.Count)
            {
                string temp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = temp;
            }
        }
    }
}
