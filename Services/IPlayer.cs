using RPGame.Model;

namespace RPGame.Services
{
    public interface IPlayer
    {
        Player StartNewGame(string name);
        bool SavingGame(Player updatedPlayer);
        Player? GetPlayer();
        bool Delete();
    }
}