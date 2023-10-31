using System;

namespace MyGameProject.Game.GameObjects
{
    public class Esqueleton : Enemy
    {
        int attackType = 0;
        public Esqueleton(string name) : base(name)
        {
            charclass = "Esqueleton King";
            maxhp = 230;
            hp = 230;
            damage = 20;
            speed = 10;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = " | O   ";
            texture4 = " ┼/|\\  ";
            texture5 = "  / \\  ";
        }

        // Does a random action (each enemy usually overrides this, its just an example)
        public override void Actions(List<Character> list, List<Character> allyList)
        {
            if (hp > 0)
            {
                
                if (attackType == 1)
                {
                    Attack(allyList);
                }
                else if (attackType == 2)
                {
                    UseSpecialAttack(list);
                }
                else
                {
                    SecondSpecialAttack(list);
                    attackType = 0;
                }
                attackType += 1;
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

        public override void Attack(List<Character> list)
        {
            Console.WriteLine($"{name} invoca un esqueleto")
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} le roba vitalidad a {target.name}!");
            target.ReciveDamage(damage / 2);
            ReciveHeal(10);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} corta a {target.name}!");
            target.ReciveDamage(damage);
        }
        public override object Clone()
        {
            return new Esqueleton(charclass);
        }
    }
}
