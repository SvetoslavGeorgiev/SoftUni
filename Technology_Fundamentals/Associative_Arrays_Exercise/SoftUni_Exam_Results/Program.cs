using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            
            
            var laguageAndSubmissions = new Dictionary<string, int>();
            var user = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "exam finished")
            {

                if (!command.Contains("banned"))
                {
                    var splittedCommand = command.Split("-");

                    var name = splittedCommand[0];
                    var language = splittedCommand[1];
                    var points = int.Parse(splittedCommand[2]);

                    if (!laguageAndSubmissions.ContainsKey(language))
                    {
                        laguageAndSubmissions.Add(language, 1);
                    }
                    else
                    {
                        laguageAndSubmissions[language]++;
                    }

                    if (!user.ContainsKey(name))
                    {
                        user.Add(name, new Dictionary<string, int>());
                        user[name].Add(language, points);
                    }
                    else
                    {
                        if (!user[name].ContainsKey(language))
                        {
                            user[name].Add(language, points);
                        }
                        else
                        {
                            if (user[name][language] < points)
                            {
                                user[name][language] = points;
                            }
                        }
                    }
                }
                else
                {
                    var splittedCommand = command.Split("-");


                    var name = splittedCommand[0];

                    if (user.ContainsKey(name))
                    {
                        user.Remove(name);
                    }

                }
            }
            Console.WriteLine("Results:");
            foreach (var kvp in user.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key))
            {
                foreach (var point in kvp.Value)
                {
                    Console.WriteLine($"{kvp.Key} | {point.Value}");
                }
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in laguageAndSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
