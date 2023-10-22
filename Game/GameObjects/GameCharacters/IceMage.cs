using System;

namespace MyGameProject.Game.GameObjects
{
	public class IceMage : Character
	{
		public IceMage(string name) : base(name)
		{
			damage = 7;
			charclass = "IceMage";
			Attack2Name = "Mana Steal";
			Attack3Name = "Freeze";
			speed = 13;
		}

		public override void UseSpecialAttack(List<Character> list)
		{
			if (mana >= 25)
			{
                Character target = SelectTarget(list);
                mana = mana - 25;
				Console.WriteLine($"{name} realiza un ataque especial con 25 de mana a {target.name} y le saca 10 de mana.");
				target.ReciveDamage(damage + (Random(10)));
				if (target.mana >= 10)
					{
					target.mana = target.mana - 10;
					}
				else
				{
					target.mana = 0;
				}
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
				Console.WriteLine($"{name} freezes {target.name}!");
				target.SetIce(1);
			}
			else
			{
				Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
			}
		}
	}
}