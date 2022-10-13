namespace Football_Tournament.Services.Teams
{
    

    public class EditMatchServiceModel
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public int HomeTeamPenalities { get; set; }
        public int AwayTeamPenalities { get; set; }
        public int TournamentId { get; set; }


    }
}
