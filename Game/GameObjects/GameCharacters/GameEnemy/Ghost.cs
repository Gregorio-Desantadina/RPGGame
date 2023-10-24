using System;

namespace MyGameProject.Game.GameObjects
{
	public class Ghost : Enemy
	{
		public Ghost(string name) : base(name)
		{
			charclass = "Mana Ghost";
			maxhp = 50;
			hp = 50;
			damage = 7;
			speed = 7;
			maxmana = 20;
			mana = 20;
		}
		public override void Actions(List<Character> list)
		{
			if (hp > 0)
			{
				int election = (Random(3));
				if (election == 1)
				{
					UseSpecialAttack(list);
				}
				else if (election == 2)
				{
					SecondSpecialAttack(list);
				}
			}
			else
			{
				Console.WriteLine($"{name} dies...");
			}
		}

		public override void UseSpecialAttack(List<Character> list)
		{
			if (mana < 20)
			{
				Character target = SelectTarget(list);
				target.SetMana(-20);
				mana = mana + 20;
				Console.WriteLine($"{name} steals {target.name} mana!");
				target.ReciveDamage(damage);
			}
			else
			{
				Actions(list);
			}
		}
		public override void SecondSpecialAttack(List<Character> list)
		{
			if (mana >= 20)
			{
				SetMana(-20);
				foreach (var character in list)
				{
					Console.WriteLine($"{name} does a magic attack to {character.name}");
					character.ReciveDamage(damage * 2);
				}
			}
			else
			{
				Actions(list);
			}
		}
	}
}
