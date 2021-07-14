using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace PearlPoet173377.Hometask_01
{
    interface IWorker
    {
        public string Name { get; }
    }
    public class Team
    {
        public Team(List<Worker> w)
        {
            WS = w;
        }
        public Team(List<Worker> w, TeamLeader tl)
        {
            WS = w;
            TL = tl;
        }

        public TeamLeader TL { get; set; }
        public List<Worker> WS { get; set; }
        public List<string> report = new List<string>();

        public string GetName()
        {
            string name = "";
            foreach (var i in WS)
            {
                name = i.Name;
            }
            return name;
        }
    }
    public class Worker : IWorker
    {
        public Worker(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        string IWorker.Name => Name;
    }
    public class TeamLeader : IWorker
    {
        public TeamLeader(string name)
        {
            Name = name;
        }

        public static string Name { get; set; }
        string IWorker.Name => Name;
    }
}