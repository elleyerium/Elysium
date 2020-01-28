using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Menu.Animations
{
    [RequireComponent(typeof(Image))]
    public class Animation : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Play(float timePerLoop, float totalTime , AnimationType animType, Ease easeType)
        {
            var loops = Mathf.RoundToInt(totalTime / timePerLoop);
            var color = _image.color;
            _image.gameObject.SetActive(true);
            DOTween.To(() => _image.color, x => _image.color = x
                , new Color(color.r, color.g, color.b, 1), 0.5f);
            switch (animType)
            {
                case AnimationType.Scaling:
                    DOTween.To(() => (Vector2)_image.transform.localScale
                            , x => _image.transform.localScale = x
                            , new Vector2(1f,1f), timePerLoop).SetEase(easeType)
                        .SetLoops(loops, LoopType.Yoyo);
                    break;
                case AnimationType.Rotating:
                    DOTween.To(() => _image.transform.rotation
                            , x => _image.transform.rotation = x
                            , new Vector3(0,0, -180), timePerLoop).SetEase(easeType)
                        .SetLoops(loops, LoopType.Incremental);
                    break;
                case AnimationType.ScalingAndRotating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animType), animType, null);
            }
        }

        public void Play(float time, int loopsCount, AnimationType animType, Ease easeType)
        {
            var color = _image.color;
            _image.gameObject.SetActive(true);
            DOTween.To(() => _image.color, x => _image.color = x
                , new Color(color.r, color.g, color.b, 1), 0.5f);
            Debug.Log(animType.ToString());
            switch (animType)
            {
                case AnimationType.Scaling:
                    DOTween.To(() => (Vector2)_image.transform.localScale
                            , x => _image.transform.localScale = x
                            , new Vector2(1f,1f), time).SetEase(easeType)
                        .SetLoops(loopsCount, LoopType.Yoyo);
                    break;
                case AnimationType.Rotating:
                    DOTween.To(() => _image.transform.rotation
                            , x => _image.transform.rotation = x
                            , new Vector3(0,0, -180), time).SetEase(easeType)
                        .SetLoops(loopsCount, LoopType.Incremental);
                    break;
                case AnimationType.ScalingAndRotating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animType), animType, null);
            }
        }

        public void Play(float time, int loopsCount, AnimationType animType, Ease easeType, Screen.Screen panelToHide)
        {
            var color = _image.color;
            //Screen.Screen.HideOrShowScreen(0.2f, panelToHide);
            _image.gameObject.SetActive(true);
            DOTween.To(() => _image.color, x => _image.color = x
                , new Color(color.r, color.g, color.b, 1), 0.5f);
            Debug.Log(animType.ToString());
            switch (animType)
            {
                case AnimationType.Scaling:
                    DOTween.To(() => (Vector2)_image.transform.localScale
                            , x => _image.transform.localScale = x
                            , new Vector2(1f,1f), time).SetEase(easeType)
                        .SetLoops(loopsCount, LoopType.Yoyo);
                    break;
                case AnimationType.Rotating:
                    DOTween.To(() => _image.transform.rotation
                            , x => _image.transform.rotation = x
                            , new Vector3(0,0, -180), time).SetEase(easeType)
                        .SetLoops(loopsCount, LoopType.Incremental);
                    break;
                case AnimationType.ScalingAndRotating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animType), animType, null);
            }
        }

        public void Stop()
        {
            var color = _image.color;
            DOTween.To(() => _image.color, x => _image.color = x, new Color(color.r, color.g, color.b, 0), 0.5f)
                .OnComplete(() => _image.gameObject.SetActive(false))
                .OnComplete(() =>_image.transform.rotation = new Quaternion(0,0,0,0));

        }

        public void Stop(CanvasGroup panelToShow)
        {
            var color = _image.color;
            DOTween.To(() => _image.color, x => _image.color = x, new Color(color.r, color.g, color.b, 0), 0.5f)
                .OnComplete(() => _image.gameObject.SetActive(false))
                .OnComplete(() =>_image.transform.rotation = new Quaternion(0,0,0,0));

        }
    }

    public enum AnimationType
    {
        Scaling,
        Rotating,
        ScalingAndRotating
    }
}