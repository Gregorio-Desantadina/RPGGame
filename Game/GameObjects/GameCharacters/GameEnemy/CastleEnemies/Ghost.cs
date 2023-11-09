using System;

namespace MyGameProject.Game.GameObjects
{
	public class Ghost : Enemy
	{
		public Ghost(string name) : base(name)
		{
			charclass = "Fantasma de mana";
			maxhp = 40;
			hp = 40;
			damage = 5;
			speed = 7;
			maxmana = 20;
			mana = 20;
            texture1 = "      ";
            texture2 = "      ";
            texture3 = "   ô  ";
            texture4 = "  /▒\\ ";
            texture5 = "   ░  ";
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
                    texture1 = "       ";
                    texture2 = "       ";
                    texture3 = "       ";
                    texture4 = "   ô   ";
                    texture5 = " /░▒░\\ ";
                    Console.WriteLine($"{name} esta muerto...");
                }
		}

		public override void UseSpecialAttack(List<Character> list)
		{
			Character target = SelectTarget(list);
			target.SetMana(-20);
			mana = mana + 20;
			Console.WriteLine($"{name} le roba mana a {target.name}!");
			target.ReciveDamage(damage);
		}
		public override void SecondSpecialAttack(List<Character> list)
		{
			SetMana(-20);
            Console.WriteLine($"{name} realiza un ataque magico a todo el equipo!");
            foreach (var character in list)
			{
				character.ReciveDamage(damage * 2);
			}
		}
        public override object Clone()
        {
            return new Ghost(charclass);
        }
    }
}
