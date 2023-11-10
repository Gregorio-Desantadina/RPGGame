using System;

namespace MyGameProject.Game.GameObjects
{
    public class Hitter : Character
    {
        public Hitter(string name) : base(name)
        {
            hp = 90;
            maxhp = 90;
            maxmana = 60;
            mana = 60;
            damage = 10;
            charclass = "Bateador";
			Attack1Name = $"Esfuerzo [HP]";
		    Attack2Name = "Golpe de bate [30]";
            Attack3Name = "Provocacion [+15]";
            Attack4Name = $"Paliza [Mana]";
            characterDescription = $"El bateador es una clase que se vuelve mas fuerte con el tiempo, depende de su energia, ya que tiene una manera especial de recuperarla \n[Esfuerzo] El bateador se cura instantaneamente todo su mana, pero recibe daño igual a la mitad de lo recuperado \n[Golpe de bate]: Realiza un golpe pesado, al matar a un enemigo con este ataque aumenta el mana maximo. \n[Provocacion]: Recupera mucho mana, aumenta el mana maximo y se marca, todos los enemigos atacaran a el bateador el siguente turno \n[Paliza]: El bateador utiliza toda su energia en una serie de golpes, que aumentan en daño progresivamente.";
            texture1 = "       ";
            texture2 = "       ";
            texture3 = " <═O-  ";
            texture4 = "  /|┘  ";
            texture5 = "  / \\  ";
        }

		public override void Attack(List<Character> list)
		{
			if(hp > ((maxmana - mana) / 2)) 
            {
                Console.WriteLine($"{name} sacrifica {(maxmana - mana) / 2} HP para recuperar su mana completamente");
                hp -= ((maxmana - mana) / 2);
                SetMana(maxmana);
			}
            else
            {
				Console.WriteLine($"{name} sacrifica el resto de su HP para recuperar su mana completamente");
				SetMana(hp -1);
                hp = 1;
			}
			
		}

		public override void UseSpecialAttack(List<Character> list)
        {
            if (mana >= 30)
            {
                Character target = SelectTarget(list);
                mana = mana - 30;
                Console.WriteLine($"{name} golpea con su bate a {target.name}.");
                target.mark = 2;
                target.ReciveDamage(damage / 2);
                if(target.ReturnHP() <= 0)
                {
                    Console.WriteLine($"{name} se potencia.");
                    maxmana += 15;
					SetMana(15);
				}
            }
            else
            {
                Character target = SelectTarget(list);
                Console.WriteLine($"{name} no tiene suficiente mana para utilizar esta habilidad..."); 
            }
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            maxmana += 15;
			SetMana(15);
            mark = 2;
			Console.WriteLine($"{name} provoca a sus enemigos!");  
        }
        public override void ThirdSpecialAttack(List<Character> list)
        {
			Character target = SelectTarget(list);
			while (true)
            {
                if(mana  >= 30)
                {
                    mana -= 30;
					target.ReciveDamage(damage + extraDamage);
                    extraDamage += 5;
					Console.WriteLine($"{name} golpea salvajemente a {target.name}");
				}
                else
                {
                    Console.WriteLine($"{name} esta extenuado...");
                    extraDamage = 0;
                    break;
                }
            }
        }
        
        public override object Clone()
        {
            return new Hitter(charclass);
        }
    }
}
