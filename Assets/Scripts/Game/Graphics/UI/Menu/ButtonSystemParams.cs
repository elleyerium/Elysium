using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Graphics.UI.Buttons;
using UnityEngine;

namespace Game.Graphics.UI.Menu
{
    public enum MenuButtonsEnum
    {
        Exit,
        Styling,
        Start,
        Ranking
    }
    public class ButtonSystemParams : MonoBehaviour
    {
        [SerializeField] private ScrollTracker _scrollTracker;

        public void ChangeFocus(MenuButton button)
        {
            foreach (var buttonActive in FindObjectsOfType<MenuButton>())
            {
                if (buttonActive.IsFocused)
                {
                    Debug.Log($"Focus from {buttonActive.gameObject.name} has been removed.");
                    buttonActive.IsFocused = false;
                }
            }
            button.IsFocused = true;
            _scrollTracker.ScrollWithoutQueue(button.Type);
            Debug.Log($"Currently focused {button.gameObject.name}");
        }

        internal void ShowButtonDescription(MenuButtonsEnum typeOfTheButton)
        {
            switch (typeOfTheButton)
            {
                case MenuButtonsEnum.Exit:
                    break;
                case MenuButtonsEnum.Styling:
                    break;
                case MenuButtonsEnum.Start:
                    break;
                case MenuButtonsEnum.Ranking:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfTheButton), typeOfTheButton, null);
            }
        }

        internal MenuButton GetButtonWithActiveFocus()
        {
            return FindObjectsOfType<MenuButton>().FirstOrDefault(x => x.IsFocused);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
