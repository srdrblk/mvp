using Domain.Entities;

namespace Business.IService
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();
        List<Player> GetMVPlayers();
        Player AddPlayer(Player player);
        List<Player> AddPlayers(List<Player> players);
        bool DeletePlayer(int id);
    }
}
