using System;

namespace MyGameProject.Game.GameObjects
{
	public class IceMage : Character
	{
		public IceMage(string name) : base(name)
		{
			damage = 7;
			maxhp = 75;
			hp = 75;
			charclass = "Mago de hielo";
			Attack2Name = "Perforar [25]";
			Attack3Name = "Congelar [40]";
			Attack4Name = "Tormenta [15]";
			speed = 13;
            characterDescription = $"El mago de hielo es una clase que destaca por su utilidad, pudiendo hacer que los enemigos pierdan turnos y velocidad, es una clase que trabaja en equipo. \n[Perforar]: Ataque de daño moderado, ralentiza al objetivo \n[Congelar]: Congela a un enemigo, que perdera su siguente turno. \n[Tormenta]: Daña a todos los enemigos y reduce su velocidad considerablemente.";
            texture1 = "      ";
            texture2 = "   A ^";
            texture3 = "   O ¥";
            texture4 = "  /|─│";
            texture5 = "  / \\ ";
		}


        public override void UseSpecialAttack(List<Character> list)
		{
			if (mana >= 25)
			{
                Character target = SelectTarget(list);
                mana = mana - 25;
				Console.WriteLine($"{name} perfora a {target.name} con un tempano de hielo y lo ralentiza.");
				target.ReciveDamage(damage * 2);
                target.SetSpeed(-4);

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
                Character target = SelectTarget(list);
                mana -= 40;
				Console.WriteLine($"{name} congela a {target.name}!");
				target.SetIce(1);
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
				mana -= 15;
				foreach (var character in list)
				{
					Console.WriteLine($"{name} ralentiza a {character.name}");
                    character.ReciveDamage(damage);
                    character.SetSpeed(-4);
				}
			}
        }
        public override object Clone()
        {
            return new IceMage(charclass);
        }
    }
}