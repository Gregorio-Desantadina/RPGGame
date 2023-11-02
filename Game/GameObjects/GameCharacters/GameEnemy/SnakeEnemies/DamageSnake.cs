using System;

namespace MyGameProject.Game.GameObjects
{
    public class DamageSnake : Enemy
    {
        public DamageSnake(string name) : base(name)
        {
            charclass = "Serpiente venenosa";
            maxhp = 15;
            hp = 15;
            damage = 4;
            speed = 11;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "  ╔═O  ";
            texture4 = "  ╚═╗  ";
            texture5 = " <══╝  ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} poisons {target.name}.");
            target.ReciveDamage(damage + (Random(4)));
            target.SetPoison(8);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un golpe fuerte a {target.name}!");
            target.ReciveDamage(damage * 2);
        }
        public override object Clone()
        {
            return new DamageSnake(charclass);
        }
    }
}
