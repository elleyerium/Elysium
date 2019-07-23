using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Scale
{
    public class UI_Scaler : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Scale()
        {
            foreach (var rect in FindObjectsOfType<RectTransform>())
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x * _slider.value, rect.sizeDelta.y * _slider.value);
            }
        }
    }
}