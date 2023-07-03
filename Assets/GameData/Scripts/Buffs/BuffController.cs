using UnityEngine;
using UnityEngine.UI;

namespace Game.Buffs
{
    public class BuffController : MonoBehaviour
    {
        [SerializeField] private GameObject fighter;
        [SerializeField] private GameObject[] buffButtons;

        public IBuff[] buffs;

        private void Start()
        {
            buffs = fighter.GetComponents<IBuff>();
            ActiveRandomBuff();
        }

        public void CheackDuration()
        {
            for (int i = 0; i < buffs.Length; i++)
            {
                buffs[i].CheackDuration();
            }
            ActiveRandomBuff();
        }

        public void ActiveRandomBuff()
        {
            int random = Random.Range(0, buffButtons.Length);
            for (int i = 0; i < buffButtons.Length; i++)
            {
                if(i == random)
                {
                    buffButtons[i].SetActive(true);
                    buffButtons[i].GetComponent<Button>().interactable = true;
                }
                else
                {
                    buffButtons[i].SetActive(false);
                }
            }
        }
    }
}