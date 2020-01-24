namespace Game.Online
{
    public enum MessageType
    {
        Authorization = 1,
        AuthorizationResponse = 2,
        GetConcurrentUsers = 3,
        GetConcurrentUsersResponse = 4,
        UserConnected = 6,
        UserDisconnected = 8,
        LeaderboardsRequest = 9,
        LeaderboardsResponse = 10,
        GetPlayerStars = 11,
        PlayerStatsResponse = 12,
        SendChatMessage = 13,
        IncomingChatMessage = 14
    }
}