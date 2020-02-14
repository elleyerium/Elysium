namespace Game.Online
{
    public enum MessageType
    {
        Authorization = 1,
        AuthorizationResponse = 2,
        GetConcurrentUsers = 3,
        GetConcurrentUsersResponse = 4,
        UserConnected = 6, //Broadcast
        UserDisconnected = 8, //Broadcast
        GetPlayerStats = 11,
        PlayerStatsResponse = 12,
        SendChatMessage = 13,
        IncomingChatMessage = 14, //Broadcast
        UpdateProfileSettings = 15,
        UpdateProfileSettingsResponse = 16,
        CreateRoom = 17,
        NewRoomAvailable = 18
    }

    public enum ProfileSettingsMessage
    {
        SetAvatar = 1,
        ChangePassword = 2
    }
}