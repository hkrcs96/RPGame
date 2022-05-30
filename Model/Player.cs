namespace RPGame.Model
{
    public class Player : Character
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Healing { get; private set; }
        public int Strength { get; private set; }
        public int Defense { get; private set; }
        public int Kills { get; private set; }
        public Player(string name)
        {
            this.Name = name;
            this.Id = 1;
            this.Healing = 2;
            this.Health = 50;
            this.MaxHealth = 50;
            this.Strength = 10;
            this.Kills = 0;
            this.Defense = (int)(Math.Ceiling(this.Strength * 0.25));
        }

        public void Attack()
        {
            var enemy = Enemy.Instance;

            int attackPoints = AttackPoints(this.Strength, enemy.Defense);
            enemy.GetDamage(attackPoints);

            if (enemy.Health <= 0)
            {
                LevelUp();
                HealPlayer();
            }
            else
            {
                attackPoints = AttackPoints(enemy.Strength, this.Defense);
                GetDamage(attackPoints);
            }
        }

        private void HealPlayer()
        {
            if ((Health += Healing) >= MaxHealth) Health = MaxHealth;
            else Health += Healing;
        }
        private void LevelUp()
        {
            Healing += 1;
            MaxHealth += 5;
            Kills += 1;
            Defense = (int)(Math.Ceiling(this.Strength * 0.25));
            if (Kills % 5 == 0) Health = MaxHealth;
        }
        private void GetDamage(int damagePoints)
        {
            this.Health -= damagePoints;
        }
    }
}