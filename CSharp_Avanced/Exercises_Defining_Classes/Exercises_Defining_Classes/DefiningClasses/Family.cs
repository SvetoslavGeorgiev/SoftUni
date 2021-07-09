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

        public Person GetOldestMember()
        {
            Person oldestOne = FamilyMembers.OrderByDescending(x => x.Age).FirstOrDefault();

            //foreach (var member in family)
            //{
            //    if (member.Age >= oldestOne.Age)
            //    {
            //        oldestOne = member;
            //    }
            //}

            return oldestOne ;
        }
    }
}
