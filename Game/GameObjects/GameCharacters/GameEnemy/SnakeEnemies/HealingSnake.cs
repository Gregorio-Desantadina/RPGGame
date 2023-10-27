using System;

namespace MyGameProject.Game.GameObjects
{
    public class HealingSnake : Enemy
    {
        public HealingSnake(string name) : base(name)
        {
            charclass = "Healing Snake";
            maxhp = 20;
            hp = 20;
            damage = 6;
            speed = 10;
        }

        public override void Actions(List<Character> list, List<Character> allyList)
        {
            // Orders the list depending on the difference between maxHP and actual HP, characters with bigger gap will go first
            var orderedList = list.OrderByDescending(c => c.ReturnMaxHP() - c.ReturnHP()).ToList();
            int i = orderedList[0].ReturnHP();
            int a = orderedList[0].ReturnMaxHP();
            if (hp > 0)
            {
                // If any character has less HP than max HP the serpent heals, else it just attack
                if (a > i)
                {
                    UseSpecialAttack(allyList);
                }
                else
                {
                    SecondSpecialAttack(list);
                }
            }
            else
            {
                Console.WriteLine($"{name} dies...");
            }
        }
        public override void UseSpecialAttack(List<Character> list)
        {
            // This list contains all allies orderd depending on their hp, it allows the snake to always heal the most damaged one
            var orderedList = list.OrderByDescending(c => c.ReturnMaxHP() - c.ReturnHP()).ToList();
            Character target = orderedList[0];
            mana = mana - 35;
            Console.WriteLine($"{name}'s poison heals {target.name}.");
            target.ReciveHeal(damage *2 + (Random(4)));
        }

        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} realiza un golpe fuerte a {target.name}!");
            target.ReciveDamage(damage);
        }

        public override object Clone()
        {
            return new HealingSnake(charclass);
        }
    }
}