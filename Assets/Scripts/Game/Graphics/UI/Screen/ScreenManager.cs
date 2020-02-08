using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Graphics.UI.Screen
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private Screen _authScreen, _webScreen, _profileInfoScreen, _mainScreen, _notificationsScreen, _settingsScreen;
        private Screen _prevScreen;
        public static ScreenManager Instance;
        public List<Screen> Screens;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if(Instance != this)
                Destroy(gameObject);
        }

        private void Start()
        {
            _authScreen.IsActive = true;
            Screens.Add(_authScreen);
            Screens.Add(_webScreen);
            Screens.Add(_profileInfoScreen);
            Screens.Add(_mainScreen);
            Screens.Add(_notificationsScreen);
            Screens.Add(_settingsScreen);
        }

        public Screen GetScreen(ScreenType screenType)
        {
            switch (screenType)
            {
                case ScreenType.AuthScreen:
                    return _authScreen;
                case ScreenType.WebScreen:
                    return _webScreen;
                case ScreenType.ProfileInfoScreen:
                    return _profileInfoScreen;
                case ScreenType.MainScreen:
                    return _mainScreen;
                case ScreenType.NotificationsScreen:
                    return _notificationsScreen;
                case ScreenType.SettingsScreen:
                    return _settingsScreen;
                default:
                    throw new ArgumentOutOfRangeException(nameof(screenType), screenType, null);
            }
        }

        public void ChangeScreen(Screen screen)
        {
            Debug.Log(screen.gameObject.name);
            if (_prevScreen == _authScreen)
                _prevScreen = _mainScreen;
            var activeScreen = Screens.FirstOrDefault(x => x.IsActive);
            if (activeScreen == null)
                return;
            activeScreen.IsActive = false;
            if (activeScreen == screen)
            {
                _prevScreen.IsActive = true;
                Screen.HideOrShowScreen(0.5f, activeScreen);
                Screen.HideOrShowScreen(0.5f, _prevScreen);
                return;
            }
            _prevScreen = activeScreen;
            screen.IsActive = true;
            Screen.HideOrShowScreen(0.5f, activeScreen);
            Screen.HideOrShowScreen(0.5f, screen);
        }
    }
}