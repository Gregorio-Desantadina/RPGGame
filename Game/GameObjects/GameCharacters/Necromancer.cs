using System;

namespace MyGameProject.Game.GameObjects
{
    public class Necromancer : Character
    {
        Character corpse = null;
        public Necromancer(string name) : base(name)

        {
            maxhp = 60;
            hp = 60;
            maxmana = 120;
            mana = 120;
            damage = 10;
            speed = 11;
            name = "Mortis";
            charclass = "Necromancer";
            Attack2Name = "Robo de vida [30]";
            Attack3Name = "Marcar objetivo";
            Attack4Name = "Necromancia [70]";
            characterDescription = $"Una clase muy debil que depende de un compañero, puede revivir enemigos muertos pero mas debiles. \n[Robo de vida]: Absorbe un poco de vida de un rival. \n[Marcar objetivo]: Señala un objetivo, todas las invocaciones lo atacaran por 3 turnos. \n[Necromancia]: Revive una copia mas debil del ultimo enemigo muerto, pero desaparecen al acampar.";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   O ┬ ";
            texture4 = "  /|¯| ";
            texture5 = "  / \\Ü ";
        }

        public override void Corpses(Character character)
        {
            texture1 = "       ";
            texture2 = " ®     ";
            texture3 = "  \\O ┬ ";
            texture4 = "   |¯| ";
            texture5 = "  / \\Ü ";
            corpse = character;
            corpse.maxhp = corpse.maxhp / 5;
            corpse.hp = corpse.maxhp;

        }

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
                    SecondSpecialAttack(list);
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

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} absorbe la vida de {target.name}.");
                target.ReciveDamage(damage);
                ReciveHeal(damage);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} señala a {target.name}");
            target.mark = 3;
            SetExtraTurn(1);
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            if(corpse != null)
            {
                if (mana >= 70)
                {
                    mana = mana - 70;
                    Console.WriteLine($"{name} revive un {corpse.name}!");
                    list.Add(corpse);
                    corpse = null;
                    texture1 = "       ";
                    texture2 = "       ";
                    texture3 = "   O ┬ ";
                    texture4 = "  /|¯| ";
                    texture5 = "  / \\Ü ";
                }
                else
                {
                    Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
                }
            }
            else 
            { 
                Console.WriteLine($"{name} no tiene a quien revivir...");
            }
        }

        public override object Clone()
        {
            return new Necromancer(charclass);
        }
    }
}