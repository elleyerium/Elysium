using Game.Difficult;
using Game.Online.Multiplayer.Lobby;

namespace Game
{
    public interface IGameHost
    {
        void CreateHost(BotDifficult difficult);
        void CreateHost(Room room);
    }
}