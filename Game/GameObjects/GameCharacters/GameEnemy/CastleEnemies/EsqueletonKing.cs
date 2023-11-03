using System;

namespace MyGameProject.Game.GameObjects
{
    public class EsqueletonKing : Enemy
    {
        List<Character> summons = new List<Character>
        {
            new SmallEsqueleton("Esqueleto pequeño"),
            new HealerEsqueleton("Esqueleto curador")
        };
        int attackType = 1;
        public EsqueletonKing(string name) : base(name)
        {
            charclass = "Rey Esqueleto";
            maxhp = 170;
            hp = 170;
            damage = 30;
            speed = 10;
            texture1 = "   m   ";
            texture2 = "   Ø   ";
            texture3 = "o═▀▓▀╗ ";
            texture4 = "╬ ┌▒┐o ";
            texture5 = "║ █ █  ";
        }

        // Does a random action (each enemy usually overrides this, its just an example)
        public override void Actions(List<Character> list, List<Character> allyList)
        {
            Console.WriteLine(list[0].ReturnName());
            Console.WriteLine(allyList[0].ReturnName());
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
                texture2 = "   ╬   ";
                texture3 = "   ║   ";
                texture4 = "   Ø   ";
                texture5 = " /▄█▄\\ ";
                Console.WriteLine($"{name} esta muerto...");
            }

        }

        public override void Attack(List<Character> list)
        {
            Console.WriteLine($"{name} invoca un aliado");
            Console.WriteLine(list[0].ReturnName());
            Random random = new Random();
            int number = random.Next(summons.Count);
            Character character = (Character)summons[number].Clone();
            list.Add(character);
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
            return new EsqueletonKing(charclass);
        }
    }
}
