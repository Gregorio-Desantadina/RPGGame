using System;

namespace MyGameProject.Game.GameObjects
{
    public class CursedTree : Enemy
    {
        public CursedTree(string name) : base(name)
        {
            charclass = "Arbol maldito";
            maxhp = 90;
            hp = 90;
            damage = 8;
            speed = 15;
            texture1 = " \\ | |/";
            texture2 = "  \\^/  ";
            texture3 = "  }∞{  ";
            texture4 = "  {o}/ ";
            texture5 = "  } {  ";
        }

        public override void UseSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} golpea a {target.name} con su rama!");
            target.ReciveDamage(damage);
        }
        public override void SecondSpecialAttack(List<Character> list)
        {
            Character target = SelectTarget(list);
            Console.WriteLine($"{name} le roba el mana a {target.name}!");
            target.SetMana(-30);
        }
        public override object Clone()
        {
            return new CursedTree(charclass);
        }
    }
}
