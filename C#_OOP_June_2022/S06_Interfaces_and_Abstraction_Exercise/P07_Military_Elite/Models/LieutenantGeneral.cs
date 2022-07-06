namespace MilitaryElite.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class LieutenantGeneral : Soldier, ILieutenantGeneral
    {
        private readonly List<Private> privates  = new List<Private>();
        static int[] privateIds;
        public LieutenantGeneral(int id, string firstName, string lastName, params int[] privates) : base(id, firstName, lastName)
        {
            privateIds = privates;
        }
        private IReadOnlyList<Private> FindingAndAddingPrivatesToLieutanatControl(int[] privates)
        {
            foreach (var item in collection)
            {

            }
        }

        public IReadOnlyList<Private> Privates
        {
            get => FindingAndAddingPrivatesToLieutanatControl(privateIds);
        }

    }
}
