using System;

namespace MyGameProject.Game.GameObjects
{
	public class ArcherEsqueleton : Enemy
	{
		bool charged = false;
		public ArcherEsqueleton(string name) : base(name)
		{
			charclass = "ArcherEsqueleton";
			maxhp = 80;
			hp = 80;
			damage = 15;
			speed = 10;
		}
		public override void Actions(List<Character> list, List<Character> allyList)
		{
			if (hp > 0)
			{
				if (!charged)
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
			charged = true;
			Console.WriteLine($"{name} recharges the bow...");
		}
		public override void SecondSpecialAttack(List<Character> list)
		{
			Character target = SelectTarget(list);
			Console.WriteLine($"{name} shots {target.name}!");
			target.ReciveDamage(damage * 2);
			charged = false;
		}
        public override object Clone()
        {
            return new ArcherEsqueleton(charclass);
        }
    }
}
