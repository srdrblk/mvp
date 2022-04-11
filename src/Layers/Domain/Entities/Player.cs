
namespace Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public Team Team { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public List<RatingParameter> RatingParameters { get; set; } = new List<RatingParameter>();

        public int ProductivityScore { get; set; }

        public string ToString()
        {
            return PlayerPosition.SporType.Name+ " "+ Team.Name + " " + Name + " " + NickName + "/" + Number + " : " + ProductivityScore;
        }
    }
}
