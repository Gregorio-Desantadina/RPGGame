﻿using System;
using System.ComponentModel;
using MyGameProject.Game.GameObjects;
namespace MyGameProject.Game.Start
{
    public class Main
    {
        public void Start()
        {
            Console.WriteLine("El Juego a Comenzado.");
            Console.Write("Ingrese su nombre: ");
            string? input = Console.ReadLine();

            Executioner Character1 = new Executioner(input);

            Esqueleton Character2 = new Esqueleton("Esqueleton1");

            Character Character3 = new Berserk ("Amigo");


            Character Character5 = new Esqueleton("Esqueleton2");

            List<Character> teamList = CreateCharacterList();
            List<Character> enemyList = CreateCharacterList();
           
            teamList = AddList(teamList, Character1);
            teamList = AddList(teamList, Character3);
            enemyList = AddList(enemyList, Character2);
            enemyList = AddList(enemyList, Character5);

            Fight(teamList, enemyList);
        }

        public List<Character> CreateCharacterList()
        {
            List<Character> CharacterList = new List<Character>();
            return CharacterList;
        }

        public List<Character> AddList(List<Character> list, Character character)
        {
            list.Add(character);
            return list;
        }

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
                            character.StatusManager(enemyList);
                        }
                        else if (enemyList.Contains(character))
                        {
                            character.StatusManager(teamList);
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