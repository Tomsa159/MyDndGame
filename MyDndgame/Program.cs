using MyDndgame.Properties.Classes;
using MyDndgame.Properties.Enums;
using System;
using System.Collections.Generic;

namespace MyDndgame
{
    internal class Program
    {

        static Player player = new Player("You", 10, 120);
        static List<Room> rooms = new List<Room>();
        static Room currentRoom;

        static void Main(string[] args)
        {
            Console.WriteLine("Wecome to the game.....                       part 2 hmmmm");

            rooms.Add(new Room("enter the jendas dex dungeon", Enemy.Factory.CreateOger()));
            rooms.Add(new Room("hallway", Enemy.Factory.CreateGoblin()));
            rooms.Add(new Room("Medusas chamber", Enemy.Factory.CreateMedusa()));
            rooms.Add(new Room("Empty room", Enemy.Factory.CreateDog()));
            rooms.Add(new Room("Oasis (finaly place to rest)"));
            rooms.Add(new Room("Arch demons layer", Enemy.Factory.CreateBoss()));

            while (true)
            {
                Console.WriteLine("Whats your command (move, attack(only in room), heal, gamba(free to play for now...)): ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "move":
                        Move();
                        break;
                    case "attack":
                        if (currentRoom == null)
                        {
                            Console.WriteLine("you have no enemies");
                        }
                        else
                        {
                            Attack();
                        }
                        break;
                    case "heal":
                        player.Heal();
                        break;
                    case "strength":
                        player.Strength();
                        break;
                    case "openchest":
                        OpenChest();
                        break;
                }
            }
        }

        private static void OpenChest()
        {
            Console.WriteLine("Warning:First two spins are free, if you get premium you get 50% sale for next spins. premium cost is only for 29.99$ ;P");
            Console.WriteLine("Warning:If you bet more to make up for your losses, you are likely to lose even more money. I konw you will do it");
            Random rndWeapon = new Random();
            int randomWeapon = rndWeapon.Next(1, 5);
            switch (randomWeapon)
            {
                case 1:
                    player.BaseDmg += (int)Weapons.knife;
                    Console.WriteLine("Warning:If you get this. you should spin again");
                    break;
                case 2:
                    player.BaseDmg += (int)Weapons.ndegger;
                    Console.WriteLine("Warning:The result of any spin has nothing to do with previous spins");
                    break;
                case 3:
                    player.BaseDmg += (int)Weapons.enhancedsword;
                    break;
                case 4:
                    player.BaseDmg += (int)Weapons.fullbring;
                    break;
                case 5:
                    player.BaseDmg += (int)Weapons.PEKKAset;
                    Enemy.Factory.Createtrap();
                    Console.WriteLine("ITs a trap!");
                    break;

            }
            Console.WriteLine($"NO WAY!!! This weapon looks coool. (your dmg is increased by {player.BaseDmg})");
            
        }

        private static void Attack()
        {
            if (currentRoom.Enemy != null)
            {
                player.Attack(currentRoom.Enemy);

                if (currentRoom.Enemy.Hp <= 0)
                {

                    if (currentRoom == rooms[5])
                    {

                        if (currentRoom.Enemy.Hp <= 0)
                        {
                            Console.WriteLine("Boss was successfully");
                            Console.WriteLine("thx for playing");
                            Environment.Exit(0);
                        }
                    }
                    Console.WriteLine($"You killed pleb {currentRoom.Enemy.Name}");
                    currentRoom.Enemy = null;
                }
                else
                {
                    currentRoom.Enemy.Attack(player);

                    if (player.Hp <= 0)
                    {
                        Console.WriteLine("GG you are useless");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.WriteLine("blud is attacking his schizo...");
            }
        }

        private static void Move()
        {
            Console.WriteLine("Choose 1 2 3 4 5 6");

            int roomIndex = int.Parse(Console.ReadLine());
            
            if (roomIndex >= 0 && roomIndex < rooms.Count + 1)
            {
                currentRoom = rooms[roomIndex - 1];
                Console.WriteLine($"moving to... {currentRoom.Name}");

                if (currentRoom.Enemy != null)
                {
                    Console.WriteLine($"I smell nig....enemies {currentRoom.Enemy.Name}");
                }
                else
                {
                    Console.WriteLine("why?? no one is here");
                }
            }
            else
            {
                Console.WriteLine("nope");
            }
        }
    }

}
