using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Game.Graphics.UI.Screen.Window
{
    public class WebWindow : WindowManager
    {
        public Window ChatWindow, UserInfoWindow, EventsWindow, NewsWindow;

        private readonly List<Window> _windows = new List<Window>();

        private void Start()
        {
            _windows.Add(ChatWindow);
            _windows.Add(UserInfoWindow);
            _windows.Add(EventsWindow);
            _windows.Add(NewsWindow);
        }

        public void ChangeWindow(WebWindowType to)
        {
            var active = _windows.FirstOrDefault(x => x.IsActive);
            if (active != null)
            {
                Hide(active);
            }

            switch (to)
            {
                case WebWindowType.Chat:
                    Show(ChatWindow);
                    ChatWindow.IsActive = true;
                    break;
                case WebWindowType.UserInfo:
                    Show(UserInfoWindow);
                    UserInfoWindow.IsActive = true;
                    break;
                case WebWindowType.Events:
                    Show(EventsWindow);
                    EventsWindow.IsActive = true;
                    break;
                case WebWindowType.News:
                    Show(NewsWindow);
                    NewsWindow.IsActive = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(to), to, null);
            }
        }
    }

    public enum WebWindowType
    {
        Chat,
        UserInfo,
        Events,
        News
    }
}