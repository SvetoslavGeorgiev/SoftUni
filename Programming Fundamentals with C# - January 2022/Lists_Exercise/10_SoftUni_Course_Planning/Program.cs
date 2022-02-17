using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {

                var tokens = command.Split(':');

                var course = tokens[1];

                if (tokens.Contains("Add"))
                {
                    if (!schedule.Contains(course))
                    {
                        schedule.Add(course);
                    }
                }
                else if (tokens.Contains("Insert"))
                {
                    if (!schedule.Contains(course))
                    {
                        var index = int.Parse(tokens[2]);
                        if (index > schedule.Count - 1)
                        {
                            schedule.Add(course);
                        }
                        else if (index >= 0 && index < schedule.Count)
                        {
                            schedule.Insert(index, course);
                        }
                    }
                }
                else if (tokens.Contains("Remove"))
                {

                    if (schedule.Contains(course))
                    {
                        var index = schedule.FindIndex(x => x.Contains(course));
                        schedule.RemoveAt(index);
                        if (index <= schedule.Count - 1 && schedule[index].Contains(course))
                        {
                            schedule.RemoveAt(index);
                        }
                    }
                }
                else if (tokens.Contains("Swap"))
                {
                    var courseToSwap = tokens[2];
                    if (schedule.Contains(course) && schedule.Contains(courseToSwap))
                    {
                        var indexOfTheFirstCourse = schedule.FindIndex(x => x.Contains(course));

                        var indexOfTheSecondCourse = schedule.FindIndex(x => x.Contains(courseToSwap));

                        if (indexOfTheFirstCourse < indexOfTheSecondCourse)
                        {
                            schedule.RemoveAt(indexOfTheFirstCourse);
                            if (indexOfTheSecondCourse > schedule.Count - 1)
                            {
                                schedule.Add(course);
                            }
                            else
                            {
                                schedule.Insert(indexOfTheSecondCourse, course);
                            }

                            if (schedule[indexOfTheFirstCourse].Contains(course))
                            {
                                var exercise = schedule[indexOfTheFirstCourse];
                                schedule.RemoveAt(indexOfTheFirstCourse);
                                schedule.Insert(indexOfTheSecondCourse, exercise);
                            }
                            indexOfTheSecondCourse = schedule.FindIndex(x => x.Contains(courseToSwap));
                            schedule.RemoveAt(indexOfTheSecondCourse);
                            schedule.Insert(indexOfTheFirstCourse, courseToSwap);
                            for (int i = indexOfTheSecondCourse + 1; i < schedule.Count; i++)
                            {
                                if (schedule[i].Contains(courseToSwap))
                                {
                                    var exercise = schedule[i];
                                    schedule.RemoveAt(i);
                                    schedule.Insert(indexOfTheFirstCourse + 1, exercise);
                                    break;
                                }
                            }

                        }
                        else
                        {

                            schedule.RemoveAt(indexOfTheSecondCourse);
                            if (indexOfTheFirstCourse > schedule.Count - 1)
                            {
                                schedule.Add(courseToSwap);
                            }
                            else
                            {
                                schedule.Insert(indexOfTheFirstCourse, courseToSwap);
                            }

                            if (schedule[indexOfTheSecondCourse].Contains(courseToSwap))
                            {
                                var exercise = schedule[indexOfTheSecondCourse];
                                schedule.RemoveAt(indexOfTheSecondCourse);
                                schedule.Insert(indexOfTheFirstCourse, exercise);
                            }
                            indexOfTheFirstCourse = schedule.FindIndex(x => x.Contains(course));
                            schedule.RemoveAt(indexOfTheFirstCourse);
                            schedule.Insert(indexOfTheSecondCourse, course);
                            for (int i = indexOfTheFirstCourse + 1; i < schedule.Count; i++)
                            {
                                if (schedule[i].Contains(course))
                                {
                                    var exercise = schedule[i];
                                    schedule.RemoveAt(i);
                                    schedule.Insert(indexOfTheSecondCourse + 1, exercise);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (schedule.Contains(course))
                    {
                        var index = schedule.FindIndex(x => x.Contains(course));
                        var exerciseToAdd = $"{course}-Exercise";
                        if (index == schedule.Count - 1)
                        {
                            schedule.Add(exerciseToAdd);
                        }
                        else
                        {
                            if (!schedule[index + 1].Contains("Exercise"))
                            {

                                schedule.Insert(index + 1, exerciseToAdd);

                            }
                        }

                    }
                    else
                    {
                        schedule.Add(course);
                        schedule.Add($"{course}-Exercise");
                    }
                }
            }

            for (int i = 1; i <= schedule.Count; i++)
            {
                Console.WriteLine($"{i}.{schedule[i - 1]}");
            }
        }
    }
}
