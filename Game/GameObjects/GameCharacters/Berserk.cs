using System;

namespace MyGameProject.Game.GameObjects
{
    public class Berserk : Character
    {
        bool endurance = false;
        public Berserk(string name) : base(name)
        {
            hp = 100;
            maxhp = 100;
            maxmana = 60;
            mana = 60;
            charclass = "Berserker";
            Attack2Name = "Triple golpe [30]";
            Attack3Name = "Golpe pesado [20 HP]";
            Attack4Name = "Sacrificio de sangre [10 HP]";
            characterDescription = $"El Berserk es una clase de mucha vida, capaz de dar vuelta cualquier batalla gracias a sus habilidades de supervivencia y aumentos de daño. \n[Triple golpe]: Realiza 3 ataques de poco daño, el daño aumenta dependiendo cuanta vida le falte al berserker. \n[Golpe pesado]: Ataque de mucho daño que utiliza vida en vez de mana, el daño aumenta dependiendo cuanta vida le falte al berserker \n[Sacrificio de sangre]: El berserk sacrifica vida para recuperar mana, el siguente golpe moral que reciva lo dejara con 1 de vida en vez.";
            texture1 = "       ";
            texture2 = "     ¶ ";
            texture3 = "   O ║ ";
            texture4 = "  /|\\┼ ";
            texture5 = "  / \\  ";
        }
   
        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} golpea ferozmente a {target.name}.");
                for (int i = 0; i <= 2; i++)
                {
                    target.ReciveDamage((damage / 2) + ((maxhp - hp) / 10));
                }
            }
            else
            {
                Character target = SelectTarget(list);
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad..."); 
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            
                Character target = SelectTarget(list);
                hp-=20;
                Console.WriteLine($"{name} corta a {target.name}!");
                target.ReciveDamage(damage + ((maxhp - hp) / 5)); 
            
            
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {  
            Console.WriteLine($"{name} Sacrifica sangre para ganar poder...");
            endurance = true;
            ReciveDamage(10);
            SetMana(35);
        }
        public override void ReciveDamage(int damage)
        {
            if ((endurance == true) && (damage >= hp))
            {
                endurance = false;
                hp = 1;
            }
            else
            {
                hp = hp - damage;
            }
            Console.WriteLine($"{name} recives {damage} damage!");
            Console.WriteLine($"{name} tiene {hp} de vida...");

        }
        public override object Clone()
        {
            return new Berserk(charclass);
        }
    }
}
