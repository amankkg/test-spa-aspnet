using System;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var sword = new Sword(10);
            var bow = new Bow(4);

            bow.RechargeArrows(5);

            var archer = new Warrior("Archer", bow);
            var swordsman = new Warrior("Swordsman", sword);

            archer.Hit(6);
            swordsman.Hit(2);
            swordsman.Hit(3);
        }
    }

    class Warrior
    {
        public string Name { get; }
        public IWeapon Weapon { get; set; }

        public Warrior(string name, IWeapon weapon)
        {
            Name = name;
            Weapon = weapon;
        }

        public void Hit(int count = 1)
        {
            int totalDamage = 0;

            for (var i = count; i > 0; i--) totalDamage += Weapon.Attack();

            Console.WriteLine($"{Name} deals {totalDamage} damage");
        }
    }

    interface IWeapon
    {
        int Attack();
    }

    class Sword : IWeapon
    {
        public int Damage { get; }

        public Sword(int damage)
        {
            Damage = damage;
        }

        public int Attack() => Damage;
    }

    class Bow : IWeapon
    {
        private int arrowAmount;

        public int Damage { get; }

        public Bow(int damage)
        {
            Damage = damage;
        }

        public void RechargeArrows(int amount) => arrowAmount += amount;

        public int Attack()
        {
            if (arrowAmount == 0) return 0;

            arrowAmount--;

            return Damage;
        }
    }
}
