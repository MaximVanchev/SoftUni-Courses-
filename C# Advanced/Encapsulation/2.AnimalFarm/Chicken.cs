﻿using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private  const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null || value == "" || value == " ")
                {
                    throw new ArgumentException ("Name cannot be empty.");
                }
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            protected set
            {
                if (value < 0 || value > 15)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                age = value;
            }
        }

        public double ProductPerDay
        {
			get
			{				
				return CalculateProductPerDay();
			}
        }

        private double CalculateProductPerDay()
        {
            switch (Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
