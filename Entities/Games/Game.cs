namespace Entities.Games
{
    public class Game
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int Week { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
    }
    
    public class GameDto
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int Week { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
    }
}
