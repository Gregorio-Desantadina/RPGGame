using System;

namespace MyGameProject.Game.GameObjects
{
    public class BossWine1 : Enemy
    {
        bool charged = false;
        public BossWine1(string name) : base(name)
        {
            charclass = "Latigo carnivoro";
            maxhp = 16;
            hp = 16;
            damage = 6;
            speed = 15;
            texture1 = "       ";
            texture2 = "  3Ð   ";
            texture3 = "   ❦\\_ ";
            texture4 = "     \\❦";
            texture5 = "   _/[]";
        }

        // Allows to recive damage
        public override void ReciveDamage(int damage)
        {
            if(hp > damage)
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
                texture4 = "   __  ";
                texture5 = "3D/  []";
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
                texture4 = "   __  ";
                texture5 = "3D/  []";
                Console.WriteLine($"{name} lentamente se regenera...");
                ReciveHeal(5);
                if(!alive)
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
                Console.WriteLine("El latigo carnivoro se regenera completamente!");
                texture1 = "       ";
                texture2 = "  3Ð   ";
                texture3 = "   ❦\\_ ";
                texture4 = "     \\❦";
                texture5 = "   _/[]";
                alive = false;
            }
        }
        

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} golpea a {target.name} y abre su boca!");
            target.ReciveDamage(damage);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} muerde brutalmente a {target.name} y lo hace sangrar!");
            target.ReciveDamage(damage);
        }
        public override object Clone()
        {
            return new BossWine1(charclass);
        }
    }
}
