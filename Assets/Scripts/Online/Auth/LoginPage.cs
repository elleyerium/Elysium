using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Auth;

public class LoginPage : MonoBehaviour {
    public GameObject registerinputs, login_inputs, registerbtn, loginbtn, settings;
    public InputField username_input,registerusername_input, email_input;
    public InputField password_input, registerpass_input, confirm_input;
    public string userID;
    public string email, RegisterID, registerpass;
    public string pass, confirm;
    public GameObject Guest, waystoconnect, loginpanel, bordersignin, borderregister, gamemenu, Choose;
    public GameObject connectedtoaccount, Connected, Connecting, Disconnected;
    public GameObject ErrorManager,textObj;
    public Text hellouser, message, status;
    private string errorInfo;
    public int ID;
    [SerializeField] private Animation ErrorAnim;
    
    void Start()
    {
        NotificationsCreator.NewNofication(TypeOfNofications.Warning.ToString(), "You need to update your client for multiplayer!");
        //LoginAttempt();
    }

    private void Username()
    {
        userID = username_input.text;
        RegisterID = registerusername_input.text;
        email = email_input.text;
    }
    private void Password()
    {
        pass = password_input.text;
        registerpass = registerpass_input.text;
        confirm = confirm_input.text;
    }
    public void Register()
    {
        registerinputs.SetActive(true);
        login_inputs.SetActive(false);
        registerbtn.SetActive(true);
        loginbtn.SetActive(false);
        bordersignin.SetActive(false);
        borderregister.SetActive(true);
    }
    public void SignIn()
    {
        registerinputs.SetActive(false);
        login_inputs.SetActive(true);
        loginbtn.SetActive(true);
        registerbtn.SetActive(false);
        bordersignin.SetActive(true);
        borderregister.SetActive(false);
    }
    public void AsGuest()
    {
        //Scroll.enabled = true;
        loginpanel.SetActive(false);
        Guest.SetActive(true);
        NotificationsCreator.NewNofication(TypeOfNofications.Info.ToString(), "You currently playing as guest. If you want to enjoy multiplayer actions, you have to login.");

    }
    public void LogOut()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("password");
        loginpanel.SetActive(true);
        username_input.text = "";
        password_input.text = "";
        
    }
    public void RegisterEnter()
    {
        string format = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        if (confirm == registerpass && Regex.IsMatch(email, format, RegexOptions.IgnoreCase) && registerpass.Length >= 8)
        {
            PlayerPrefs.SetString("username", RegisterID);
            PlayerPrefs.SetString("password", registerpass);
            Auth.Register.RegisterRequest(RegisterID, registerpass, email);
           

                /*if (str.Contains(":1"))
                {
                    loginpanel.SetActive(false);
                    hellouser.text = (RegisterID + " #1");
                    Debug.Log("Registered");
                }
                if (str.Contains(":2"))
                {
                    errorInfo = "EmailTaken";
                    GotError();
                    Debug.Log("email already taken");
                }
                if (str.Contains(":3"))
                {
                    errorInfo = "UsernameEmailTaken";
                    GotError();
                    Debug.Log("Username and Email Already Taken");
                }
                if (str.Contains(":4"))
                {
                    errorInfo = "UsernameTaken";
                    GotError();
                    Debug.Log("Username Already Taken");
                }*/
       }
        if (registerpass.Length < 8)
        {
            errorInfo = "PassLess8";
            GotError();
            Debug.Log("Password less than 8 Symbols");
        }
            if (confirm != registerpass)
        {
            errorInfo = "PassDontmatch";
            GotError();
            Debug.Log("Passwords do not match");
        }
    }
    public void LoginAttempt()
    {
        string Responce;
/*        if (!PlayerPrefs.HasKey("username") || !PlayerPrefs.HasKey("password"))
        {*/
            Responce = Login.LoginAction(username_input.text,password_input.text);
        //}
/*        else
        {
            Responce = Login.LoginAction(PlayerPrefs.GetString("username"), PlayerPrefs.GetString("password"));
            PlayerPrefs.SetString("username", userID);
            PlayerPrefs.SetString("password", pass);
        }*/
        Debug.Log(Responce);
        if (Responce.Contains("logged in!"))
        {
            PlayerPrefs.SetString("username", userID);
            PlayerPrefs.SetString("password", pass);
            hellouser.text = PlayerPrefs.GetString("username");
            loginpanel.SetActive(false);
            NotificationsCreator.NewNofication(TypeOfNofications.Info.ToString(),
                $"{hellouser.text}, welcome again!. Saved session time : {System.DateTime.Now.ToString()}");
            Debug.Log("logged");
        }
        if(Responce.Contains("Failed to login!"))
                status.text = "Failed to connect!"; 
    }

    private void GotError()
    {
        var text = ErrorManager.GetComponent<Text>();
        if (errorInfo == "UsernameTaken")
            text.text = "Username already taken!";
        if (errorInfo == "UsernameEmailTaken")
            text.text = "Username and email already taken!";
        if (errorInfo == "EmailTaken")
            text.text = "Email already taken!";
        if (errorInfo == "PassLess8")
            text.text = "Password less than 8 symbols";
        if (errorInfo == "PassDontmatch")
            text.text = "Passwords do not match";
        if (errorInfo == "WrongData")
            text.text = "Wrong /username/ or password!";
        GameObject window = Instantiate(ErrorManager);
        window.transform.SetParent(Choose.transform);
        window.transform.localPosition = new Vector3(-405, -555);
        Destroy(window, 4f);
    }
}
