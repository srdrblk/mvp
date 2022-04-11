using Business.IService;
using Domain.Entities;

namespace Business.Service
{
    public class PlayerPositionService :IPlayerPositionService
    {
        private List<PlayerPosition> PlayerPositions { get; set; }
        public PlayerPositionService()
        {
            PlayerPositions = new List<PlayerPosition>();
        }
        public PlayerPosition AddPlayerPosition(SportType sportType, string name,string code)
        {
            var playerPosition = new PlayerPosition();
            playerPosition.Name = name;
            playerPosition.SporType = sportType;
            playerPosition.Code = code;
            var id = !PlayerPositions.Any() ? 1 : PlayerPositions.LastOrDefault().Id + 1;
            playerPosition.Id = id;
            PlayerPositions.Add(playerPosition);
            return playerPosition;

        }
        public List<PlayerPosition> GetPlayerPositions() { return PlayerPositions; }

        public PlayerPosition GetPlayerPositionByCodeAndSportTypeName(string code, string sportName)
        {
            return PlayerPositions.FirstOrDefault(pp => pp.Code == code && pp.SporType.Name == sportName);
        }
    }
}
