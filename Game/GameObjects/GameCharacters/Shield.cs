using System;

namespace MyGameProject.Game.GameObjects
{
    public class Shield : Character
    {
        public Shield(string name) : base(name)
        {
            hp = 120;
            maxhp = 120;
            maxmana = 70;
            mana = 70;
            speed = 17;
            damage = 17;
            name = "Sin nombre";
            charclass = "Protector";
            Attack2Name = "Golpe de escudo [15]";
            Attack3Name = "El aguante [40]";
            Attack4Name = "Proteger [30]";
            characterDescription = $"El protector es una clase que se encarga de proteger a sus aliados mas debiles, ademas de resistir golpes. \n[Habilidad pasiva] Lentamente recupera su vida y la de sus aliados. \n[Golpe de escudo]: Un golpe debil \n[El aguante]: Aumenta su defensa en un 30% por 3 turnos, y recupera el mana de un compañero. \n[Proteger]: El protector se marca a si mismo por 4 turnos.";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = "   O A ";
            texture4 = "  /║¯█ ";
            texture5 = "  / \\V ";
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

        public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} golpea ferozmente a {target.name}.");
                target.ReciveDamage(damage);
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
                SetMana(-40);
                Character target = SelectTarget(list);
                target.SetMana(30);
                SetShield(3, 3);
                Console.WriteLine($"{name} recupera el mana de {target.name} y aumenta su propia defensa!");
            }
            else
            {
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }

            }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            Console.WriteLine($"{name} se marca a si mismo");
            mark = 4;
        }
        
        public override object Clone()
        {
            return new Shield(charclass);
        }
    }
}