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
          [SerializeField] private WindowButtonHandler _buttonHandler;
          [SerializeField] private BotDifficult _botDifficult;
          [SerializeField] private GameProvider _gameProvider;

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

          public void LeaderboardsScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.LeaderboardsScreen));

          public void StylingScreen() =>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.StylingScreen));

          public void LobbyScreen()=>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.LobbyScreen));

          /*public void ShowDiff()=>
               //_buttonHandler.ShowGameModeOfflineWindow();*/ //TODO: FIX

          public void PlayOffline()
          {
               //_gameProvider.SetOfflineHost(new BotDifficult(DifficultRate.Easy));
               Initiate.Fade("Bots", Color.black, 1f);
               //_botDifficult.Play();
          }

          public void ModeSelectorScreen()=>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.ModeSelectorScreen));

          public void DiffSelectorScreen()=>
               ScreenManager.Instance.ChangeScreen(ScreenManager.Instance.GetScreen(ScreenType.DiffSelectorScreen));

          /*public void BackDiff()=>
               _buttonHandler.ShowGameModeWindow();*/
     }
}
