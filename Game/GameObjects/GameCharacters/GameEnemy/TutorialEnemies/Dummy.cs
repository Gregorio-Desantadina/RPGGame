using System;

namespace MyGameProject.Game.GameObjects
{
    public class Dummy : Enemy
    {
        public Dummy(string name) : base(name)
        {
            charclass = "Dummy";
            maxhp = 20;
            hp = 20;
            damage = 0;
            speed = 1;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   Ø   ";
            texture4 = " /(X)\\ ";
            texture5 = "   |   ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            
            Console.WriteLine($"El maniqui se tambalea...");
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Console.WriteLine($"El maniqui se tambalea...");
        }
        public override object Clone()
        {
            return new Dummy(charclass);
        }
    }
}