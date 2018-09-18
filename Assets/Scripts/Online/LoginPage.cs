using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

public class LoginPage : MonoBehaviour {
    public GameObject registerinputs, login_inputs, registerbtn, loginbtn, settings;
    public InputField username_input,registerusername_input, email_input;
    public InputField password_input, registerpass_input, confirm_input;
    public string userID, email, RegisterID, registerpass;
    public string pass, confirm;
    public GameObject errormessage, Guest, waystoconnect, loginpanel, bordersignin, borderregister;
    public GameObject connectedtoaccount, Connected, Connecting, Disconnected;
    public GameObject registered, Usernametaken, userandmailtaken, emailtaken, passdontmatch, incorrectmail, passlessthan8;
    public Text hellouser;
    void Awake()
    {
            PhotonNetwork.automaticallySyncScene = true;
      
    }
    void Start()
    {
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
        if (PhotonNetwork.connected == true)
        {
           
            hellouser.text = ("logged as :  " + PlayerPrefs.GetString("username"));
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
        errormessage.SetActive(false);
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
        loginpanel.SetActive(false);
        Guest.SetActive(true);

    }
    public void LogOut()
    {
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
            string url = "http://dev.itvegas.ru/Reg.php";
            using (var webClient = new WebClient())
            {
                var registerdata = new NameValueCollection();
                registerdata.Add("email", email);
                registerdata.Add("registerID", RegisterID);
                registerdata.Add("registerpass", registerpass);
                var response = webClient.UploadValues(url, registerdata);
                string str = System.Text.Encoding.UTF8.GetString(response);
                Debug.Log(str);

                if (str.Contains(":1"))
                {
                    loginpanel.SetActive(false);
                    hellouser.text = "Logged as : " + RegisterID;
                    Connecting.SetActive(false);
                    Connected.SetActive(true);
                    registered.SetActive(true);
                    Debug.Log("Registered");
                }
                if (str.Contains(":2"))
                {
                    loginpanel.SetActive(true);
                    emailtaken.SetActive(true);
                    Debug.Log("email already taken");
                }
                if (str.Contains(":3"))
                {
                    loginpanel.SetActive(true);
                    userandmailtaken.SetActive(true);
                    Debug.Log("Username and Email Already Taken");
                }
                if (str.Contains(":4"))
                {
                    Usernametaken.SetActive(true);
                    Debug.Log("Username Already Taken");
                }
                   
            }
       }
        if (registerpass.Length < 8)
        {
            passlessthan8.SetActive(true);
            Debug.Log("Password less than 8 Symbols");
        }
            if (confirm != registerpass)
        {
            passdontmatch.SetActive(true);
            Debug.Log("Passwords do not match");
        }
            if (Regex.IsMatch(email, format, RegexOptions.IgnoreCase) == false)
        {
            incorrectmail.SetActive(true);
            Debug.Log("Mail is incorrect");
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

    }
    void  OnConnectedToPhoton()
    {
        
        Connected.SetActive(true);
        Connecting.SetActive(false);

    }
   void OnConnectedToMaster()
    {
      Connected.SetActive(true);
      Connecting.SetActive(false);
      //connectedtoaccount.SetActive(true);
      Debug.Log("connected to master");
   }
    void OnCustomAuthenticationFailed(string debugMessage)
    {
        errormessage.SetActive(true);
    }
    private void OnDisconnectedFromPhoton()
    {
        if (Connecting.active)
        {
            Connecting.SetActive(false);
        }
        if (Connected.active)
        {
            Connected.SetActive(false);
        }
        Connecting.SetActive(true);
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Reconnect();
        }
    }
}
