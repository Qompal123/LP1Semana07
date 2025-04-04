using System;
using System.Data;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace MyRoguelike
{
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