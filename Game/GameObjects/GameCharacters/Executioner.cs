using System;

namespace MyGameProject.Game.GameObjects
{
    public class Executioner : Character
    {
        public int extraDamage = 0;
        public Executioner(string name) : base(name)
        {
            damage = 12;
            speed = 9;
            charclass = "Executioner";
            Attack2Name = "Axe slash";
            Attack3Name = "Sharpen the Blade";
            Attack4Name = "Execution";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un ataque especial con 30 de mana a {target.name}.");
                target.ReciveDamage(damage + (Random(5)) + extraDamage);
                extraDamage = 0;
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Console.WriteLine($"{name} recharges energy while he/she sharpens his/her ax");
            extraDamage += 10;
            mana += 15;
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            if (target.hp <= (target.maxhp / 3) + extraDamage)
            {
                if (mana >= 20)
                {
                    mana = mana - 20;
                    Console.WriteLine($"{name} executes {target.name}!");
                    ReciveHeal(target.hp);
                    target.ReciveDamage(999);
                    extraDamage = 0;
                }
                else
                {
                    Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
                }
            }
            else
            {
                Console.WriteLine($"{target.name} as not enough HP to be executed...");
            }
        }
    }
}