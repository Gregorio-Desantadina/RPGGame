using System;

namespace MyGameProject.Game.GameObjects
{
    public class HealerEsqueleton : Enemy
    {
        public HealerEsqueleton(string name) : base(name)
        {
            charclass = "Esqueleto curandero";
            maxhp = 20;
            hp = 20;
            damage = 6;
            speed = 7;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "♥  Ø   ";
            texture4 = " \\/|\\  ";
            texture5 = "  / \\  ";
        }

        public override void Actions(List<Character> list, List<Character> allyList)
        {
            if (hp > 0)
            {      
                UseSpecialAttack(allyList);

            }
            else
            {
                texture1 = "       ";
                texture2 = "       ";
                texture3 = "       ";
                texture4 = "   Ø   ";
                texture5 = "♥/▄█▄\\ ";
                Console.WriteLine($"{name} esta muerto...");
            }
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            list[0].ReciveHeal(damage);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            list[0].ReciveHeal(damage);
        }
        public override object Clone()
        {
            return new HealerEsqueleton(charclass);
        }
    }
}