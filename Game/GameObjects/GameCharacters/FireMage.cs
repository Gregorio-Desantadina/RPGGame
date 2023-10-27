using System;

namespace MyGameProject.Game.GameObjects
{
	public class FireMage : Character
	{
		public FireMage(string name) : base(name)
		{
			damage = 7;
			charclass = "FireMage";
            Attack2Name = "Meteor Rain 40";
            Attack3Name = "Burning 20";
            Attack4Name = "Nothing...";
        }

		public override void UseSpecialAttack(List<Character> list)
		{
			if (mana >= 40)
			{
                Character target = SelectTarget(list);
                mana = mana - 40;
				Console.WriteLine($"{name} realiza un ataque especial con 40 de mana a {target.name}.");
				for (int i = 0; i <= 5; i++)
				{
					if (Random(3) == 1)
					{
						target.ReciveDamage(damage + (Random(4)));
					}
					else
					{
						Console.WriteLine("El ataque fallo!");
					}
				}

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
				foreach (var character in list)
				{
					Console.WriteLine($"{name} sets {character.name} on fire!");
					character.SetFire(3, damage);
				}
			}
		}
	}
}