using System;

namespace MyGameProject.Game.GameObjects
{
    public class Berserk : Character
    {
        bool endurance = false;
        public Berserk(string name) : base(name)
        {
            charclass = "Berserk";
            Attack2Name = "Triple Attack 30";
            Attack3Name = "Heavy slash 30";
            Attack4Name = "Blood Sacrifice";
            texture1 = "       ";
            texture2 = "     ¶ ";
            texture3 = "   O ║ ";
            texture4 = "  /|\\┼ ";
            texture5 = "  / \\  ";
        }
   
        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un ataque especial con 20 de mana a {target.name}.");
                for (int i = 0; i <= 2; i++)
                {
                    target.ReciveDamage((damage / 2) + ((maxhp - hp) / 10));
                }
            }
            else
            {
                Character target = SelectTarget(list);
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad..."); 
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un ataque especial con 30 de mana a {target.name}.");
                target.ReciveDamage(damage + ((maxhp - hp) / 5)); 
            }
            else
            {
                Character target = SelectTarget(list);
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {  
            Console.WriteLine($"{name} sacrifices blood to gain power...");
            endurance = true;
            ReciveDamage(10);
            mana += 35;
        }
        public override void ReciveDamage(int damage)
        {
            if ((endurance == true) && (damage >= hp))
            {
                endurance = false;
                hp = 1;
            }
            else
            {
                hp = hp - damage;
            }
            Console.WriteLine($"{name} recives {damage} damage!");
            Console.WriteLine($"{name} tiene {hp} de vida...");

        }
    }
}
