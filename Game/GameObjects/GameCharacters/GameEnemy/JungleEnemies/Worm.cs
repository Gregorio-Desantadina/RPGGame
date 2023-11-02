using System;

namespace MyGameProject.Game.GameObjects
{
    public class Worm : Enemy
    {
        public Worm(string name) : base(name)
        {
            charclass = "Larva";
            maxhp = 90;
            hp = 90;
            damage = 8;
            speed = 15;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "       ";
            texture4 = " _---_ ";
            texture5 = "3_____]";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} escupe sobre {target.name}!");
            target.RecivePoson(damage);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} escupe sobre {target.name}!");
            target.RecivePoison(damage);
        }
        public override object Clone()
        {
            return new Worm(charclass);
        }
    }
}
