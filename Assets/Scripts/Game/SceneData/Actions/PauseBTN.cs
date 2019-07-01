using Game.AI.Data;
using Game.Difficult;
using Game.Graphics.Effects;
using Game.Player.Weapon;
using UnityEngine;

namespace Game.SceneData.Actions
{
    public class PauseBTN : MonoBehaviour
    {
        public GameObject ResumeUI;
        public GameObject Pausebutton;

        public void PauseGame()
        {
            ResumeUI.SetActive(true);
            Pausebutton.SetActive(false);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            ResumeUI.SetActive(false);
            Pausebutton.SetActive(true);
            Time.timeScale = 1;
        }
        public void MainMenu()    {
            BotDifficult.abitharder = false;
            BotDifficult.noob = false;
            BotDifficult.impossible = false;
            Bots.botCounter = 0;

            if (BotDifficult.noob)
                AmmoCounter.AmmodownRocket = 999;

            if (BotDifficult.abitharder)
                AmmoCounter.AmmodownRocket = 20;

            if (BotDifficult.impossible)
                AmmoCounter.AmmodownRocket = 10;

            Initiate.Fade("Main", Color.black, 2.5f);
            Time.timeScale = 1;

        }
        public void Exit()
        {
            Application.Quit();
            PlayerPrefs.Save();
        }
        public void Restart()
        {
            Bots.botCounter = 0;
            if (BotDifficult.noob)
                AmmoCounter.AmmodownRocket = 999;
            if (BotDifficult.abitharder)
                AmmoCounter.AmmodownRocket = 20;
            if (BotDifficult.impossible)
                AmmoCounter.AmmodownRocket = 10;


            Initiate.Fade("bots", Color.black, 4.5f);
            Time.timeScale = 1;
        }
    }
}

