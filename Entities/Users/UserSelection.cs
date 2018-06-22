namespace Entities.Users
{
    public class UserSelection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int WeekId { get; set; }
    }

    public class UserSelectionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int WeekId { get; set; }
    }
}
