namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Mission
    {

        private string codeName;
        private string missionState;

        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }


        public string MissionState
        {
            get => missionState;
            private set 
            { 
                missionState = value; 
            }
        }


        public string CodeName
        {
            get { return codeName; }
            private set 
            { 
                codeName = value; 
            }
        }

        public void CompleteMission(string newMissionName)
        {
            if (codeName == newMissionName)
            {
                missionState = "Finished";
            }
        }
        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {MissionState}";
        }
    }
}
