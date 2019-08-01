using System.Collections;
using System.Collections.Generic;
using Game.Graphics.Effects;
using Game.Graphics.UI.Background;
using Game.Graphics.UI.Menu.Animations;
using UnityEngine;

namespace Game.Graphics.UI.Buttons
{
     public class ButtonTracker : MonoBehaviour
     {
          [SerializeField] private CanvasGroup _mainMenu, _selectableScreen, _styling, _ranking, _settings, _rooms, _diffPanel;
          [SerializeField] private WindowAnimations _windowsAnimations;
          private float _playbackSpeed = 2f;

          public void StartGame()=>
          StartCoroutine(_windowsAnimations.Animate(_mainMenu, _selectableScreen, _playbackSpeed));

          public void Rating() =>
          Application.OpenURL("https://play.google.com/store/apps/details?id=com.Elleyer.Elysium");

          public void Settings()=>
          StartCoroutine(_windowsAnimations.Animate(_mainMenu, _settings, _playbackSpeed));

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
          StartCoroutine(_windowsAnimations.Animate(_settings, _mainMenu, _playbackSpeed));

          public void BackSelectableScreen()=>
          StartCoroutine(_windowsAnimations.Animate(_selectableScreen, _mainMenu, _playbackSpeed));

          public void BackRooms()=>
          StartCoroutine(_windowsAnimations.Animate(_rooms, _selectableScreen, _playbackSpeed));

          public void BackDiff()=>
          StartCoroutine(_windowsAnimations.Animate(_diffPanel, _selectableScreen, _playbackSpeed));
     }
}
