namespace Entities.Teams
{
    public class Team
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Nickname { get; set; }
    }

    public class TeamDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Nickname { get; set; }
    }
}
