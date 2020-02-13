using System.Collections;

namespace Game.Online.API.Requests
{
    public interface IAPIRequest
    {
        string AdditionalPath { get; set; }
    }
}