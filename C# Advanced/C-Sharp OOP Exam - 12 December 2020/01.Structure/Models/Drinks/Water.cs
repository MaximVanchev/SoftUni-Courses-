﻿
namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        public const decimal WaterPrice = 1.50M;
        public Water(string name, int portion, string brand)
            : base(name, portion, WaterPrice, brand)
        { }
    }
}
