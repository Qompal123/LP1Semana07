using System;
using System.Data;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace MyRoguelike
{
    public class Program
    {
        private static void Main()
        {
            Hero player = new Hero("Dragonborn");

            Console.WriteLine($"Name: {player.Name}");      // Name: Hero
            Console.WriteLine($"Level: {player.Level}");    // Level: 1
            Console.WriteLine($"XP: {player.XP}");          // XP: 0
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 100/100

            player.XP = 2500; // Aumenta XP para 2500
            Console.WriteLine($"Level: {player.Level}");    // Level: 3
            Console.WriteLine($"XP: {player.XP}");          // XP: 2500
            Console.WriteLine($"MaxHealth: {player.MaxHealth}"); // MaxHealth: 140

            player.TakeDamage(45);
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 55/140
            Console.WriteLine($"XP: {player.XP}");          // XP: 2502
            Console.WriteLine($"Level: {player.Level}");    // Level: 3

            player.Health = -10;  // Tentativa de colocar health negativa
            Console.WriteLine($"Health: {player.Health}");  // Health: 0

            player.Health = 5000; // Tentativa de ultrapassar maxHealth
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 140/140

            // Output esperado:
            //
            // Name: Dragonborn
            // Level: 1
            // XP: 0
            // Health: 100/100
            // Level: 3
            // XP: 2500
            // MaxHealth: 140
            // Health: 55/140
            // XP: 2502
            // Level: 3
            // Health: 0
            // Health: 140/140
        }
    }

    public class Hero
    {
        private int xp;

        private float health;



        public readonly string Name;

        public int XP
        {
            get 
            {
                return xp;
            }
            set
            {
                xp = value;
            }
        }

        public int Level
        {
            get
            {
                return 1 + xp / 1000;
            }
        }

        public int MaxHealth
        {
            get
            {
                return 100 + (Level - 1) * 20;
            }
        }

        public int Health
        {
            get
            {
                return (int)health;
            }
            set
            {
                if (value > MaxHealth)
                {
                    health = MaxHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public void TakeDamage(float damage)
        {
            int damageRound = Convert.ToInt32(damage);

            Health -= damageRound;

            if (Health < 0)
            {
                Health = 0;
            }

            XP += damageRound / 20;
        }
        
        public Hero(string name)
        {
            this.Name = name;
            this.xp = 0;
            this.Health = MaxHealth;
        }
    }
}