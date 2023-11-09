using System;

namespace MyGameProject.Game.GameObjects
{
    public class DartThrower : Enemy
    {
        public DartThrower(string name) : base(name)
        {
            charclass = "Esqueleto";
            maxhp = 40;
            hp = 40;
            damage = 1;
            speed = 20;
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "  [O]  ";
            texture4 = "  {o}  ";
            texture5 = "  [O]  ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Console.WriteLine($"{name} dispara ciegamente!");
            for (int i = 0; i <= 3; i++)
            {
                Character target = SelectTarget(list);
                Console.WriteLine($"{name} dispara a {target.name}!");
                target.ReciveDamage(damage);
                target.SetPoison(5);
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} dispara a {target.name} con veneno concentrado.");
            target.ReciveDamage(damage);
            target.SetPoison(12);
        }
        public override object Clone()
        {
            return new DartThrower(charclass);
        }
    }
}
