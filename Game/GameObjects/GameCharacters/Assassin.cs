using System;

namespace MyGameProject.Game.GameObjects
{
    public class Assassin : Character
    {
        public Assassin(string name) : base(name)
        {
            damage = 8;
            speed = 21;
            charclass = "Assassin";
            Attack1Name = "Basic Attack";
            Attack2Name = "Posion Dagger";
            Attack3Name = "Deadly Finish";
            Attack4Name = "Severe Poison";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 15)
            {
                Character target = SelectTarget(list);
                mana = mana - 15;
                Console.WriteLine($"{name} realiza un ataque especial con 20 de mana a {target.name}.");
                target.ReciveDamage(damage + (Random(4)));
                target.SetPoison(8);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            if (mana >= 10)
            {
                Character target = SelectTarget(list);
                mana = mana - 10;
                Console.WriteLine($"{name} realiza un ataque especial con 15 de mana a {target.name}."); 
                target.ReciveDamage(damage + (Random(4)) + (target.ReturnPosion()));
                target.SetPoison(- target.ReturnPosion());
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            
            if (mana >= 15)
            {
                Character target = SelectTarget(list);
                mana = mana - 15;
                Console.WriteLine($"{name} severely increases {target.name}'s poison!");
                target.SetPoison(target.ReturnPosion() * 2);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
            
    }
}
