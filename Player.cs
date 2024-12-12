using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
   
    internal class Player
    {
        private int _max_health;
        private int _health;
        private int _damage;
        private int _innateDefense;
        private int _defense = 0;
       public Player()
        {

        }
       public Player(int maxHealth, int health, int damage, int innateDefense, int defense)
        {
            _max_health = maxHealth;
            _health = health;
            _damage = damage;
            _innateDefense = innateDefense;
            _defense = defense;
        }
    }
}
