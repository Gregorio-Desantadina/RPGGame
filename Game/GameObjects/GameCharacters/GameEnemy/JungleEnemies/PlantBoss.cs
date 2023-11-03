using System;

namespace MyGameProject.Game.GameObjects
{
	public class PlantBoss : Enemy
	{
		bool reborn = false;
		int attackType = 1;
		public PlantBoss(string name) : base(name)
		{
			charclass = "Capullo gigante";
			maxhp = 80;
			hp = 80;
			damage = 10;
			speed = 17;
			texture1 = "       ";
			texture2 = "  MMM  ";
			texture3 = " |   | ";
			texture4 = "/ ┴ ┴ \\";
			texture5 = "[_____]";
		}

		// Does a random action (each enemy usually overrides this, its just an example)
		public override void Actions(List<Character> list, List<Character> allyList)
		{
			if((!reborn) && allyList[0].alive==true && allyList[2].alive == true){
                Uncover();
			}
			if (hp > 1)
			{
				if (!reborn)
				{
                    if (attackType == 1)
                    {
                        Attack(list);
                    }
                    else if (attackType == 2)
                    {
                        UseSpecialAttack(list);
                    }
                    else
                    {
                        SecondSpecialAttack(allyList);
                        attackType = 0;
                    }
                    attackType += 1;
                }
				else
				{
					ThirdSpecialAttack(list);
				}

				
				
			}


			else
			{
                texture1 = "       ";
                texture2 = "       ";
                texture3 = "0┴───\\ ";
                texture4 = "/ ┴ ┴ \\";
                texture5 = "[_____]";
                Console.WriteLine($"{name} y sus latigos mueren...");
                allyList.Remove(allyList[2]);
                allyList.Remove(allyList[0]);
				hp = 0;
            }

		}

        public override void ReciveDamage(int damage)
        {
            if (reborn)
            {
                if (hp > damage)
                {
                    Console.WriteLine($"{name} recive {damage} de daño!");
                    hp = hp - damage;
                    Console.WriteLine($"{name} tiene {hp} de vida...");
                }
                else
                {
                    hp = 1;
                    Console.WriteLine($"{name} ya no se mueve debido a sus heridas...");
                    texture1 = "       ";
                    texture2 = "       ";
                    texture3 = "0┴───\\ ";
                    texture4 = "/ ┴ ┴ \\";
                    texture5 = "[_____]";
                }
            }
            else
            {
                Console.WriteLine($"{name} se cubre con sus latigos y es inmune a todo los daños!");
            }
        }

        public override void ReciveHeal(int heal)
        {

            Console.WriteLine($"{name} se cura {heal} de vida.");
            if (hp + heal < maxhp)
            {
                hp += heal;
            }
            else
            {
                hp = maxhp;
              
            }
        }

        public override void Reborn()
		{
			Console.WriteLine($"{name} vuelve a esconderse dentro de sus hojas!");
            name = "Capullo cubierto";
            texture1 = "       ";
            texture2 = "  MMM  ";
            texture3 = " |   | ";
            texture4 = "/ ┴ ┴ \\";
            texture5 = "[_____]";
            reborn = false;
		}
		public void Uncover()
		{
			Console.WriteLine($"{name} ya no tiene defensas y queda expuesta a un ataque!");
            name = "Capullo descubierto";
            texture1 = "  ^ë^  ";
            texture2 = "  ╚╬╝ ";
            texture3 = " [¯¯¯] ";
            texture4 = "/ ┴ ┴ \\";
            texture5 = "[_____]";
            reborn = true;
        }

		public override void Attack(List<Character> list)
		{
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} golpea a con una liana {target.name}!");
            target.ReciveDamage(damage);
        }

		public override void UseSpecialAttack(List<Character> list)
		{
			Character target = SelectTarget(list);
            Console.WriteLine($"{name} envenena a con sus espinas {target.name}!");
            target.ReciveDamage(damage / 2);
            target.SetPoison(10);

        }
		public override void SecondSpecialAttack(List<Character> list)
		{
			Character target = SelectTarget(list);
			Console.WriteLine($"{name} crece rapidamente {target.name}!");
            foreach (var character in list)
            {
                character.ReciveHeal(5);
            }
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} se mueve nerviosamente y envenena a todo tu equipo levemente!");
            foreach(var character in list)
            {
                character.SetPoison(5);
            }
        }
        public override object Clone()
		{
			return new PlantBoss(charclass);
		}
	}
}
