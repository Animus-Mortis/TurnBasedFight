using Game.Buffs;
using TMPro;
using UnityEngine;

namespace Game.Level
{
    public class Step : MonoBehaviour
    {
        [SerializeField] private TMP_Text stepText;
        [SerializeField] private BuffController[] buffControllers;

        private int stepNumber;

        public void NewStep()
        {
            stepNumber++;
            stepText.text = stepNumber.ToString("00");
            for (int i = 0; i < buffControllers.Length; i++)
            {
                buffControllers[i].CheackDuration();
            }
        }
    }
}