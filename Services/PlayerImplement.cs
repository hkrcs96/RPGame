using RPGame.Context;
using RPGame.Model;

namespace RPGame.Services
{
    public class PlayerImplement : IPlayer
    {
        private RPGameSQLiteContext _context;

        public PlayerImplement(RPGameSQLiteContext context)
        {
            _context = context;
        }
        public Player StartNewGame(string name)
        {
            Player newPlayer = new Player(name);
            SavingGame(newPlayer);
            return newPlayer;
        }
        public bool SavingGame(Player updatedPlayer)
        {
            var player = GetPlayer();
            if (player == default || player == null)
            {
                _context.Add(updatedPlayer);
                _context.SaveChanges();
                return true;
            }
            else
            {
                _context.Entry(player).CurrentValues.SetValues(updatedPlayer);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Delete()
        {
            Player? player = GetPlayer();
            if (player?.Id == 1)
            {
                _context.Remove(player);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public Player? GetPlayer()
        {
            return _context.Players.SingleOrDefault(p => p.Id.Equals(1));
        }
    }
}