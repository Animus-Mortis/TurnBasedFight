using Game.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Buffs
{
    public class BuffButton : MonoBehaviour
    {
        [SerializeField] private BuffData[] buffDatas;

        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnButton);
        }

        private void TaskOnButton()
        {
            for (int i = 0; i < buffDatas.Length; i++)
            {
                buffDatas[i].InvokeEnevt();
            }

            button.interactable = false;
        }

        [System.Serializable]
        private class BuffData
        {
            public string nameBuff;
            public int value;
            public int duration;
            public UnityEvent<string, int, int> buffEvent;

            public void InvokeEnevt()
            {
                buffEvent?.Invoke(nameBuff, value, duration);
            }
        }
    }
}