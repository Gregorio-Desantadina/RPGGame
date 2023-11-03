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
            maxhp = 80;
            hp = 80;
            maxmana = 90;
            mana = 90;
            name = "Kobra";
            charclass = "Domador de serpientes";
            Attack2Name = "Golpe en conjunto [15]";
            Attack3Name = "Invocar serpiente de ataque [40]";
            Attack4Name = "Invocar serpiente de curacion [40]";
            characterDescription = $"El domador de serpientes es una clase que rapidamente puede generar un ejercito, cuenta con las abilidades para invocar serpientes y volverlas mas fuertes. \n[Golpe en conjunto]: Golpe de poco daño, pero que hace que todas las serpientes ataquen en conjunto. \n[Invocar serpiente de ataque]: Invoca una serpiente que atacara periodicamente, pudiendo infligir veneno. \n[Invocar serpiente de curacion]: Invoca una serpiente que cura aliados periodicamente, si todos los aliados estan con vida maxima realizara un ataque debil";
            texture1 = "       ";
            texture2 = "     S ";
            texture3 = "   O/  ";
            texture4 = "  /|   ";
            texture5 = "  / \\  ";
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
                Console.Write("Ingrese su accion: ");
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
            if (mana >= 40)
            {
                if (list.Any(c => c is DamageSnake))
                {
                    foreach (Character character in list)
                    {
                        if (character is DamageSnake){
                            mana -= 40;
                            Console.WriteLine($"{name} potencia a {character.ReturnName()}!");
                            character.maxhp += 3;
                            character.hp += 3;
                            character.damage += 1;
                        }
                    }
                }
                else
                {
                    mana -= 40;
                    Console.WriteLine($"{name} summons a snake");
                    AddToList(list, 1);
                }
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            if (mana >= 40)
            {
                if (list.Any(c => c is HealingSnake))
                {
                    foreach (Character character in list)
                    {
                        if (character is HealingSnake)
                        {
                            mana -= 40;
                            Console.WriteLine($"{name} potencia a {character.ReturnName()}!");
                            character.maxhp += 3;
                            character.hp += 3;
                            character.damage += 1;
                        }
                    }
                }
                else
                {
                    mana -= 40;
                    Console.WriteLine($"{name} summons a snake");
                    AddToList(list, 2);
                }
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override object Clone()
        {
            return new SnakeTamer(charclass);
        }
    }
}