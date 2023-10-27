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
		public override void Actions(List<Character> list, List<Character> allyList)
		{
			if (hp > 0)
			{
				int election = (Random(3));
				if (mana < 20)
				{
					UseSpecialAttack(list);
				}
				else 
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
			Character target = SelectTarget(list);
			target.SetMana(-20);
			mana = mana + 20;
			Console.WriteLine($"{name} steals {target.name} mana!");
			target.ReciveDamage(damage);
		}
		public override void SecondSpecialAttack(List<Character> list)
		{
			SetMana(-20);
			foreach (var character in list)
			{
				Console.WriteLine($"{name} does a magic attack to {character.name}");
				character.ReciveDamage(damage * 2);
			}
		}
        public override object Clone()
        {
            return new Ghost(charclass);
        }
    }
}
