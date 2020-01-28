using System.Collections;
using DG.Tweening;
using Game.Graphics.UI.Menu.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Animation = Game.Graphics.UI.Menu.Animations.Animation;

namespace Game.Graphics.UI.Buttons.Custom
{
    public class DelayedButton : Button
    {
        [SerializeField] private UnityEngine.UI.Text _text;

        public void Init(float delay, Animation anim, params UnityAction[] actions)
        {
            foreach (var action in actions)
            {
                onClick.AddListener(() => StartCoroutine(Delayer(delay, anim)));
                onClick.AddListener(action);
            }
        }

        private IEnumerator Delayer(float time, Animation anim)
        {
            var timer = 0f;
            interactable = false;
            var textColor = _text.color;
            anim.Play(0.2f, 6f, AnimationType.Rotating, Ease.Linear);
            DOTween.To(() => textColor.a, x =>  textColor.a = x, 0f, 0.5f).SetDelay(time);
            while (timer < time)
            {
                timer += time;
                yield return new WaitForSeconds(time);
            }
            anim.Stop();
            DOTween.To(() => textColor.a, x =>  textColor.a = x, 0f, 0.5f).SetDelay(time);
            interactable = true;
        }
    }
}