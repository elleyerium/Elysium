namespace Game.Online.API
{
    public interface IAPIProvider
    {
        string AuthorizationHeader { get; }

        string SecretToken { get; set; }

        void CreateWebRequest(APIRequestType apiRequestType, params string[] data);

    }
}