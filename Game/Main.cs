using System;
using System.ComponentModel;
using MyGameProject.Game.GameObjects;
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
                new Ghost("Ghost"),
                new Esqueleton("Esqueleton"),
                new ArcherEsqueleton("Archer Esqueleton"),
                new Spider("Spider")
            };
            Console.WriteLine("El Juego a Comenzado...");
            Console.Write("Ingrese su nombre: ");
            string? input = Console.ReadLine();

            // Just to test, player will be able to select their characters in the future
            Character Character1 = new  SnakeTamer(input);

            Character Character3 = new Healer("Amigo");

            // Creates 2 empty lists
            List<Character> teamList = CreateCharacterList();
            List<Character> enemyList = CreateCharacterList();

            // adds character to the list
            teamList = AddList(teamList, Character1);
            teamList = AddList(teamList, Character3);

            // Enemy waves (You cant die...)
            EnemyWaves(teamList, enemies);
            enemyList = CreateEnemyList(enemies, enemyList, 2);

            Fight(teamList, enemyList);
        }

        // Generate waves of enemies and send them to Fight(), after some rounds, Characters go to Camping()
        public List<Character> EnemyWaves(List<Character> teamList, List<Character> enemyType)
        {
            List<Character> enemyList = CreateCharacterList();
            int dificulty = 1;
            for (int i = 1; i <= 3; i++) {
                    for(int o = 1; o <= dificulty; o++)
                {
                    enemyList = CreateEnemyList(enemyType, enemyList, o);
                    Fight(teamList, enemyList);
                }
                dificulty += 1;
                teamList = Camping(teamList);
            }
            return teamList;
        }

        // Heals and fully regenerate all members HP/Mana, happens between rounds
        public List<Character> Camping(List<Character> teamList)
        {
            Console.Clear();
            Console.WriteLine("Your team can rest...");
            foreach (var character in teamList)
            {
                character.ReciveHeal(100);
                character.SetMana(100);
            }
            Console.ReadKey();
            Console.Clear();
            return teamList;
        }

        // Creates a random character of given list
        public Character CreateCharacter(List<Character> list)
        {
            Random random = new Random();
            int number = random.Next(list.Count);
            Character character = (Character)list[number].Clone();
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
        public void Fight(List<Character> teamList, List<Character> enemyList)
        {
            while (teamList.Any(c => c.ReturnHP() > 0) && enemyList.Any(c => c.ReturnHP() > 0))
            {
                var allList = teamList.Concat(enemyList).OrderByDescending(c => c.ReturnSpeed());
                foreach (var character in allList)
                {
                    if (character.ReturnHP() > 0)
                    {
                        Console.ReadKey(); 
                        Console.Clear();
                        if (teamList.Contains(character))
                        {
                            character.StatusManager(enemyList, teamList);
                        }
                        else if (enemyList.Contains(character))
                        {
                            character.StatusManager(teamList, teamList);
                        }
                    }
                    else
                    {
                        if (teamList.Contains(character))
                        {
                            teamList.Remove(character);
                        }
                        else if (enemyList.Contains(character))
                        {
                            enemyList.Remove(character);
                        }

                    }
                }
            }
        }
    
        
    }
}