using System;

namespace MyGameProject.Game.GameObjects
{
    public class Lancer : Enemy
    {
        bool charged = false;
        public Lancer(string name) : base(name)
        {
            charclass = "Lancero";
            maxhp = 60;
            hp = 60;
            damage = 6;
            speed = 15;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = " A ▄/  ";
            texture4 = " ║/|   ";
            texture5 = " ║/ \\  ";
        }

        public override void Actions(List<Character> list, List<Character> allyList)
        {
            if (hp > 0)
            {
                if (!charged)
                {
                    UseSpecialAttack(list);
                }
                else
                {
                    SecondSpecialAttack(list);
                }
            }
            else
            {
                texture1 = "       ";
                texture2 = "       ";
                texture3 = "       ";
                texture4 = "   o   ";
                texture5 = " /▄█▄\\ ";
                Console.WriteLine($"{name} esta muerto...");
            }
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza una estocada a {target.name}!");
            target.ReciveDamage(damage * 2);
            Console.WriteLine($"{name} aniade veneno a su lanza...");
            charged = true;
            
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} corta a {target.name} con el filo envenenando!");
            target.ReciveDamage(damage * 2);
            target.SetPoison(damage);
            charged = false;
        }
        public override object Clone()
        {
            return new Lancer(charclass);
        }
    }
}
