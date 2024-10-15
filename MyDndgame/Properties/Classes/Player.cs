using MyDndgame.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDndgame.Properties.Classes
{
    public class Player
    {
        public string Name { get; }
        public double BaseDmg { get; set; }
        public double Hp { get; private set; }

        public Player(string name, double baseDmg, double hp)
        {
            Name = name;
            BaseDmg = baseDmg;
            Hp = hp;
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"You successfully attacked {enemy.Name} with dmg {BaseDmg}.");
            enemy.TakeDmg(BaseDmg);
        }

        public void Heal()
        {
            Console.WriteLine("what magic do you want to use to heal you:) ");
            Console.WriteLine("You can use: (1. quickheal - 5hp, 2. normalheal - 15hp, 3. phoenixmagicarray - 30hp) ");
            int heal = Convert.ToInt32(Console.ReadLine());
            switch (heal)
            {
                case 1:
                    Hp += (int)HealingMagic.quickheal;
                    break;
                case 2:
                    Hp += (int)HealingMagic.normalheal;
                    break;
                case 3:
                    Hp += (int)HealingMagic.phoenixmagicarray;
                    break;
                default:
                    Console.WriteLine("Nauč se psát lol");
                    break;
            }
            Console.WriteLine($"HP:{Hp}");
        }
        public void Strength()
        {
            Console.WriteLine("Strength Potions in stock:");
            Console.WriteLine("Shop: 1. angerissues(not recomenned), 2. wrath, 3. rage, 4. randomwhitepowder(Where did you get this stuf), 5. HlousekValoCarry(cap)");
            int strength = Convert.ToInt32(Console.ReadLine());
            switch (strength)
            {
                case 1:
                    BaseDmg += (int)StrengthPot.angerissues;
                    break;
                case 2:
                    BaseDmg += (int)StrengthPot.wrath;
                    break;
                case 3:
                    BaseDmg += (int)StrengthPot.rage;
                    break;
                case 4:
                    BaseDmg += (int)StrengthPot.randomwhitepowder;
                    break;
                case 5:
                    BaseDmg += (int)StrengthPot.HlousekValoCarry;
                    break;
                default:
                    Console.WriteLine("Nauč se psát lol");
                    break;
            }
            Console.WriteLine($"U used a strength potion. Your dmg is now {BaseDmg}!");
        }
        public void TakeDmg(double damage)
        {
            Hp -= damage;
            if (Hp < 0) Hp = 0; 
            Console.WriteLine($"{Name} has now {Hp} HP.");
        }
    }
}
