using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlPoet173377.Hometask_01
{
    interface IPart
    {
        void Do(House house);
    }
    public class House
    {
        public Basement basement;
        public Door door;
        public Roof roof;
        public List<Walls> walls;
        public List<Window> window;

        public void Build(House house, Team team)
        {
            if (house.basement == null)
            {
                Basement basement = new Basement();
                basement.Do(house);
                team.report.Add($"Builder {team.GetName()} made fundation!");
            }

            else if (house.walls == null || house.walls.Count < 4)
            {
                if (house.walls == null) house.walls = new List<Walls>();
                Walls wall = new Walls();
                wall.Do(house);
                team.report.Add($ "Builder {team.GetName()} made walls {house.walls.Count}!");
            }

            else if (house.door == null)
            {
                Door door = new Door();
                door.Do(house);
                team.report.Add($"Builder {team.GetName()} put walls {house.walls.Count}!");
            }

            else if (house.window == null || house.window.Count < 4)
            {
                if (house.window == null) house.window = new List<Window>();
                Window window = new Window();
                window.Do(house);
                team.report.Add($"Builder {team.GetName()} put window in wall {house.window.Count}!");
            }

            else if (house.roof == null)
            {
                Roof roof = new Roof();
                roof.Do(house);
                team.report.Add($"Builder {team.GetName()} made roof!");
            }

        }
    }
    public class Basement : IPart
    {
        public void Do(House house)
        {
            house.basement = new Basement();
        }
    }
    public class Walls : IPart
    {
        public void Do(House house)
        {
            house.walls.Add(new Walls());
        }
    }
    public class Door : IPart
    {
        public void Do(House house)
        {
            house.door = new Door();
        }
    }
    public class Window : IPart
    {
        public void Do(House house)
        {
            house.window.Add(new Window());
        }
    }
    public class Roof : IPart
    {
        public void Do(House house)
        {
            house.roof = new Roof();
        }
    }
}