namespace Raiding.Engine
{
    using System;
    using System.Collections.Generic;
    using Models;
    public class StartUp
    {
        static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());
            var raid = new Raid(capacity);

            BaseHero hero = null;
            Command command = new Command();

            while (capacity > raid.Heroes.Count)
            {
                command.HeroName = Console.ReadLine();
                command.HeroType = Console.ReadLine();

                try
                {
                    if (command.HeroType == Constants.DruidType)
                    {
                        hero = new Druid(command.HeroName);
                        raid.AddHero(hero);
                    }
                    else if (command.HeroType == Constants.PaladinType)
                    {
                        hero = new Paladin(command.HeroName);
                        raid.AddHero(hero);
                    }
                    else if (command.HeroType == Constants.RogueType)
                    {
                        hero = new Rogue(command.HeroName);
                        raid.AddHero(hero);
                    }
                    else if (command.HeroType == Constants.WarriorType)
                    {
                        hero = new Warrior(command.HeroName);
                        raid.AddHero(hero);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }

            var bossPower = int.Parse(Console.ReadLine());

            raid.ForEach();
            Console.WriteLine(raid.GetWinOrLose(bossPower));


        }
    }
}
