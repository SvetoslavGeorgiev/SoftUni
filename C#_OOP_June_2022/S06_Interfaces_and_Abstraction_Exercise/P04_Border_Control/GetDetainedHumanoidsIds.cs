namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class GetDetainedHumanoidsIds
    {
        public DetainedHumanoidsIds GetDetainedIds(List<Humanoid> humanoids, string lastDigitsOfFakeIds)
        {
            var listOfDetainedIds = new List<string>();
            foreach (var humanoid in humanoids)
            {
                
                if (humanoid.Id.EndsWith(lastDigitsOfFakeIds))
                {
                    listOfDetainedIds.Add(humanoid.Id);
                }
            }

            return new DetainedHumanoidsIds
            {
                IDsOfTheDetained = listOfDetainedIds
            };
        }
    }
}
