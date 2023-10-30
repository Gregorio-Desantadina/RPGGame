﻿using System;
using System.ComponentModel;
using MyGameProject.Game.GameObjects;
using System.Drawing;


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
            Character Character3 = new  IceMage(input);

            Character Character1 = new Assassin("Amigo");


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
                    enemyList = CreateEnemyList(enemyType, enemyList, 2);
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

        // Create the textures for the game!
        public void PrintCharacters(List<Character> list, List<Character> list2)
        {
            
            List<Character> list3 = new List<Character>();
            if(list.Count > list2.Count)
            {
                list3 = list;
            }
            else
            {
                list3 = list2;
            }
            for (int o = 0; o <= list3.Count; o+=3)
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
                    if (list.Count > o+1 && list[o+1] != null)
                    {

                        PrintPart(list[o+1], i);
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (list.Count > o+2 && list[o+2] != null)
                    {

                        PrintPart(list[o+2], i);
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
            if(number == 5)
            {
                int hp = character.ReturnHP();
                Console.Write($"HP={character.hp}   ");
            }

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
                    if (teamList.Any(obj => obj.ReturnHP() > 0) || enemyList.Any(obj => obj.ReturnHP() > 0))
                    {
                        Console.ReadKey(); 
                        Console.Clear();
                        PrintCharacters(teamList, enemyList);
                        if (teamList.Contains(character))
                        {
                            character.StatusManager(enemyList, teamList);
                        }
                        else if (enemyList.Contains(character))
                        {
                            character.StatusManager(teamList, teamList);
                        }
                    }
                    Console.WriteLine("Hola mundo!");
                }
            }

            enemyList.Clear();
            
            Console.WriteLine("Hola muntetedo!");
        }
    
        
    }
}