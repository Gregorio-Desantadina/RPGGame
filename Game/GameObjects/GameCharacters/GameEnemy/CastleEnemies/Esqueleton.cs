using System;

namespace MyGameProject.Game.GameObjects
{
    public class Esqueleton : Enemy
    {
        public Esqueleton(string name) : base(name)
        {
            charclass = "Esqueleto";
            maxhp = 60;
            hp = 60;
            damage = 6;
            speed = 15;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = " | O   ";
            texture4 = " ┼/|\\  ";
            texture5 = "  / \\  ";
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
