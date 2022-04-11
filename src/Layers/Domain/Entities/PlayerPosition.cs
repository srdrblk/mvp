namespace Domain.Entities
{
    public class PlayerPosition : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }    
        public SportType SporType { get; set; }

    }
}
