using System;
using System.Collections.Generic;
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
            this.familyMembers.Add(newMember);
        }

        public Person GetOldestMember(List<Person> family)
        {
            Person oldestOne = new Person();

            foreach (var member in family)
            {
                if (member.Age >= oldestOne.Age)
                {
                    oldestOne = member;
                }
            }

            return oldestOne ;
        }
    }
}
