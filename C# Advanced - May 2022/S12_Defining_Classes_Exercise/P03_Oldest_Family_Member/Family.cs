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
            FamilyMembers = new List<Person>();
        }

        public Family(List<Person> familyMemvers)
        {
            FamilyMembers = familyMemvers;
        }


        private List<Person> familyMembers;

        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person newMember)
        {
            FamilyMembers.Add(newMember);
        }
        public Person GetOldestMember()
        {
            return  FamilyMembers.OrderByDescending(x => x.Age).FirstOrDefault();

        }

    }
}
