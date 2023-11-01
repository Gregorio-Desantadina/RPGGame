using System;

namespace MyGameProject.Game.GameObjects
{
    public class Assassin : Character
    {
        public Assassin(string name) : base(name)
        {

            damage = 8;
            speed = 21;
            maxhp = 70;
            hp = 70;
            maxmana = 115;
            mana = 115;
            charclass = "Asesino";
            Attack2Name = "Daga venenosa [15]";
            Attack3Name = "Golpe mortal [10]";
            Attack4Name = "Abrir herida [15]";
            characterDescription = $"El asesino es una clase agil de poca vida, con sus ataques puede acumular daño progresivamente. \n[Daga venenosa]: Un ataque de poco daño pero que envenena al enemigo. \n[Ataque 2]: Ataque de daño medio, usarlo hara el veneno en el enemigo 0, pero aumentara el daño dependiendo del veneno que el objetivo tenia. \n[Abrir herida]: Triplica el veneno del enemigo.";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   O | ";
            texture4 = $"  /|\\┼ ";
            texture5 = "  / \\  ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 15)
            {
                Character target = SelectTarget(list);
                mana -= 15;
                Console.WriteLine($"{name} realiza un corte envenenado a {target.name}.");
                target.ReciveDamage(damage);
                target.SetPoison(10);
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
                Console.WriteLine($"{name} apuñala a {target.name}!"); 
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
                Console.WriteLine($"{name} incrementa severamente el veneno de {target.name}!");
                target.SetPoison(target.ReturnPosion() * 2);
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override object Clone()
        {
            return new Assassin(charclass);
        }
    }
}
