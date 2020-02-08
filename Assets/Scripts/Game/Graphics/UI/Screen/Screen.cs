using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Graphics.UI.Screen
{
    public class Screen : MonoBehaviour
    {
        internal bool IsActive, CanReturn;
        public CanvasGroup CanvasGroup;

        public static void HideOrShowScreen(float time, Screen screen)
        {
            Debug.Log($"{screen.GetType()} {screen.IsActive}");
            var group = screen.CanvasGroup;
            if (!screen.IsActive)
            {
                screen.IsActive = false;
                group.interactable = group.blocksRaycasts = false;
                DOTween.To(() => group.alpha, x => group.alpha = x, 0f, time).OnComplete(() => group.gameObject.SetActive(true));
                if(screen.CanReturn)
                    HideOrShowScreen(0.5f, ScreenManager.Instance.GetScreen(ScreenType.MainScreen));
            }
            else
            {
                screen.IsActive = true;
                group.gameObject.SetActive(true);
                group.interactable = group.blocksRaycasts = true;
                DOTween.To(() => group.alpha, x => group.alpha = x, 1f, time);
            }
        }

        public static void ShowThenHide(float time, CanvasGroup group)
        {
            DOTween.To(() => group.alpha, x => group.alpha = x, 1f, 0.5f)
                .OnComplete(() => group.interactable = true)
                .OnComplete(() => DOTween.To(() => group.alpha, x => group.alpha = x, 0f, 0.5f).SetDelay(time - 0.5f)
                    .OnComplete(() => group.interactable = true));
        }

        public static void HideThenShow(float time, CanvasGroup group)
        {
            DOTween.To(() => group.alpha, x => group.alpha = x, 0f, 0.5f)
                .OnComplete(() => group.interactable = false)
                .OnComplete(() => DOTween.To(() => group.alpha, x => group.alpha = x, 1f, 0.5f).SetDelay(time - 0.5f)
                    .OnComplete(() => group.interactable = true));
        }
    }

    public enum ScreenType
    {
        AuthScreen,
        WebScreen,
        ProfileInfoScreen,
        MainScreen,
        NotificationsScreen,
        SettingsScreen
    }
}