using Moq;

namespace RPGame.Model
{
    public class Enemy : Character
    {
        private static Enemy? _enemy = null;
        public string? Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Defense { get; private set; }
        public int Level { get; private set; }

        private Enemy() { }

        public static Enemy Instance
        {
            get
            {
                if (_enemy == null) _enemy = new Enemy();
                return _enemy;
            }
        }
        public void GenerateEnemyProperties(int playerStrength,
                                            int playerMaxHealth,
                                            int playerKills)
        {
            Random random = new Random();
            string[] names = new string[] { "Nyx", "Akuji", "Hecate", "Thanatos", "Laverna", "Appius" };
            this.Name = names[random.Next(0, names.Length + 1)];
            this.Defense = random.Next(0, playerStrength / 2);
            this.Health = random.Next(playerMaxHealth - (playerMaxHealth / 2), playerMaxHealth);
            this.Strength = random.Next(playerStrength - (playerStrength / 2), playerStrength);
            this.Level = playerKills + 1;
        }

        public void GetDamage(int damageValue)
        {
            this.Health -= damageValue;
        }
    }
}