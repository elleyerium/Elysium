using Game.Graphics.UI.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Graphics.UI.Buttons.Custom
{
    public class MenuButton : Button
    {
        [SerializeField] private ButtonSystemParams _params;
        private new void Start()
        {
            onClick.AddListener(() => _params.ChangeFocus(this));
        }

        public MenuButtonsEnum Type;
        public bool IsFocused { get; set; }
    }
}