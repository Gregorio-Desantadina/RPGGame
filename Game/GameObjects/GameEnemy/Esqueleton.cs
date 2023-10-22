/*using System;

namespace MyGameProject.Game.GameObjects
{
    public class Esqueleton : Enemy
    {
        public Esqueleton(string name) : base(name)
        {
            charclass = "Esqueleton";
            damage = 6;
        }

        public override void UseSpecialAttack(Character target)
        {
            if (mana >= 30)
            {
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un doble golpe a {target.name}!");
                for (int i = 0; i <= 1; i++)
                {
                    target.ReciveDamage(damage);
                }
            }
            else
            {
                Actions(target);
            }
        }
        public override void SecondSpecialAttack(Character target)
        {
            if (mana >= 20)
            {
                mana -= 20;
                Console.WriteLine($"{name} realiza un golpe fuerte a {target.name}!");
                target.ReciveDamage(damage * 2);
            }
            else
            {
                Actions(target);
            }
        }
    }
}*/
