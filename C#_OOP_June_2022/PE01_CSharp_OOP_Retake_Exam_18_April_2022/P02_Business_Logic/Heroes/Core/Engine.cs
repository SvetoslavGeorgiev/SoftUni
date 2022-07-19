namespace Heroes.Core
{
    using System;
    using Heroes.IO;
    using Heroes.IO.Contracts;
    using Heroes.Core.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "CreateHero")
                    {
                        string type = input[1];
                        string name = input[2];
                        int health = int.Parse(input[3]);
                        int armour = int.Parse(input[4]);

                        result = controller.CreateHero(type, name, health, armour);
                    }
                    else if (input[0] == "CreateWeapon")
                    {
                        string weaponType = input[1];
                        string name = input[2];
                        int durability = int.Parse(input[3]);

                        result = controller.CreateWeapon(weaponType, name, durability);
                    }
                    else if (input[0] == "AddWeaponToHero")
                    {
                        string weaponName = input[1];
                        string heroName = input[2];

                        result = controller.AddWeaponToHero(weaponName, heroName);
                    }
                    else if (input[0] == "StartBattle")
                    {
                        result = controller.StartBattle();
                    }
                    else if (input[0] == "HeroReport")
                    {
                        result = controller.HeroReport();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
