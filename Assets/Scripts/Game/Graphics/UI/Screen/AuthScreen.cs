using Game.Graphics.UI.Buttons.Custom;
using Game.Online.Manager.Auth;
using UnityEngine;
using UnityEngine.UI;
using Animation = Game.Graphics.UI.Menu.Animations.Animation;

namespace Game.Graphics.UI.Screen
{
    public class AuthScreen : Screen
    {
        public CanvasGroup AuthPanel, LoginHolders, RegisterHolders;
        public AuthProvider AuthProvider;
        public Animation LoadingAnimation;
        [SerializeField] private InputField _username, _password;
        [SerializeField] private InputField _usernameRegField, _passwordRegField, _passwordConfRegField, _emailField;
        [SerializeField] private DelayedButton _authorize, _registerAccount;

        private void Start()
        {
            //ScreenManager.Instance.ChangeScreen(this);
            _authorize.Init(6f,
                LoadingAnimation, () => AuthProvider.LoginAction(_username.text, _password.text),
                () => HideThenShow(6f, LoginHolders));
            _registerAccount.Init(6f,
                LoadingAnimation, () => AuthProvider.RegisterRequest(_usernameRegField.text, _passwordRegField.text, _emailField.text));
        }
    }
}