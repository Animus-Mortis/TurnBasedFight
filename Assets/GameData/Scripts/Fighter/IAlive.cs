namespace Game.Fighter
{
    public interface IAlive
    {
        void GetDamage(int damage, Vampirism vampirism = null);
        void GetHealth(int value);

        void Die();
    }
}