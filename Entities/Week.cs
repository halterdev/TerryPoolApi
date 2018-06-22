namespace Entities
{
    public class Week
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int WeekNum { get; set; }
    }

    public class WeekDto
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int WeekNum { get; set; }
    }
}
