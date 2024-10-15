using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDndgame.Properties.Classes
{
    public class Room
    {
        public string Name { get; private set; }
        public Enemy Enemy { get; set; }

        public Room(string name, Enemy enemy = null)
        {
            Name = name;
            Enemy = enemy;
        }
    }
}
