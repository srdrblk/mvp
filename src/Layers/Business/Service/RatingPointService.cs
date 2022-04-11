using Business.IService;
using Contracts.Enums;
using Domain.Entities;

namespace Business.Service
{
    public class RatingPointService : IRatingPointService
    {
        private List<RatingPoint> RatingPoints;
        public RatingPointService()
        {
            RatingPoints = new List<RatingPoint>();
        }
        public RatingPoint AddRatingPoint(PlayerPosition playerPosition, RatingTypeEnum ratingType, string name, int point,int order)
        {
            var ratingPoint = new RatingPoint() { PlayerPosition = playerPosition, RatingType = ratingType, Name = name, Point = point ,Order = order };
            var id = !RatingPoints.Any()? 1 : RatingPoints.LastOrDefault().Id + 1;
            ratingPoint.Id = id;
            RatingPoints.Add(ratingPoint);
            return ratingPoint;
        }
        public List<RatingPoint> GetRatingPoints() { return RatingPoints; }
        public List<RatingPoint> GetRatingPointsBySportTypeName(string sportTypeName)
        {
           var ratingPoints = RatingPoints.Where(rp => rp.PlayerPosition.SporType.Name == sportTypeName).ToList();
            return ratingPoints;
        }
    }
}
