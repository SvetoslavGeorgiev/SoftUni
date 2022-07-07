namespace MilitaryElite.Engine
{
    using System;
    using Models;


    public class Program
    {
        static void Main()
        {

            var parser = new CommandParser();
            var command = parser.Parse(Console.ReadLine());

            var soldiers = new Soldiers();
            Privates privates = new Privates();

            while (command.Name != "End")
            {

                var id = int.Parse(command.Arguments[0]);
                var firstname = command.Arguments[1];
                var lastName = command.Arguments[2];

                if (command.Name == nameof(Spy))
                {

                    var codeNumber = int.Parse(command.Arguments[3]);

                    Soldier spy = new Spy(id, firstname, lastName, codeNumber);

                    soldiers.AddSoldier(spy);
                }
                else if (command.Name == nameof(Private))
                {
                    var salary = decimal.Parse(command.Arguments[3]);

                    Private newPrivate = new Private(id, firstname, lastName, salary);

                    soldiers.AddSoldier(newPrivate);
                    privates.PrivatesList.Add(newPrivate);

                }
                else if (command.Name == nameof(LieutenantGeneral))
                {

                    var salary = decimal.Parse(command.Arguments[3]);

                    var lieutenantGeneral = new LieutenantGeneral(id, firstname, lastName, salary);

                    for (int i = 4; i < command.Arguments.Length; i++)
                    {
                        foreach (var newPrivate in privates.PrivatesList)
                        {
                            if (int.Parse(command.Arguments[i]) == newPrivate.Id)
                            {
                                lieutenantGeneral.AddPrivateId(newPrivate);
                            }
                        }
                    }
                    soldiers.AddSoldier(lieutenantGeneral);
                }
                else if (command.Name == nameof(Engineer))
                {

                    var salary = decimal.Parse(command.Arguments[3]);
                    if (command.Arguments[4] == "Airforces" || command.Arguments[4] == "Marines")
                    {
                        var corp = command.Arguments[4];

                        var engineer = new Engineer(id, firstname, lastName, salary, corp);

                        if (command.Arguments.Length > 5)
                        {
                            for (int i = 5; i < command.Arguments.Length; i += 2)
                            {
                                var partName = command.Arguments[i];
                                var hoursWorked = int.Parse(command.Arguments[i + 1]);

                                var newRepair = new Repair(partName, hoursWorked);
                                engineer.AddRepair(newRepair);

                            }
                        }
                        soldiers.AddSoldier(engineer);
                    }
                    

                }
                else if (command.Name == nameof(Commando))
                {

                    var salary = decimal.Parse(command.Arguments[3]);
                    if (command.Arguments[4] == "Airforces" || command.Arguments[4] == "Marines")
                    {
                        var corp = command.Arguments[4];

                        var comando = new Commando(id, firstname, lastName, salary, corp);

                        if (command.Arguments.Length > 5)
                        {
                            for (int i = 5; i < command.Arguments.Length; i += 2)
                            {
                                var codeName = command.Arguments[i];
                                var missionState = command.Arguments[i + 1];

                                var newMission = new Mission(codeName, missionState);
                                comando.AddMission(newMission);

                            }
                        }

                        soldiers.AddSoldier(comando);
                    }
                    
                }
                command = parser.Parse(Console.ReadLine());
            }

            foreach (var soldier in soldiers.ListOfSoldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
