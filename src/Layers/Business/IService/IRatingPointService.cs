using Contracts.Enums;
using Domain.Entities;

namespace Business.IService
{
    public interface IRatingPointService
    {
        RatingPoint AddRatingPoint(PlayerPosition playerPosition, RatingTypeEnum ratingType, string name, int point, int order);
        List<RatingPoint> GetRatingPoints();
        List<RatingPoint> GetRatingPointsBySportTypeName(string sportTypeName);
    }
}
