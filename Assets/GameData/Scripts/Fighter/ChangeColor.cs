using System.Collections;
using UnityEngine;

namespace Game.Fighter
{
    public class ChangeColor : MonoBehaviour
    {
        [SerializeField] private Color gamageColor;
        [SerializeField] private float timeColorChange;

        private Material material;
        private Color startColor;
        private Color newColor;
        private Coroutine changeCoroutine;

        private void Start()
        {
            material = GetComponent<MeshRenderer>().material;
            startColor = newColor = material.color;
        }

        public void GoChangeColor()
        {
            if (changeCoroutine == null)
                changeCoroutine = StartCoroutine(colorChange());
        }

        private IEnumerator colorChange()
        {
            float timer = 0;
            while (timer < timeColorChange/2)
            {
                timer += Time.deltaTime;
                newColor = Color.Lerp(startColor, gamageColor, timeColorChange - (timeColorChange / 2 - timer));
                material.color = newColor;
                yield return null;
            }
            while(timer < timeColorChange)
            {
                timer += Time.deltaTime;
                newColor = Color.Lerp(gamageColor, startColor, timeColorChange - (timeColorChange - timer));
                material.color = newColor;
                yield return null;
            }

            changeCoroutine = null;
        }
    }
}