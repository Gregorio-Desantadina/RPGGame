using System;

namespace MyGameProject.Game.GameObjects
{
	public class FireMage : Character
	{
		public FireMage(string name) : base(name)
		{
			damage = 5;
			charclass = "FireMage";
            Attack2Name = "Meteor Rain";
            Attack3Name = "Burning";
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
						target.ReciveDamage(damage + (Random(5)));
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
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} sets {target.name} on fire!");
			target.fire = target.fire + 2;
		}
	}
}