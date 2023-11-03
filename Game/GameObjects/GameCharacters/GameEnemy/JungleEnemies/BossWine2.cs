using System;

namespace MyGameProject.Game.GameObjects
{
    public class BossWine2 : Enemy
    {
        bool charged = false;
        
        public BossWine2(string name) : base(name)
        {
            charclass = "Latigo venenoso";
            maxhp = 16;
            hp = 16;
            damage = 6;
            speed = 16;
            texture1 = "       ";
            texture2 = " ❤  d3";
            texture3 = "  \\/   ";
            texture4 = "  /     ";
            texture5 = "[]\\_   ";
        }

        public override void ReciveDamage(int damage)
        {
            if (hp > damage)
            {
                Console.WriteLine($"{name} recive {damage} de daño!");
                hp = hp - damage;
                Console.WriteLine($"{name} tiene {hp} de vida...");
            }
            else
            {
                Console.WriteLine($"{name} ya no se mueve debido a sus heridas...");
                texture1 = "       ";
                texture2 = "       ";
                texture3 = "       ";
                texture4 = "❥__   ";
                texture5 = "[]  \\d3";
                hp = 1;
                alive = true;
            }

        }

        public override void Actions(List<Character> list, List<Character> allyList)
        {
            if (!alive)
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
                texture4 = "❥__   ";
                texture5 = "[]  \\d3";
                Console.WriteLine($"{name} lentamente se regenera...");
                ReciveHeal(5);
                if (!alive)
                {
                    allyList[1].Reborn();
                }
            }
        }
        public override void ReciveHeal(int heal)
        {

            Console.WriteLine($"{name} se cura {heal} de vida.");
            if (hp + heal < maxhp)
            {
                hp += heal;
            }
            else
            {
                hp = maxhp;
                Console.WriteLine("El latigo venenoso se regenera completamente!");
                texture1 = "       ";
                texture2 = " ❤  d3";
                texture3 = "  \\/   ";
                texture4 = "  /     ";
                texture5 = "[]\\_   ";
                alive = false;

            }
        }
    

    public override void UseSpecialAttack(List<Character> list)
        {
            
            Console.WriteLine($"{name} prepara un escupitajo venenoso...");
            charged = true;
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} escupe veneno a {target.name}!");
            target.SetPoison(14);
            charged = false;
        }
        public override object Clone()
        {
            return new BossWine2(charclass);
        }
    }
}
