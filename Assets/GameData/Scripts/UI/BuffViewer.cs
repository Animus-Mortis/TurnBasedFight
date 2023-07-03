using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class BuffViewer : MonoBehaviour
    {
        [SerializeField] private Transform panelView;
        [SerializeField] private BuffData prefabBuff;

        private List<BuffData> buffDatas = new List<BuffData>();

        public void AddBuff(string name, int duration)
        {
            BuffData newBuff = Instantiate(prefabBuff, panelView);
            newBuff.UpdateData(name, duration);
            buffDatas.Add(newBuff);
        }

        public void RemotBuff(string name)
        {
            for (int i = 0; i < buffDatas.Count; i++)
            {
                if(buffDatas[i].SetName() == name)
                {
                    Destroy(buffDatas[i].gameObject);
                    buffDatas.Remove(buffDatas[i]);
                }
            }
        }

        public void UpdateData(string name, int duration)
        {
            for (int i = 0; i < buffDatas.Count; i++)
            {
                if (buffDatas[i].SetName() == name)
                {
                    buffDatas[i].UpdateData(name, duration);
                }
            }
        }
    }
}