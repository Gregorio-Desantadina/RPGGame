using System;

namespace MyGameProject.Game.GameObjects
{
    public class Spider : Enemy
    {
        public Spider(string name) : base(name)
        {
            charclass = "Araña";
            maxhp = 25;
            hp = 25;
            damage = 5;
            speed = 23;
            texture1 = "      ";
            texture2 = "      ";
            texture3 = "  \\|/ ";
            texture4 = "  3oO ";
            texture5 = "  /|\\ ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} golpea a {target.name}!");        
            target.ReciveDamage(damage * 3);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un golpe venenoso a {target.name}!");
            target.ReciveDamage(damage);
            target.SetPoison(4);
        }
        public override object Clone()
        {
            return new Spider(charclass);
        }
    }
}
