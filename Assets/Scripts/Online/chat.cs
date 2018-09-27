using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon.Chat;
using ExitGames.Client.Photon;

public class chat : MonoBehaviour, IChatClientListener {

    public Text SenderName;
    public ChatClient chatClient;
    private Text UserID;
    string ChatChannel;
    public InputField MessageInput;

    void Start()
    {
        UserID.text = (PlayerPrefs.GetString("username"));
        GetConnected();
        ChatChannel = "world";
    }
    void GetConnected()
    {
        chatClient.Connect("7c3f40fc-6ae0-4783-89cd-6c7a72769512", "0.5", new ExitGames.Client.Photon.Chat.AuthenticationValues(PlayerPrefs.GetString("username")));
        this.chatClient = new ChatClient (this);
        
    }
	
	void Update ()
    {
        if (this.chatClient != null)
        {
            this.chatClient.Service();
        }
	}
    public void OnClickSend()
    {
        this.chatClient.PublishMessage(ChatChannel, "1");
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        this.chatClient.Subscribe(new string[] { ChatChannel });
        this.chatClient.SetOnlineStatus(ChatUserStatus.Online);
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }
}
