using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDndgame.Properties.Classes
{
    public partial class Enemy
    {
        public string Name { get; }
        public double BaseDmg { get; }
        public double Hp { get; private set; }

        public Enemy(string name, double baseDmg, double hp)
        {
            Name = name;
            BaseDmg = baseDmg;
            Hp = hp;
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} is Attacking you!");
            Console.WriteLine($"you took {BaseDmg} DMG");
            player.TakeDmg(BaseDmg);
        }

        public void TakeDmg(double dmg)
        {
            Hp -= dmg;
            if (Hp < 0) Hp = 0; 
            Console.WriteLine($"{Name} Has now {Hp} HP.");
        }

        public static partial class Factory
        {
            public static Enemy CreateDog()
            {
                return new Enemy("Angry dog", 10, 15);
            }
            public static Enemy CreateGoblin()
            {
                return new Enemy("Goblin", 7, 20);
            }
            public static Enemy Createtrap()
            {
                return new Enemy("trap", 20, 20);
            }

            public static Enemy CreateMedusa()
            {
                return new Enemy("Medusa - kill it or you die", 99999, 5);
            }
            public static Enemy CreateOger()
            {
                return new Enemy("Oger", 5, 50);
            }
            public static Enemy CreateBoss()
            {
                return new FinalBoss("Grolog the destoryer", 25, 100);
            }
        }
    }
}
