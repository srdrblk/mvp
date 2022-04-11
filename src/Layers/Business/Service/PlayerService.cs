using Business.IService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class PlayerService : IPlayerService
    {
        public List<Player> Players { get; set; }
        public PlayerService()
        {
            Players = new List<Player>();
        }
        public List<Player> GetPlayers()
        {
            return Players;
        }
        public List<Player> GetMVPlayers()
        {
            var mvps = Players.GroupBy(a => a.PlayerPosition.SporType, (key, g) => g.OrderByDescending(e => e.ProductivityScore).First()).ToList();
            return mvps;
        }
        public Player AddPlayer(Player player)
        {
            player.Id = !Players.Any() ? 1 : Players.LastOrDefault().Id + 1;
            player.ProductivityScore = CalculateProductivityScore(player);
            Players.Add(player);
            return player;
        }
        public List<Player> AddPlayers(List<Player> players)
        {
            var result = new List<Player>();


            foreach (Player player in players)
            {
                result.Add(AddPlayer(player));
            }
            return result;

        }
        public bool DeletePlayer(int id)
        {
            var player = Players.FirstOrDefault(x => x.Id == id);
            if (player != null)
            {
                Players.Remove(player);
                return true;
            }
            return false;
        }
        private int CalculateProductivityScore(Player player)
        {
            var productivityScore = 0;
            
            foreach (var ratingParameter in player.RatingParameters)
            {
                productivityScore += ratingParameter.RatingPoint.RatingType== Contracts.Enums.RatingTypeEnum.Fixed ? ratingParameter.Value : ratingParameter.RatingPoint.Point*ratingParameter.Value;
            }
            return productivityScore;
        }
    }
}
