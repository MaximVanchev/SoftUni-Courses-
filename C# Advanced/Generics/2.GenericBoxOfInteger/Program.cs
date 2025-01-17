﻿using System;
using System.Collections.Generic;

namespace _1._Generic_Box_of_String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Box<int> newBox = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(newBox);
            }
            foreach (var item in boxes)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
