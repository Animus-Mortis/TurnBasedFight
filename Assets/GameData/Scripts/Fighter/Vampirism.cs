using Game.Buffs;
using Game.UI;
using UnityEngine;

namespace Game.Fighter
{
    public class Vampirism : Buffer, IVampire
    {
        [Range(0, 100)]
        [SerializeField] private int vampirePower;
        [SerializeField] private Bar barVampire;

        private Health health;

        private void Start()
        {
            health = GetComponent<Health>();
            barVampire.UpdateBar(vampirePower, 100);
        }

        public void TakeHealth(int damage)
        {
            health.GetHealth((int)((damage / 100f) * vampirePower));
        }

        public void ChangeVampirePower()
        {
            int buffValue = 0;

            for (int i = 0; i < buffs.Count; i++)
            {
                buffValue += buffs[i].value;
            }

            vampirePower = buffValue;

            if (vampirePower > 100)
                vampirePower = 100;

            if (vampirePower < 0)
                vampirePower = 0;

            barVampire.UpdateBar(vampirePower, 100);
        }

        public void VampirePowerDowngrade(int value)
        {
            vampirePower -= value;
            if (vampirePower < 0)
                vampirePower = 0;

            barVampire.UpdateBar(vampirePower, 100);
        }

        public override void GetBuff(string name, int value, int duration)
        {
            base.GetBuff(name, value, duration);
            ChangeVampirePower();
        }

        public override void DeleteBuff(string name)
        {
            base.DeleteBuff(name);

            ChangeVampirePower();
        }

        public override void CheackDuration()
        {
            base.CheackDuration();
        }
    }
}