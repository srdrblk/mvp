using Contracts.Enums;

namespace Domain.Entities
{
    public class RatingPoint : BaseEntity
    {
        public RatingTypeEnum RatingType { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int Order { get; set; }
    }
}
