﻿

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
