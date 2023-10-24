using System;

namespace MyGameProject.Game.GameObjects
{
    public class Spider : Enemy
    {
        public Spider(string name) : base(name)
        {
            charclass = "Spider";
            maxhp = 25;
            hp = 25;
            damage = 3;
            speed = 23;
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
    }
}
