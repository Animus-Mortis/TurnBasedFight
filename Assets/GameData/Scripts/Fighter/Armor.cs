using Game.Buffs;
using Game.UI;
using UnityEngine;

namespace Game.Fighter
{
    public class Armor : Buffer, IArmored
    {
        [Range(0, 100)]
        [SerializeField] private int startArmor;
        [SerializeField] private Bar barArmor;

        private int armor;

        private void Start()
        {
            armor = startArmor;
            barArmor.UpdateBar(armor, 100);
        }

        public void ChangeArmor()
        {
            int buffValue = 0;
            for (int i = 0; i < buffs.Count; i++)
            {
                buffValue += buffs[i].value;
            }

            armor = buffValue;

            if (armor > 100)
                armor = 100;

            if (armor < 0)
                armor = 0;

            barArmor.UpdateBar(armor, 100);
        }

        public int PassedDamage(int damage)
        {
            float passed = damage - (damage / 100f) * armor;

            return (int)passed;
        }

        public override void GetBuff(string name, int value, int duration)
        {
            base.GetBuff(name, value, duration);
            ChangeArmor();
        }

        public override void DeleteBuff(string name)
        {
            base.DeleteBuff(name);
            ChangeArmor();
        }

        public override void CheackDuration()
        {
            base.CheackDuration();
        }
    }
}