﻿namespace Gym.Models.Equipment
{
    using Gym.Models.Equipment.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {
            this.weight = weight;
            this.price = price;
        }

        public double Weight => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}