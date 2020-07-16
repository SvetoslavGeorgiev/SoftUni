﻿using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            var vipMembers = new HashSet<string>();
            var members = new HashSet<string>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(command[0]))
                {
                    vipMembers.Add(command);
                }
                else
                {
                    members.Add(command);
                }
            }

            while (command != "END")
            {

                vipMembers.Remove(command);
                members.Remove(command);
                command = Console.ReadLine();
            }

            var notCome = vipMembers.Count + members.Count;

            Console.WriteLine(notCome);
            foreach (var vipMember in vipMembers)
            {
                Console.WriteLine(vipMember);
            }
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }

        }
    }
}
