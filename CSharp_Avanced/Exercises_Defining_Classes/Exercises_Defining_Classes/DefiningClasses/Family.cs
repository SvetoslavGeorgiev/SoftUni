using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.FamilyMembers = new List<Person>();
        }


        private List<Person> familyMembers;


        public List<Person> FamilyMembers { get; set; }


        public void AddMember(Person newMember)
        {
            this.FamilyMembers.Add(newMember);
        }

        public void GetAllMembersOver30(List<Person> family)
        {
            family.Where(m => m.Age > 30).OrderBy(m => m.Name).ToList().ForEach(m => Console.WriteLine($"{m.Name} - {m.Age}"));

        }
    }
}
