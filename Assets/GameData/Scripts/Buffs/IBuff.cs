namespace Game.Buffs
{
    public interface IBuff
    {
        void GetBuff(string name, int value, int duration);
        void DeleteBuff(string name);
        void CheackDuration();
    }
}