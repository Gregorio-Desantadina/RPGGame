using System;

namespace MyGameProject.Game.GameObjects
{
    public class SmallEsqueleton : Enemy
    {
        public SmallEsqueleton(string name) : base(name)
        {
            charclass = "Esqueleto peque�o";
            maxhp = 20;
            hp = 20;
            damage = 10;
            speed = 10;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   �   ";
            texture4 = "  /|\\  ";
            texture5 = "  / \\  ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} ataca a {target.name}!");
            target.ReciveDamage(damage);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} ataca a {target.name}!");
            target.ReciveDamage(damage);
        }
        public override object Clone()
        {
            return new SmallEsqueleton(charclass);
        }
    }
}