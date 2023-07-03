using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Buffs
{
    public class Buffer : MonoBehaviour, IBuff
    {
        [SerializeField] protected List<Buff> buffs = new List<Buff>();
        [SerializeField] protected BuffViewer buffViewer;

        public virtual void GetBuff(string name, int value, int duration)
        {
            if (!CanAddBuff(name))
                return;

            buffs.Add(new Buff(name, value, duration));
            buffViewer.AddBuff(name, duration);
        }

        public virtual void DeleteBuff(string name)
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                if (buffs[i].nameBuff == name)
                {
                    buffViewer.RemotBuff(name);
                    buffs.Remove(buffs[i]);
                }
            }

        }

        public virtual void CheackDuration()
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