using UnityEngine;
using UnityEngine.UI;

namespace Game.Level
{
    public class EndOfTurn : MonoBehaviour
    {
        [SerializeField] private Step step;

        [Header("Left Fighter")]
        [SerializeField] private Button leftAttackButton;
        [SerializeField] private GameObject leftControllPanel;

        [Header("Right Fighter")]
        [SerializeField] private Button rightAttackButton;
        [SerializeField] private GameObject rightControllPanel;

        private void Start()
        {
            leftControllPanel.SetActive(true);
            rightControllPanel.SetActive(false);

            leftAttackButton.onClick.AddListener(EndLeftTurn);
            rightAttackButton.onClick.AddListener(EndRightTurn);
        }

        private void EndLeftTurn()
        {
            leftControllPanel.SetActive(false);
            rightControllPanel.SetActive(true);
        }
        private void EndRightTurn()
        {
            leftControllPanel.SetActive(true);
            rightControllPanel.SetActive(false);
            step.NewStep();
        }
    }
}