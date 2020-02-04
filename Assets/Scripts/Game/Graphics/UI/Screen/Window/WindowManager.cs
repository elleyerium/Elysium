using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Game.Graphics.UI.Screen.Window
{
    public class WindowManager : MonoBehaviour
    {
        public Window ChatWindow, UserInfoWindow, EventsWindow, NewsWindow;

        public List<Window> Windows = new List<Window>();

        private void Start()
        {
            Windows.Add(ChatWindow);
            Windows.Add(UserInfoWindow);
            Windows.Add(EventsWindow);
            Windows.Add(NewsWindow);
        }

        public void ChangeWindow(WindowType to)
        {
            var active = Windows.FirstOrDefault(x => x.IsActive);
            if (active != null)
            {
                Hide(active);
            }

            switch (to)
            {
                case WindowType.Chat:
                    Show(ChatWindow);
                    ChatWindow.IsActive = true;
                    break;
                case WindowType.UserInfo:
                    Show(UserInfoWindow);
                    UserInfoWindow.IsActive = true;
                    break;
                case WindowType.Events:
                    Show(EventsWindow);
                    EventsWindow.IsActive = true;
                    break;
                case WindowType.News:
                    Show(NewsWindow);
                    NewsWindow.IsActive = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(to), to, null);
            }
        }

        private void Show(Window window)
        {
            if (window.IsActive)
                return;
            window.IsActive = true;
            window.CanvasGroup.gameObject.SetActive(true);
            window.CanvasGroup.interactable = window.CanvasGroup.blocksRaycasts = true;
            DOTween.To(() => window.CanvasGroup.alpha, x => window.CanvasGroup.alpha = x, 1f, 0.3f);
        }

        private void Hide(Window window)
        {
            if (!window.IsActive)
                return;
            window.IsActive = false;
            window.CanvasGroup.interactable = window.CanvasGroup.blocksRaycasts = false;
            DOTween.To(() => window.CanvasGroup.alpha, x => window.CanvasGroup.alpha = x, 0f, 0.3f);
        }
    }

    public enum WindowType
    {
        Chat,
        UserInfo,
        Events,
        News
    }
}