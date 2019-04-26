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
    public GameObject ErrorManager;
    public Text hellouser;
    private string errorInfo;
    public int ID;
    [SerializeField] private Animation ErrorAnim;
    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;     
    }
    void Start()
    {
        errorInfo = "Waiting some data...";
        Debug.Log(PlayerPrefs.GetString("username"));
        Debug.Log(PlayerPrefs.GetString("password"));
        if (PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("password"))
        {
            PhotonNetwork.AuthValues = new AuthenticationValues();
            PhotonNetwork.AuthValues.AuthType = CustomAuthenticationType.Custom;
            PhotonNetwork.AuthValues.AddAuthParameter("username", PlayerPrefs.GetString("username"));
            PhotonNetwork.AuthValues.AddAuthParameter("password", PlayerPrefs.GetString("password"));
            PhotonNetwork.ConnectUsingSettings("0.5");
        }
    }
    
    void Update()
    {
        if (PhotonNetwork.connected)
        {           
            hellouser.text = (PlayerPrefs.GetString("username") + " #1");
            loginpanel.SetActive(false);
        }
    }

    private void Username()
    {
        userID = username_input.text.ToString();
        RegisterID = registerusername_input.text.ToString();
        email = email_input.text.ToString();
    }
    private void Password()
    {
        pass = password_input.text.ToString();
        registerpass = registerpass_input.text.ToString();
        confirm = confirm_input.text.ToString();
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

    }
    public void LogOut()
    {
        //Scroll.enabled = false;
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("password");
        PhotonNetwork.Disconnect();
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

        PlayerPrefs.SetString("username", userID);
        PlayerPrefs.SetString("password", pass);

        PhotonNetwork.AuthValues = new AuthenticationValues();
        PhotonNetwork.AuthValues.AuthType = CustomAuthenticationType.Custom;
        PhotonNetwork.AuthValues.AddAuthParameter("username", userID);
        PhotonNetwork.AuthValues.AddAuthParameter("password", pass);
        PhotonNetwork.ConnectUsingSettings("0.5");
        Debug.Log(PlayerPrefs.GetString("username"));
        Debug.Log(PlayerPrefs.GetString("password"));
        

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

    void OnCustomAuthenticationFailed(string debugMessage)
    {
        errorInfo = "WrongData";
        GotError();
        Debug.Log("Wrong data");
    }
    private void OnDisconnectedFromPhoton()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Reconnect();
        }
    }
}
