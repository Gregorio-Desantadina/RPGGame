using System;

namespace MyGameProject.Game.GameObjects
{
    // ICloneable means it can generate copies of itself
    public class Character :ICloneable
    {
        public string name;
        public string charclass = "Basic";
        protected string Attack1Name = "Mana recharge";
        protected string Attack2Name = "Special Attack 1";
        protected string Attack3Name = "Special Attack 2";
        protected string Attack4Name = "Special Attack 3";
        public string texture1 = "       ";
        public string texture2 = "       ";
        public string texture3 = "   O   ";
        public string texture4 = "  /|\\  ";
        public string texture5 = "  / \\  ";
        public string texture1dead = "       ";
        public string texture2dead = "       ";
        public string texture3dead = "       ";
        public string texture4dead = "   o   ";
        public string texture5dead = " /▄█▄\\ ";
        public int damage = 10;
        public int hp = 100;
        public int speed = 16;
        public int maxhp = 100;
        public int maxmana = 100;
        public int mana = 100;
        public int fire = 0;
        public int fireDamage = 0;
        private int poison = 0;
        private int ice = 0;
        public Character(string name)
        {
            this.name = name;
        }
        

        public string ReturnName()
        {
            return charclass;
        }

        public int ReturnHP()
        {
            return hp;
        }

        public int ReturnMaxHP()
        {
            return maxhp;
        }

        public int ReturnSpeed()
        {
            return speed;
        }

        // Allows Player to choose attacks and abilities
        public virtual void Actions(List<Character> list, List<Character> allyList)
        {
            if (hp > 0)
            {
                Console.WriteLine($"[{name} {charclass}]: HP: {hp} Mana: {mana}");
                Console.WriteLine($"{name}: Seleccione su accion:");
                Console.WriteLine($"[1] {Attack1Name}");
                Console.WriteLine($"[2] {Attack2Name}");
                Console.WriteLine($"[3] {Attack3Name}");
                Console.WriteLine($"[4] {Attack4Name}");
                Console.Write("...");
                string? election = Console.ReadLine();
                if (election == "1")
                {
                    Attack(list);
                }
                else if (election == "2")
                {
                    UseSpecialAttack(list);
                }
                else if (election == "3")
                {
                    SecondSpecialAttack(list);
                }
                else
                {
                    ThirdSpecialAttack(list);
                }
            }
            // This else just exist so characters cant have a turn when they die for burning
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


        // Allows player to choose a target
        public virtual Character SelectTarget(List<Character> list)
        {
            Character selection = null;
            foreach (Character character in list)
            {
                Console.WriteLine($"Target: {character.name}, HP: {character.ReturnHP()}");
            }
            while (true)
            {
                Console.Write("Target: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {

                    if (number < list.Count && number >= 0)
                    {
                        selection = list[number];
                        break;
                    }
                    else
                    {
                        Console.Write("Insert a valid target!");
                    }
                }
                else
                {
                    Console.WriteLine("Insert a valid number!");
                }
                
            }
            return selection;
        }


        // Basic mana regeneration, most characters use it
        public virtual void Attack(List<Character> list)
        {
            Console.WriteLine($"{name} recharges mana");
            SetMana(30);
        }

        // First attack
        public virtual void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un ataque especial con {mana} de mana a {target.name}.");
            target.ReciveDamage(damage * 2);
        }

        // Second
        public virtual void SecondSpecialAttack(List<Character> list)
        {
            hp = hp + 5;
            Console.WriteLine($"{name} se curo 5 de vida! Vida actual: {hp}");
        }

        // Third
        public virtual void ThirdSpecialAttack(List<Character> list)
        {
            hp = hp + 5;
            Console.WriteLine($"{name} se curo 5 de vida! Vida actual: {hp}");
        }

        // Allows to recive damage
        public virtual void ReciveDamage(int damage)
        {
            Console.WriteLine($"{name} recives {damage} damage!");
            hp = hp - damage;
            Console.WriteLine($"{name} tiene {hp} de vida...");
            if (hp <= 0) {
                texture1 = texture1dead; 
                texture2 = texture2dead;
                texture3 = texture3dead;
                texture4 = texture4dead;
                texture5 = texture5dead;
                hp = 0;
            }

        }

        // Allows healing
        public void ReciveHeal(int heal)
        {
            if (hp > 0)
            {
                Console.WriteLine($"{name} heals {heal}");
                if (hp + heal <= maxhp)
                {
                    hp += heal;
                }
                else
                {
                    hp = maxhp;
                }
            }
        }

        // Generates random number
        public int Random(int limit)
        {
            Random random = new Random();
            // Generar un número aleatorio en el rango de 1 a 10
            int numeroAleatorio = random.Next(1, limit);
            return numeroAleatorio;
        }

        // Manages all status effects, after its done, it allows the player to act with this character using Actions()
        public void StatusManager(List<Character> list, List<Character> allyList)
        {
            if (fire > 0)
            {
                FireDamage();
            }
            if (poison > 0)
            {
                PoisonDamage();
            }
           
            if (ice > 0)
            {
                IceDamage();
            }
            else
            {
                Actions(list, allyList);
            }
        }

        public void FireDamage()
        {
            Console.WriteLine($"{name} recives {fireDamage} fire damage!");
            hp -= fireDamage;
            fire = fire - 1;
            if (fire != 0){
                Console.WriteLine($"{name} will burn for {fire} more turns");
            }
            else
            {
                Console.WriteLine($"{name} stops buring");
            }
        }
        public void PoisonDamage()
        {
            int poisondamage = (int)Math.Ceiling(poison / 2.0); // Redondear hacia arriba
            Console.WriteLine($"{name} recives {poisondamage} poison!");
            hp = hp - poisondamage;
            poison -= (int)Math.Ceiling(poison / 2.0);
            
            if (poison != 0)
             {
                 Console.WriteLine($"{name} as {poison} poison...");
             }
             else
             {
                 Console.WriteLine($"{name} stops being poisoned.");
             }
        }
       
        public void IceDamage()
        {
            Console.WriteLine($"{name} is frozen!");
            ice = ice - 1;
        }
        public void SetSpeed(int speed)
        {
            this.speed += speed;
        }
        public void SetFire(int fire, int damage)
        {
            if (fireDamage <= damage)
            {
                this.fireDamage = damage;
            }
            this.fire = fire;
        }
        public void SetPoison(int Poison)
        {
            Console.WriteLine($"Pepe {Poison} {poison}");
            poison += Poison;
        }
        public int ReturnPosion()
        {
            return poison;
        }

        public void SetIce(int quantity)
        {
            ice = ice + quantity;
        }
        public void SetMana(int quantity)
        {
            mana = mana + quantity;
            if (mana < 0) 
            {
                mana = 0;
            }
            else if (mana > maxmana)
            {
                mana = maxmana;
            }
                                    
        }
        public int ReturnMana()
        {
            return mana;
        }

        // Allows the class to create a new class of the same type, each character has its how Clone(), used in the creation of enemies
        public virtual object Clone()
        {
            return new Character(charclass);
        }

    }
}