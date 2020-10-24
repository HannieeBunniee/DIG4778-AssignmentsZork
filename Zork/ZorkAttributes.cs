using System;
using System.Collections.Generic;

namespace Zork
{
    //[AttributeUsage(AttributeTargets.Class)]

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandClassAttribute: Attribute
    {
        public string CommandName { get; }
        public IEnumerable<string> Verbs { get; }

        public CommandClassAttribute(string commandName, string verb) :
            this (commandName, new string[] { verb })
        {

        }

        public CommandClassAttribute(string commandName, string[] verbs)
        {
            CommandName = commandName;
            Verbs = verbs;
        }
    }
}
