using Entities.Teams;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Games
{
    public class Game
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        [ForeignKey("WeekId")]
        public virtual Week Week { get; set; }
    }
    
    public class GameDto
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int WeekNum { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public TeamDto AwayTeam { get; set; }
        public TeamDto HomeTeam { get; set; }
    }
}
