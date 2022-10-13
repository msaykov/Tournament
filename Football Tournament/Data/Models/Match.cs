namespace Football_Tournament.Data.Models
{
    
    public class Match
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public int HomeTeamPenalities { get; set; }
        public int AwayTeamPenalities { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public bool IsPlayed { get; set; }
    }
}
