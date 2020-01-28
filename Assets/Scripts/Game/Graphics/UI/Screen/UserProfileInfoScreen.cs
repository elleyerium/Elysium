using Game.Graphics.UI.Buttons.Custom;
using UnityEngine;

namespace Game.Graphics.UI.Screen
{
    public class UserProfileInfoScreen : Screen
    {
        [SerializeField] private JumpingButton _showUserInfo;
        public GameObject Panel, Exp;

        /*private void Start()
        {
            _showUserInfo.Init(() => HideOrShowScreen(0f, this));
        }*/
    }
}