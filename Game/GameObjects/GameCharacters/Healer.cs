using System;

namespace MyGameProject.Game.GameObjects
{
    public class Healer : Character
    {
        public Healer(string name) : base(name)
        {
            damage = 15;
            speed = 15;
            charclass = "Healer";
            Attack2Name = "Healing prayer 35";
            Attack3Name = "Groupal regeneration 30";
            Attack4Name = "Small attack";
        }

        // needs override because UseSpecialAttack/SecondSpecialAttack dont use the enemy list, but the ally one
        public override void Actions(List<Character> list, List<Character> allyList)
        {
            if (hp > 0)
            {
                Console.WriteLine($"[{name} {charclass}]: HP: {hp} Mana: {mana}");
                Console.WriteLine($"{name}: Seleccione su accion:");
                Console.WriteLine($"[1] {Attack1Name}");
                Console.WriteLine($"[2] {Attack2Name}");
                Console.WriteLine($"[3] {Attack3Name}");
                Console.WriteLine($"[4] {Attack4Name}");
                Console.Write("...");
                string? election = Console.ReadLine();
                if (election == "1")
                {
                    Attack(list);
                }
                else if (election == "2")
                {
                    UseSpecialAttack(allyList);
                }
                else if (election == "3")
                {
                    SecondSpecialAttack(allyList);
                }
                else
                {
                    ThirdSpecialAttack(list);
                }
            }
            else
            {
                Console.WriteLine($"{name} dies...");
            }
        }
        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 35)
            {
                Character target = SelectTarget(list);
                mana = mana - 35;
                Console.WriteLine($"{name} prays for {target.name}.");
                target.ReciveHeal(damage + (Random(4)));
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            if (mana >= 20)
            {
                mana -= 20;
                Console.WriteLine($"{name} heals the party");
                foreach (var character in list)
                {
                    character.ReciveHeal(damage / 2 + (Random(2)));
                }
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
                Console.WriteLine($"{name} sighly damages {target.name}");
                target.ReciveDamage(damage);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }

    }
}
