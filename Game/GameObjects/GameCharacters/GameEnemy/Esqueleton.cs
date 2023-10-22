using System;

namespace MyGameProject.Game.GameObjects
{
    public class Esqueleton : Enemy
    {
        public Esqueleton(string name) : base(name)
        {
            charclass = "Esqueleton";
            hp = 80;
            damage = 6;
            speed = 15;
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un doble golpe a {target.name}!");
                for (int i = 0; i <= 1; i++)
                {
                    target.ReciveDamage(damage);
                }
            }
            else
            {
                Actions(list);
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            if (mana >= 20)
            {
                Character target = SelectTarget(list);
                mana -= 20;
                Console.WriteLine($"{name} realiza un golpe fuerte a {target.name}!");
                target.ReciveDamage(damage * 2);
            }
            else
            {
                Actions(list);
            }
        }
    }
}
