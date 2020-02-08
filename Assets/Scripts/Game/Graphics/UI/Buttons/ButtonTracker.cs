using System.Collections;
using System.Collections.Generic;
using Game.Difficult;
using Game.Graphics.Effects;
using Game.Graphics.UI.Background;
using Game.Graphics.UI.Menu.Animations;
using Game.Graphics.UI.Screen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Graphics.UI.Buttons
{
     public class ButtonTracker : MonoBehaviour
     {
          [SerializeField] private CanvasGroup _mainMenu, _selectableScreen, _styling, _ranking, _settings, _rooms, _diffPanel;
          [SerializeField] private WindowAnimations _windowsAnimations;
          [SerializeField] private WindowButtonHandler _buttonHandler;
          [SerializeField] private BotDifficult _botDifficult;
          private float _playbackSpeed = 2f;

          public void WebScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.WebScreen));

          public void NotificationsScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.NotificationsScreen));

          public void UserInfoScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.ProfileInfoScreen));

          public void SettingsScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.SettingsScreen));

          public void HomeScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.MainScreen));

          public void ShowRooms()=>
          StartCoroutine(_windowsAnimations.Animate(_selectableScreen, _rooms, _playbackSpeed));

          public void ShowDiff()=>
               _buttonHandler.ShowGameModeOfflineWindow();

          public void PlayOffline()
          {
               Initiate.Fade("Bots", Color.black, 1f);
               _botDifficult.Play();
          }

          public void BackStyling() =>
               _buttonHandler.ShowMainWindow();

          public void BackRanking()=>
               _buttonHandler.ShowMainWindow();

          public void BackSettings()=>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.MainScreen));

          public void BackSelectableScreen()=>
               _buttonHandler.ShowMainWindow();

          public void BackRooms()=>
          StartCoroutine(_windowsAnimations.Animate(_rooms, _selectableScreen, _playbackSpeed));

          public void BackDiff()=>
               _buttonHandler.ShowGameModeWindow();
     }
}
