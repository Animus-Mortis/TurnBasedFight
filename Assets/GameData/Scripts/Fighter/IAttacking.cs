namespace Game.Fighter
{
    public interface IAttacking
    {
        void ActiveDoubleAttack(int value);
        void DeactiveDoubleAttack();
        void SetGamage();
    }
}