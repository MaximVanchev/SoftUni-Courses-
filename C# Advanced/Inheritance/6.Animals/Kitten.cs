﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
            : base(name, age, gender)
        {

        }
        public override string Gender { get => "Female";}
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
