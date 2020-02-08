using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Graphics.UI.Screen.Window
{
    public class MenuWindow : WindowManager
    {
        public Window MainWindow, RankingWindow, StylingWindow, GameModeWindow, GameModeOnlineWindow, GameModeOfflineWindow;

        private readonly List<Window> _windows = new List<Window>();

        private void Start()
        {
            _windows.Add(MainWindow);
            _windows.Add(RankingWindow);
            _windows.Add(StylingWindow);
            _windows.Add(GameModeWindow);
            _windows.Add(GameModeOnlineWindow);
            _windows.Add(GameModeOfflineWindow);
        }

        public void ChangeWindow(MenuWindowType to)
        {
            var active = _windows.FirstOrDefault(x => x.IsActive);
            if (active != null)
            {
                Hide(active);
            }

            switch (to)
            {
                case MenuWindowType.Main:
                    Show(MainWindow);
                    break;
                case MenuWindowType.Ranking:
                    Show(RankingWindow);
                    //UserInfoWindow.IsActive = true;
                    break;
                case MenuWindowType.Styling:
                    Show(StylingWindow);
                    //EventsWindow.IsActive = true;
                    break;
                case MenuWindowType.GameMode:
                    Show(GameModeWindow);
                    //NewsWindow.IsActive = true;
                    break;
                case MenuWindowType.GameModeOnline:
                    Show(GameModeOnlineWindow);
                    break;
                case MenuWindowType.GameModeOffline:
                    Show(GameModeOfflineWindow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(to), to, null);
            }
        }
    }

    public enum MenuWindowType
    {
        Main,
        Styling,
        Ranking,
        GameMode,
        GameModeOnline,
        GameModeOffline
    }
}