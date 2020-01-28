using System;
using DG.Tweening;
using Game.Graphics.UI.Menu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Graphics.UI.Buttons.Custom
{
    //[RequireComponent]
    public class JumpingButton : Button, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
    {
        private Vector2 _cached;
        private Tween _tween;

        public void Init( params UnityAction[] actions)
        {
            foreach (var action in actions)
            {
                onClick.AddListener(action);
            }
        }

        protected override void Start()
        {
            base.Start();
            _cached = transform.localScale;
        }

        public new void OnPointerDown(PointerEventData eventData)
        {
            _tween = DOTween.To(() => (Vector2)transform.localScale, x => transform.localScale = x,
                new Vector2(0.5f,0.5f), 1f).SetEase(Ease.OutCubic);
        }

        public new void OnPointerUp(PointerEventData eventData)
        {
            DOTween.To(() => (Vector2)transform.localScale, x => transform.localScale = x,
                    new Vector2(1, 1), 1.5f).SetEase(Ease.OutElastic);
        }

        public new void OnPointerExit(PointerEventData eventData)
        {
            //DOTween.To(() => (Vector2)transform.localScale, x => transform.localScale = x,
                  //  new Vector2(1, 1), 1.5f).SetEase(Ease.OutElastic);
        }
    }
}