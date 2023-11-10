using System;
using System.ComponentModel;
using MyGameProject.Game.GameObjects;
using System.Drawing;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;


namespace MyGameProject.Game.Start

{
    public class Main
    {
        static Random random = new Random();

        public void Start()
        {
            // List of possible enemies (Later will move to another document)
            List<Character> enemies = new List<Character>
            {
                new Ghost("Fantasma"),
                new Esqueleton("Esqueleto"),
                new ArcherEsqueleton("Arquero Esqueleto"),
                new Spider("Araña")
            };
            List<Character> enemiesJungle = new List<Character>
            {
                new DartThrower("Lanza dardos"),
                new CursedTree("Arbol maldito"),
                new Lancer("Lancero"),
                new Worm("Larva")
            };

            List<Character> allies = new List<Character>
            {
                new Assassin("Hoshi"),
                new Berserk("Galera"),
                new Executioner("Onika"),
                new Healer("Yukishiro"),
                new FireMage("Salem"),
                new IceMage("Ayame"),
                new SnakeTamer("Kobra"),
                new Hitter("Bibi"),
                new Necromancer("Mortis"),
                new Shield("Sin nombre")
            };

            /*string? input = Console.ReadLine();*/

            // Just to test, player will be able to select their characters in the future






            // Creates 2 empty lists

            List<Character> teamList = CreateCharacterList();
            List<Character> enemyList = CreateCharacterList();

            Console.WriteLine("Quieres realizar el tutorial? (Y/N): ");
            string? input = Console.ReadLine();
            Console.Clear();
            if ((input == "y") || (input == "Y") || (input == "Yes") || (input == "yes"))
            {

                teamList.Add(Tutorial(allies));
                Tutorial2(teamList);
            }
            else
            {

                teamList.Add(CharacterSelector(allies));
            }
            if (teamList.Count() > 1)
            {
                teamList.Remove(teamList[1]);
            }
            if (teamList.Count() > 1)
            {
                teamList.Remove(teamList[1]);
            }
            do
            {
                Character character = CreateCharacter(allies);
                if (allies.Any(Character => Character != character))
                {
                    Console.Clear();
                    Console.WriteLine($"En el camino encuentras a un {character.ReturnName()} que se une a tu equipo");
                    teamList.Add(character);
                    break;
                }

            } while (true);
            Console.ReadKey();
            Camping(teamList);



            // Enemy waves (You cant die...)
            EnemyWaves(teamList, enemies, 1);
            if (teamList.Count <= 1 && teamList.Count != 0)
            {
                Character character = CreateCharacter(allies);
                Console.Clear();
                Console.WriteLine($"En el camino encuentras a un {character.ReturnName()} que se une a tu equipo");
                teamList.Add(character);
                Console.ReadKey();
            }

            // Returns all values to original
            foreach (var character in teamList) 
            {
                if(character is Hitter)
                {
                    character.maxmana = 60;
                    character.mana = 60;
                }
            }

            EnemyWaves(teamList, enemiesJungle, 2);
            enemyList = CreateEnemyList(enemiesJungle, enemyList, 2);
            Fight(teamList, enemyList, 1, 1);
        }

        public Character CharacterSelector(List<Character> list)
        {
            int charNumber = 0;

            while (true)
            {

                Console.WriteLine($"{list[charNumber].ReturnName()} [HP:{list[charNumber].maxhp}] [Mana:{list[charNumber].maxmana}] [Velocidad: {list[charNumber].speed}]");
                for (int i = 0; i <= 4; i++)
                {
                    PrintPart(list[charNumber], i);
                    Console.WriteLine("");
                }
                Console.WriteLine(list[charNumber].characterDescription);
                Console.WriteLine($"[↑] Personaje anterior");
                Console.WriteLine($"[Enter] Seleccionar personaje");
                Console.WriteLine($"[↓] Personaje siguente");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    charNumber = (charNumber + 1) % list.Count;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    charNumber = (charNumber - 1 + list.Count) % list.Count;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.Clear();
            }
            return list[charNumber];
        }

        public Character Tutorial(List<Character> list)
        {
            Console.WriteLine("Bienvenido al tutorial!");
            Console.WriteLine("Ahora aprenderemos las mecanicas basicas del juego, presione enter para comenzar.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Este juego es un RPG por turnos, lo que significa que nos enfrentaremos a diversos enemigos usando diferentes personajes. \nCada uno de ellos tiene diferentes habilidades y caracteristicas unicas.\nComienza eligiendo tu primer personaje (Nuevos personajes se uniran a tu equipo con el tiempo)");
            Console.ReadKey();
            Console.Clear();
            return CharacterSelector(list);
        }

        public void Tutorial2(List<Character> list)
        {

            Console.Clear();
            Console.WriteLine("Ahora aprenderas las bases del combate.");
            Console.WriteLine("Cada personaje cuenta con puntos de vida (HP) y energia (Mana)");
            Console.WriteLine("Por ronda, cara personaje tendra un turno, el orden dependera de la velocidad de los personajes.");
            Console.WriteLine("Cuando un personaje tiene 0 de HP, este muere y desaparece de tu equipo, si no tienes personajes en tu equipo pierdes.");
            Console.WriteLine("Los personajes utilizan mana para atacar, cada ataque tiene un cierto coste, \nintentar utilizar un ataque sin cumplir los requerimientos de mana te hara perder un turno");
            Console.WriteLine("Ahora comenzara una batalla tutorial, ingresa el numero del ataque que quieras realizar y luego selecciona al objetivo del ataque. \n(ingresar algo que no sea un numero de ataque te hara realizar el cuarto ataque) \n");
            Console.ReadKey();
            Console.Clear();
            List<Character> trainingEnemies = CreateCharacterList();
            trainingEnemies.Add(new Dummy("Maniqui de entrenamiento"));
            Fight(list, trainingEnemies, 0, 1);

        }

        // Generate waves of enemies and send them to Fight(), after some rounds, Characters go to Camping()
        public List<Character> EnemyWaves(List<Character> teamList, List<Character> enemyType, int boss)
        {
            List<Character> enemyList = CreateCharacterList();
            int dificulty = 1;
            for (int i = 1; i <= 3; i++)
            {
                for (int o = 1; o <= dificulty; o++)
                {
                    enemyList = CreateEnemyList(enemyType, enemyList, o);
                    Fight(teamList, enemyList, dificulty, o);
                    if (teamList.Count == 0)
                    {
                        break;
                    }
                }
                if (teamList.Count == 0)
                {
                    break;
                }
                dificulty += 1;



                if (teamList.Any(c => c.ReturnHP() > 0))
                {
                    Console.Clear();
                    Camping(teamList);
                }


                else
                {
                    FinishedGame(0);
                }

            }
            if (teamList.Count == 0)
            {
                Console.WriteLine("Perdiste!");
            }
            else if (dificulty >= 3)
            {
                if (boss == 1)
                {
                    enemyList.Add(new EsqueletonKing("Rey Esquelto"));
                }
                else if (boss == 2)
                {
                    enemyList.Add(new BossWine1("Latigo carnivoro"));
                    enemyList.Add(new PlantBoss("Capullo gigante"));
                    enemyList.Add(new BossWine2("Latigo venenoso"));
                }

                Fight(teamList, enemyList, dificulty, 1);
                if (teamList.Count != 0 && boss == 2)
                {
                    FinishedGame(1);
                }

            }
            return teamList;
        }

        // Heals and fully regenerate all members HP/Mana, happens between rounds
        public List<Character> Camping(List<Character> teamList)
        {
            List<Character> emptyList = new List<Character>();
            List<Character> removeList = new List<Character>();
            Console.Clear();
            Console.WriteLine("Tu equipo acampa y recupera su salud y energia...");
            foreach (var character in teamList)
            {
                if (character is Enemy)
                {
                    removeList.Add(character);
                }
                else
                {
                    character.ReciveHeal(100);
                    character.SetMana(100);
                }
            }
            while (removeList.Count() != 0)
            {
                teamList.Remove(removeList[0]);
                removeList.Remove(removeList[0]);
                if (removeList.Count() == 0)
                {
                    break;
                }
            }
            PrintCharacters(teamList, emptyList);
            Console.ReadKey();
            Console.Clear();
            return teamList;
        }

        // Create the textures for the game!
        public void PrintCharacters(List<Character> list, List<Character> list2)
        {

            List<Character> list3 = new List<Character>();
            if (list.Count > list2.Count)
            {
                list3 = list;
            }
            else
            {
                list3 = list2;
            }
            for (int o = 0; o <= list3.Count; o += 3)
            {

                for (int i = 0; i <= 6; i++)
                {

                    Console.Write($"   ");
                    if (list.Count > o && list[o] != null)
                    {
                        PrintPart(list[o], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (list.Count > o + 1 && list[o + 1] != null)
                    {

                        PrintPart(list[o + 1], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (list.Count > o + 2 && list[o + 2] != null)
                    {

                        PrintPart(list[o + 2], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    Console.Write("          ");
                    if (list2.Count > o && list2[o] != null)
                    {

                        PrintPart(list2[o], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (list2.Count > o + 1 && list2[o + 1] != null)
                    {

                        PrintPart(list2[o + 1], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (list2.Count > o + 2 && list2[o + 2] != null)
                    {

                        PrintPart(list2[o + 2], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }

                    Console.WriteLine(" ");
                }
            }

        }
        public void PrintPart(Character character, int number)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (number == 0)
            {
                Console.Write($"{character.texture1}  ");
            }
            if (number == 1)
            {
                Console.Write($"{character.texture2}  ");
            }
            if (number == 2)
            {
                Console.Write($"{character.texture3}  ");
            }
            if (number == 3)
            {
                Console.Write($"{character.texture4}  ");
            }
            if (number == 4)
            {
                Console.Write($"{character.texture5}  ");
            }
            if (number == 5)
            {
                int hp = character.ReturnHP();
                Console.Write($" {character.hp}/{character.maxhp}  ");
            }

        }

        // Creates a random character of given list
        public Character CreateCharacter(List<Character> list)
        {
            Random random = new Random();
            int number = random.Next(list.Count);
            Character character = (Character)list[number].Clone();
            character.name = list[number].name;
            return character;
        }

        // Creates a list of enemies depending on number given, uses CreateCharacter()
        public List<Character> CreateEnemyList(List<Character> list, List<Character> otherList, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Character character = CreateCharacter(list);
                otherList.Add(character);
            }
            return otherList;
        }

        // Creates a list of characters (Empty)
        public List<Character> CreateCharacterList()
        {
            List<Character> CharacterList = new List<Character>();
            return CharacterList;
        }

        // Adds any given character to given list
        public List<Character> AddList(List<Character> list, Character character)
        {
            list.Add(character);
            return list;
        }

        

        // This makes 2 list of characters fight, the turns are distributed depending on speed
        public void Fight(List<Character> teamList, List<Character> enemyList, int level, int wave)
        {

            while (teamList.Any(c => c.ReturnHP() > 0) && enemyList.Any(c => c.ReturnHP() > 0))
            {
                var allList = teamList.Concat(enemyList).OrderByDescending(c => c.ReturnSpeed());
                foreach (var character in allList)
                {
                    if (teamList.Contains(character) && character.ReturnHP() <= 0)
                    {
                        teamList.Remove(character);
                    }
                    if (teamList.Any(obj => obj.ReturnHP() > 0) || enemyList.Any(obj => obj.ReturnHP() > 0))
                    {

                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine($"Nivel[{level}] Oleada[{wave}]");
                        PrintCharacters(teamList, enemyList);
                        if (teamList.Contains(character) && enemyList.Count() >= 1)
                        {
                            character.StatusManager(enemyList, teamList);
                        }
                        else if (enemyList.Contains(character) && teamList.Count() >= 1)
                        {
                            character.StatusManager(teamList, enemyList);
                        }
                        foreach (var chara in allList)
                        {
                            if (enemyList.Contains(chara) && chara.ReturnHP() <= 0)
                            {
                                enemyList.Remove(chara);
                                foreach(var character2 in teamList)
                                {
                                    if (character2 is Necromancer)
                                    {
                                        character2.Corpses(chara);
                                    }
                                }
                            }
                            if (teamList.Contains(chara) && chara.ReturnHP() <= 0)
                            {
                                teamList.Remove(chara);
                            }
                        }


                    }
                }
            }
            if (teamList.Any(c => c.ReturnHP() > 0))
            {
                enemyList.Clear();
            }
            else
            {
                FinishedGame(0);
            }
        }
        public void FinishedGame(int result)
        {
            if (result == 1)
            {
                Console.WriteLine("Ganaste!");
            }
            else
            {
                Console.WriteLine("Perdiste");
            }
            Console.Write("Quieres jugar otra vez? Y/N: ");
            Console.Clear();
            Console.ReadKey();
            Start();
        }


    }
}