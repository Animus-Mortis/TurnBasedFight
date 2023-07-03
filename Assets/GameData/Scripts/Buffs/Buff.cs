namespace Game.Buffs
{
    [System.Serializable]
    public class Buff
    {
        public string nameBuff;
        public int value;
        public int duration;
        public int durationNow;

        public Buff(string name, int newValue, int newDuration)
        {
            nameBuff = name;
            value = newValue;
            duration = newDuration;
        }
    }
}