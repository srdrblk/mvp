using Contracts.Enums;

namespace Domain.Entities
{
    //Firstly I thought I can use enum for that .
    //But I changed my mind because I want to add and remove new sports without the need for a developer.
    //It would be more appropriate to decide this according to the competence of the system administrators.
    public class RatingParameter : BaseEntity
    {
        public int PlayerId { get; set; }

        public int Value { get; set; }
        public RatingPoint RatingPoint { get; set; }
    }
}
