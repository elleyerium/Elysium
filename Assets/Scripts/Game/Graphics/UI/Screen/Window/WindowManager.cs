using DG.Tweening;
using UnityEngine;

namespace Game.Graphics.UI.Screen.Window
{
    public class WindowManager : MonoBehaviour
    {
        public static void Show(Window window)
        {
            if (window.IsActive)
                return;
            window.IsActive = true;
            window.CanvasGroup.gameObject.SetActive(true);
            window.CanvasGroup.interactable = window.CanvasGroup.blocksRaycasts = true;
            DOTween.To(() => window.CanvasGroup.alpha, x => window.CanvasGroup.alpha = x, 1f, 0.3f);
        }

        public static void Hide(Window window)
        {
            if (!window.IsActive)
                return;
            window.IsActive = false;
            window.CanvasGroup.interactable = window.CanvasGroup.blocksRaycasts = false;
            DOTween.To(() => window.CanvasGroup.alpha, x => window.CanvasGroup.alpha = x, 0f, 0.3f);
        }
    }
}