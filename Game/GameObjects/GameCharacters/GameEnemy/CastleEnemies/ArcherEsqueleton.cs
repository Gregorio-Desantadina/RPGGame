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
            texture1 = "       ";
            texture2 = "       ";
            texture3 = " ╔ O   ";
            texture4 = " ║/|\\  ";
            texture5 = " ╚/ \\  ";
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
                texture1 = "       ";
                texture2 = "       ";
                texture3 = "       ";
                texture4 = "   o   ";
                texture5 = " /▄█▄\\ ";
                Console.WriteLine($"{name} esta muerto...");
                }
		}

		public override void UseSpecialAttack(List<Character> list)
		{
			charged = true;
            texture4 = "<╣/|\\  ";
            Console.WriteLine($"{name} recharges the bow...");
		}
		public override void SecondSpecialAttack(List<Character> list)
		{
			Character target = SelectTarget(list);
			Console.WriteLine($"{name} shots {target.name}!");
			target.ReciveDamage(damage * 2);
            texture4 = " ║/|\\  ";
            charged = false;
		}
        public override object Clone()
        {
            return new ArcherEsqueleton(charclass);
        }
    }
}
