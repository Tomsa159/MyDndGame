using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDndgame.Properties.Classes
{
    public partial class Enemy
    {

        public static partial class Factory
        {
            private class FinalBoss : Enemy
            {
                private int phase = 1;

                public FinalBoss(string name, double baseDmg, double hp) : base(name, baseDmg, hp) { }

                public void Attack(Player player)
                {
                    if (phase == 1)
                    {
                        AttackPhaseOne(player);
                    }
                    else
                    {
                        AttackPhaseTwo(player);
                    }
                }
                private void ToPhaseTwo()
                {
                    phase = 2;
                    Console.WriteLine($"Blud is angry!");
                }

                private void AttackPhaseOne(Player player)
                {
                    Console.WriteLine($"{Name} útočí na hráče s útokem fáze 1 a dává {BaseDmg} poškození.");
                    player.TakeDmg(BaseDmg);

                    if (Hp < 50)
                    {
                        ToPhaseTwo();
                    }
                }

                private void AttackPhaseTwo(Player player)
                {
                    double phaseTwoDamage = BaseDmg * 1.7; 
                    Console.WriteLine($"Second phase dealt {phaseTwoDamage} dmg.");
                    player.TakeDmg(phaseTwoDamage);
                }


            }
        }
    }
}
