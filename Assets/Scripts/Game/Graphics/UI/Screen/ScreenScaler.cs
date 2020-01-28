using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Graphics.UI.Screen
{
    public class ScreenScaler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Slider _slider;
        private CanvasScaler[] _canvasScalers;

        private void Start() =>
        _canvasScalers = FindObjectsOfType<CanvasScaler>();

        private void Handle()
        {
            foreach (var scaler in _canvasScalers)
            {
                var refRes = new Vector2(1920, 1080);
                var slValue = _slider.value;
                DOTween.To(() => scaler.referenceResolution, x => scaler.referenceResolution = x,
                    new Vector2(refRes.x / slValue, refRes.y / slValue), 0.5f);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Handle();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}