using Domain.Entities;

namespace Business.IService
{
    public interface  IPlayerPositionService
    {
        PlayerPosition AddPlayerPosition(SportType sportType, string name,string code);
        List<PlayerPosition> GetPlayerPositions();
        PlayerPosition GetPlayerPositionByCodeAndSportTypeName(string code, string sportName);
    }
}
