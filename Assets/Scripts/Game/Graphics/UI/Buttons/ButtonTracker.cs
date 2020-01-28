using System.Collections;
using System.Collections.Generic;
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
          public void StartGame()=>
          StartCoroutine(_windowsAnimations.Animate(_mainMenu, _selectableScreen, _playbackSpeed));

          public void Rating() =>
          Application.OpenURL("https://play.google.com/store/apps/details?id=com.Elleyer.Elysium");


          public void Scores()=>
          StartCoroutine(_windowsAnimations.Animate(_mainMenu, _ranking, _playbackSpeed));

          public void Styling()=>
          StartCoroutine(_windowsAnimations.Animate(_mainMenu, _styling, _playbackSpeed));

          public void ShowRooms()=>
          StartCoroutine(_windowsAnimations.Animate(_selectableScreen, _rooms, _playbackSpeed));

          public void ShowDiff()=>
          StartCoroutine(_windowsAnimations.Animate(_selectableScreen, _diffPanel, _playbackSpeed));

          public void ChangeScene() =>
          Initiate.Fade("Bots", Color.black, 1f);

          public void BackStyling()=>
          StartCoroutine(_windowsAnimations.Animate(_styling, _mainMenu, _playbackSpeed));

          public void BackRanking()=>
          StartCoroutine(_windowsAnimations.Animate(_ranking, _mainMenu, _playbackSpeed));

          public void BackSettings()=>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.MainScreen));

          public void BackSelectableScreen()=>
          StartCoroutine(_windowsAnimations.Animate(_selectableScreen, _mainMenu, _playbackSpeed));

          public void BackRooms()=>
          StartCoroutine(_windowsAnimations.Animate(_rooms, _selectableScreen, _playbackSpeed));

          public void BackDiff()=>
          StartCoroutine(_windowsAnimations.Animate(_diffPanel, _selectableScreen, _playbackSpeed));
     }
}
