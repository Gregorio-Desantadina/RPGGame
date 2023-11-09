using System;

namespace MyGameProject.Game.GameObjects
{
	public class FireMage : Character
	{
		public FireMage(string name) : base(name)
		{
			hp = 80;
			maxhp = 80;
			maxmana = 80;
			mana = 80;
			damage = 7;
            name = "Salem";
            charclass = "Mago de fuego";
            Attack2Name = "Lluvia de meteoros [40]";
            Attack3Name = "Llamarada [20]";
            Attack4Name = "Calcinar [30]";
            characterDescription = $"El mago de fuego es una clase ideal para hacer daño en area, infligiendo mucho daño a todos los enemigos, pero tambien cuenta con herramientas para objetivos solitarios \n[Lluvia de meteoros]: Ataque de muchisimo daño, el ataque se repite 7 veces, pero tiene muchas probabilidades de fallar. \n[Llamarada]: Ataque que prende fuego a todos los enemigos. \n[Calcinar]: Ataque que hace mucho daño a todos los enemigos prendidos fuego.";
            texture1 = "      ";
            texture2 = "   A  ";
            texture3 = "   O ð";
            texture4 = "  /|─│";
            texture5 = "  / \\ ";
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
					Console.WriteLine($"{name} prende a {character.name} en llamas!");
					character.SetFire(3, damage);
				}
			}
		}
        public override void ThirdSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                mana -= 30;
                foreach (var character in list)
                {
					if(character.fire > 0)
					{
                        Console.WriteLine($"{name} calcina a {character.name}!");
						character.ReciveDamage(damage * 2);
                        character.SetFire(1, damage);
                    }
                    
                }
            }
			else
			{
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad...");
            }
        }
        public override object Clone()
        {
            return new FireMage(charclass);
        }
    }
}