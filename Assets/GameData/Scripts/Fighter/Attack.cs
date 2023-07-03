using Game.Buffs;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Fighter
{
    public class Attack : MonoBehaviour, IAttacking, IBuff
    {
        [SerializeField] private int damage;
        [SerializeField] private Health target;
        [SerializeField] protected BuffViewer buffViewer;

        private int damageMultiplier = 1;
        private Vampirism vampirism;
        private List<Buff> buffs = new List<Buff>();

        private void Start()
        {
            vampirism = GetComponent<Vampirism>();
        }

        public void ActiveDoubleAttack(int value)
        {
            damageMultiplier = value;
        }

        public void DeactiveDoubleAttack()
        {
            damageMultiplier = 1;
        }

        public void SetGamage()
        {
            if (vampirism != null)
                target.GetDamage(damage * damageMultiplier, vampirism);
            else
                target.GetDamage(damage * damageMultiplier);
        }

        public void GetBuff(string name, int value, int duration)
        {
            if (!CanAddBuff(name))
                return;

            buffViewer.AddBuff(name, duration);
            buffs.Add(new Buff(name, value, duration));
            if(name == "DoubleAttack")
            {
                ActiveDoubleAttack(value);
            }
        }

        public void DeleteBuff(string name)
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                if (buffs[i].nameBuff == name)
                {
                    if (name == "DoubleAttack")
                    {
                        print(2);
                        DeactiveDoubleAttack();
                    }
                    buffViewer.RemotBuff(name);
                    buffs.Remove(buffs[i]);
                }
            }

        }

        public void CheackDuration()
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                buffs[i].durationNow++;
                buffViewer.UpdateData(buffs[i].nameBuff, buffs[i].duration - buffs[i].durationNow);
                if (buffs[i].duration == buffs[i].durationNow)
                    DeleteBuff(buffs[i].nameBuff);
            }
        }

        private bool CanAddBuff(string buffName)
        {
            if (buffs.Count == 2)
                return false;

            for (int i = 0; i < buffs.Count; i++)
            {
                if (buffs[i].nameBuff == buffName)
                    return false;
            }

            return true;
        }
    }
}