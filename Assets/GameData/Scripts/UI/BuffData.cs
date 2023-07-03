using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class BuffData : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text durationText;

        private string namebuff;

        public void UpdateData(string name, int duration)
        {
            namebuff = name;
            nameText.text = namebuff;
            durationText.text = $"{duration}";
        }

        public string SetName()
        {
            return namebuff;
        }
    }
}