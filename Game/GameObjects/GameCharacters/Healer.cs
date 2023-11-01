using System;

namespace MyGameProject.Game.GameObjects
{
    public class Healer : Character
    {
        public Healer(string name) : base(name)
        {
            damage = 15;
            speed = 15;
            maxhp = 90;
            hp = 90;
            charclass = "Curandero";
            Attack2Name = "Rezo curativo [35]";
            Attack3Name = "Regeneracion grupal [30]";
            Attack4Name = "Destello";
            characterDescription = $"El curandero es una clase debil, basada en el apoyo y supervivencia de sus aliados, aunque debil en solitario, puede salvar a sus compañeros de grupo. \n[Rezo curativo]: Cura mucha vida de un objetivo aliado y elimina todos sus efectos de estado. \n[Regeneracion grupal]: Cura un poco de vida de todos los miembros del grupo. \n[Destello]: Ataque debil, unica defensa del curandero.";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "  O ┌─┐";
            texture4 = " /|\\[╬]";
            texture5 = " / \\└─┘";
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
        public override object Clone()
        {
            return new Healer(charclass);
        }
    }
}
