using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Games
{
    public class GameResult
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
