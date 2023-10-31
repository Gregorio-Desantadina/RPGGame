using System;

namespace MyGameProject.Game.GameObjects
{
    public class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
           
        }

        // Does a random action (each enemy usually overrides this, its just an example)
        public override void Actions(List<Character> list, List<Character> allyList)
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
                    texture1 = "       ";
                    texture2 = "       ";
                    texture3 = "       ";
                    texture4 = "   o   ";
                    texture5 = " /▄█▄\\ ";
                    Console.WriteLine($"{name} esta muerto...");
                }
            
}
        // Selects a random target for attacks
        public override Character SelectTarget(List<Character> list)
        {
            Character selection = null;
            Random random = new Random();
            int number = random.Next(list.Count); 
            selection = list[number];
            return selection;
        }

        public override object Clone()
        {
            return new Enemy(charclass);
        }

    }
}