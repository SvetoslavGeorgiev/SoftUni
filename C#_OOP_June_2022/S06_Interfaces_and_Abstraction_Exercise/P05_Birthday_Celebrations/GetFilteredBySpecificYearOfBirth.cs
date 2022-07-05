using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class GetFilteredBySpecificYearOfBirth
    {

        public ListOfFilteredBySpecificYear Filter(List<Humanoid> humanoids, string lastDigitsOfFakeIds)
        {
            var listOfDetainedIds = new List<string>();
            foreach (var humanoid in humanoids)
            {

                if (humanoid.Birthdate.EndsWith(lastDigitsOfFakeIds))
                {
                    listOfDetainedIds.Add(humanoid.Birthdate);
                }
            }

            return new ListOfFilteredBySpecificYear
            {
                specifiedListOfBirthdates = listOfDetainedIds
            };
        }

    }
}
