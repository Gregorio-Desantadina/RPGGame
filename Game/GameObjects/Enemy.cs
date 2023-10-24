using System;

namespace MyGameProject.Game.GameObjects
{
    public class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
           
        }

        public override void Actions(List<Character> list)
        {
            if (hp > 0) {
                int election = (Random(4));
                if (election == 1)
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
                Console.WriteLine($"{name} dies...");
            }
}
        public override Character SelectTarget(List<Character> list)
        {
            Character selection = null;
            Random random = new Random();
            int number = random.Next(list.Count); 
            selection = list[number];
            return selection;
        }


    }
}