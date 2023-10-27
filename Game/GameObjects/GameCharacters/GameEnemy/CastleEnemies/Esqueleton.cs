using System;

namespace MyGameProject.Game.GameObjects
{
    public class Esqueleton : Enemy
    {
        public Esqueleton(string name) : base(name)
        {
            charclass = "Esqueleton";
            maxhp = 80;
            hp = 80;
            damage = 6;
            speed = 15;
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un doble golpe a {target.name}!");
            for (int i = 0; i <= 1; i++)
            {
                target.ReciveDamage(damage);
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un golpe fuerte a {target.name}!");
            target.ReciveDamage(damage * 2);
        }
        public override object Clone()
        {
            return new Esqueleton(charclass);
        }
    }
}
