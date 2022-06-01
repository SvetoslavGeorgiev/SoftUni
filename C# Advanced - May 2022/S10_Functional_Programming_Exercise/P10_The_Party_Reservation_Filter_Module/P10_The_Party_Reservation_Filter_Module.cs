using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_The_Party_Reservation_Filter_Module
{
    public class P10_The_Party_Reservation_Filter_Module
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<Filter> filters = new List<Filter>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                var tokens = input.Split(';');
                string action = tokens[0];
                string typeOfTheFilter = tokens[1];
                string conditionOfTheFilter = tokens[2];

                Filter currentFilter = new Filter(typeOfTheFilter, conditionOfTheFilter);

                
                switch (action)
                {
                    case "Add filter":
                        filters.Add(currentFilter);
                        break;
                    case "Remove filter":
                        filters.RemoveAll(filter =>
                            filter.Type == typeOfTheFilter &&
                            filter.Condition == conditionOfTheFilter);
                        break;
                }

                
            }

            List<string> filteredNames = RemovePeople(filters, names);
            Console.WriteLine(string.Join(' ', names));
        }

        public class Filter
        {
            public Filter(string typeOfTheFilter, string conditionOfTheFilter)
            {
                Type = typeOfTheFilter;
                Condition = conditionOfTheFilter;

            }
            public string Type { get; set; }

            public string Condition { get; set; }
        }


        public static List<string> RemovePeople(List<Filter> filters, List<string> names)
        {

            foreach (var filter in filters)
            {
                switch (filter.Type)
                {
                    case "Starts with":
                        names.RemoveAll(name => name.StartsWith(filter.Condition));
                        break;
                    case "Ends with":
                        names.RemoveAll(name => name.EndsWith(filter.Condition));
                        break;
                    case "Length":
                        names.RemoveAll(name => name.Length == int.Parse(filter.Condition));
                        break;
                    case "Contains":
                        names.RemoveAll(name => name.Contains(filter.Condition));
                        break;
                }
            }

            return names;
        }
    }
}
