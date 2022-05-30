namespace RPGame.Model
{
    public class Character
    {
        public static int AttackPoints(int attacker, int defenser)
        {
            return attacker - defenser;
        }
    }
}