using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image barImage;
        [SerializeField] private TMP_Text valueText;

        public void UpdateBar(int value, int maxValue)
        {
            if(value < 0)
                value = 0;

            valueText.text = $"{value}/{maxValue}";
            barImage.fillAmount = ((value * 100) / maxValue) / 100f;
        }
    }
}