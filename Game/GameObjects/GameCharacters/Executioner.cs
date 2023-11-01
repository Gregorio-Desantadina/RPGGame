using System;
using MyGameProject.Game.Start;

namespace MyGameProject.Game.GameObjects
{
    public class Executioner : Character
    {
        public int extraDamage = 0;
        public Executioner(string name) : base(name)

        {
            maxmana = 80;
            mana = 80;
            damage = 18;
            speed = 9;
            charclass = "Ejecutor";
            Attack2Name = "Corte de hacha [30]";
            Attack3Name = "Afilar [+20]";
            Attack4Name = "Ejecutar [20]";
            characterDescription = $"La clase mas lenta de todas, el ejecutor cuenta con el mayor daño base, y la habilidad de matar insantaneamente cualquier enemigo con poca vida. \n[Corte de hacha]: Ataque simple de mucho daño. \n[Afilar]: Al afilar su hacha, el ejecutor recupera mana, su proximo golpe hara +10 de daño por cada ves que afile. \n[Ejecucion]: El ejecutor elimina a un enemigo con 33% o menos de vida instantaneamente, y recupera toda la vida que el objetivo de la ejecucion tenia, n\afilar hace que los enemigos puedan ser ejecutados mas facilmente (33% de vida + 10 por afilado)";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   O |╣";
            texture4 = "  /|\\| ";
            texture5 = "  / \\| ";
        }

        

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} realiza un golpe tajante a {target.name}.");
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
            Console.WriteLine($"{name} recarga energia mientras afila su hacha");
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
                    Console.WriteLine($"{name} ejecuta a {target.name}!");
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
                Console.WriteLine($"{target.name} no tiene vida suficiente para ser ejecutado...");
            }

        }
        public override object Clone()
        {
            return new Executioner(charclass);
        }
    }
}