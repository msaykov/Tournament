namespace Football_Tournament.Services.Teams
{
    using Football_Tournament.Data;
    using Football_Tournament.Data.Models;
    using Football_Tournament.Models.Teams;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeamsService : ITeamsService
    {
        private readonly TournamentDbContext data;

        public TeamsService(TournamentDbContext data)
        => this.data = data;

        public void AddTeam(string name, string logo, int id)
        {

            // TO DO -> Do not allow adding teams above the MAX value for the tournament

            var teamEntity = new Team
            {
                Name = name,
                Logo = logo,
                TournamentId = id
            };

            this.data
                .Add(teamEntity);
            this.data.SaveChanges();
        }

        public ICollection<TeamViewModel> AllTeams(int id)
            => this.data
            .Teams
            .Where(t => t.TournamentId == id)
            .Select(t => new TeamViewModel
            {
                Name = t.Name,
                Logo = t.Logo,
            })
            .ToList();

        public void AddMatch(string homeTeam, string awayTeam)
        {
            var firstTeam = GetTeamByName(homeTeam);
            var secondTeam = GetTeamByName(awayTeam);
            var matchEntity = new Match
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                IsPlayed = false,
            };
            firstTeam.Matches.Add(matchEntity);
            secondTeam.Matches.Add(matchEntity);
            this.data.SaveChanges();
        }

        public EditMatchServiceModel EditMatch(int matchId)
        {
            return this.data
             .Matches
             .Where(m => m.Id == matchId)
             .Select(m => new EditMatchServiceModel
             {
                 Id = matchId,
                 HomeTeam = m.HomeTeam,
                 AwayTeam = m.AwayTeam,
                 TournamentId = m.Team.TournamentId,
             })
             .FirstOrDefault();
        }



        public void EditMatch(int id, int homeTeamGoals, int awayTeamGoals, int homeTeamPenalities, int awayTeamPenalities)
        {
            var currentMatch = this.data
                .Matches
                .FirstOrDefault(m => m.Id == id);
            currentMatch.HomeTeamGoals = homeTeamGoals;
            currentMatch.AwayTeamGoals = awayTeamGoals;
            currentMatch.HomeTeamPenalities = homeTeamPenalities;
            currentMatch.AwayTeamPenalities = awayTeamPenalities;
            currentMatch.IsPlayed = true;

            UpdateTeamsInfo(currentMatch);
            this.data.SaveChanges();
        }



        private Team GetTeamByName(string name)
        => this.data
                 .Teams
                 .FirstOrDefault(t => t.Name == name);

        private void UpdateTeamsInfo(Match currentMatch)
        {
            var homeTeam = GetTeamByName(currentMatch.HomeTeam);
            var awayTeam = GetTeamByName(currentMatch.AwayTeam);
            if (currentMatch.HomeTeamGoals > currentMatch.AwayTeamGoals)
            {
                homeTeam.Points += 3;
                homeTeam.GoalsFwd += currentMatch.HomeTeamGoals;
                homeTeam.GoalsAg += currentMatch.AwayTeamGoals;
                homeTeam.GoalDifference = homeTeam.GoalsFwd - homeTeam.GoalsAg;
                homeTeam.Penalities += currentMatch.HomeTeamPenalities;

                awayTeam.GoalsFwd += currentMatch.AwayTeamGoals;
                awayTeam.GoalsAg += currentMatch.HomeTeamGoals;
                awayTeam.GoalDifference = awayTeam.GoalsFwd - awayTeam.GoalsAg;
                awayTeam.Penalities += currentMatch.AwayTeamPenalities;

            }
            else if (currentMatch.HomeTeamGoals < currentMatch.AwayTeamGoals)
            {
                awayTeam.Points += 3;
                awayTeam.GoalsFwd += currentMatch.AwayTeamGoals;
                awayTeam.GoalsAg += currentMatch.HomeTeamGoals;
                awayTeam.GoalDifference = awayTeam.GoalsFwd - awayTeam.GoalsAg;
                awayTeam.Penalities += currentMatch.AwayTeamPenalities;

                homeTeam.GoalsFwd += currentMatch.HomeTeamGoals;
                homeTeam.GoalsAg += currentMatch.AwayTeamGoals;
                homeTeam.GoalDifference = homeTeam.GoalsFwd - homeTeam.GoalsAg;
                homeTeam.Penalities += currentMatch.HomeTeamPenalities;
            }
            else
            {
                homeTeam.Points += 1;
                homeTeam.GoalsFwd += currentMatch.HomeTeamGoals;
                homeTeam.GoalsAg += currentMatch.AwayTeamGoals;
                homeTeam.GoalDifference = homeTeam.GoalsFwd - homeTeam.GoalsAg;
                homeTeam.Penalities += currentMatch.HomeTeamPenalities;


                awayTeam.Points += 1;
                awayTeam.GoalsFwd += currentMatch.AwayTeamGoals;
                awayTeam.GoalsAg += currentMatch.HomeTeamGoals;
                awayTeam.GoalDifference = awayTeam.GoalsFwd - awayTeam.GoalsAg;
                awayTeam.Penalities += currentMatch.AwayTeamPenalities;
            }
        }

    }
}
