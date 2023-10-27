using System;
using MyGameProject.Game.Start;

namespace MyGameProject.Game.GameObjects
{
    public class SnakeTamer : Character
    {
        public int extraDamage = 0;
        public SnakeTamer(string name) : base(name)

        {
            damage = 10;
            speed = 17;
            charclass = "Snake Tamer";
            Attack2Name = "Cobra attack 20";
            Attack3Name = "Summon Healing Snake 30";
            Attack4Name = "Summon Damage Snake 30";
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
                    UseSpecialAttack(list);
                }
                else if (election == "3")
                {
                    SecondSpecialAttack(allyList);
                }
                else
                {
                    ThirdSpecialAttack(allyList);
                }
            }
            else
            {
                Console.WriteLine($"{name} dies...");
            }
        }

        //Creates objects and add it to the list
        public void AddToList(List<Character> list, int number)
        {
            Main main = new Main();
            if (number == 1)
            {
                main.AddList(list, new DamageSnake("Damage Cobra"));
            }
            else
            {
                main.AddList(list, new HealingSnake("Healing Cobra"));
            }
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 20)
            {
                Character target = SelectTarget(list);
                mana = mana - 20;
                Console.WriteLine($"{name} attacks {target.name}.");
                target.ReciveDamage(damage + (Random(5)));
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                mana -= 30;
                Console.WriteLine($"{name} summons a snake");
                AddToList(list, 1);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                mana -= 30;
                Console.WriteLine($"{name} summons a snake");
                AddToList(list, 2);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
    }
}