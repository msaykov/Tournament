namespace Football_Tournament.Services.Tournaments
{
    using Football_Tournament.Data;
    using Football_Tournament.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Football_Tournament.Data.DataConstants;

    public class TournamentService : ITournamentService
    {
        private readonly TournamentDbContext data;

        public TournamentService(TournamentDbContext data)
        => this.data = data;

        public ICollection<TournamentInfoServiceModel> AllTournaments()
            => this.data
            .Tournaments
            .Select(t => new TournamentInfoServiceModel
            {
                Id = t.Id,
                Name = t.Name,
                Category = t.Category,
                TeamsCount = t.Teams.Count,
                GroupsCount = GetGroupsCount(t.Teams.Count),
                MaxTeams = t.MaxTeams,
                IsStarted = t.IsStarted,
                IsFinished = t.IsFinished,
            })
            .ToList();

        public void CreateTournament(string name, string category, int maxTeams)
        {

            var tournamentEntity = new Tournament
            {
                Name = name,
                Category = category,
                MaxTeams = maxTeams,
            };

            this.data
                .Tournaments
                .Add(tournamentEntity);
            this.data.SaveChanges();

        }

        public void SeedGroups(int id)
        {
            var tournament = GetTournamentById(id);
            tournament.IsStarted = true;
            var allTeams = this.data
                .Teams
                .Where(t => t.TournamentId == id)
                .ToList();
            var teamsCount = allTeams.Count;
            var groupCount = GetGroupsCount(teamsCount);
            for (int i = 1; i <= groupCount; i++)
            {
                var currentGroup = new Group
                {
                    Name = $"Group {i}",
                };
                tournament.Groups.Add(currentGroup);
            }
            AddTeamsToGroups(allTeams, tournament);
            this.data.SaveChanges();

        }

        public TournamentDetailsServiceModel Details(int id)
        {
            var tournament = GetTournamentById(id);
            var groups = GetGroupsByTournamentId(id);
            var teams = this.data
                .Teams
                .Where(t => t.Group.TournamentId == id)
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.GoalDifference)
                .ToList();


            var schedule = new List<ScheduleServiceModel>();
            foreach (var group in groups)
            {
                var currentGroupTeams = GetTeamsByGroupId(group.Id);
                for (int i = 0; i < currentGroupTeams.Count - 1; i++)
                {
                    for (int j = i + 1; j < currentGroupTeams.Count; j++)
                    {
                        var currentMatch = new ScheduleServiceModel
                        {
                            FirstTeam = currentGroupTeams[i].Name,
                            SecondTeam = currentGroupTeams[j].Name,
                            Result = "-- : --",
                        };
                        schedule.Add(currentMatch);
                    }
                }
            }

            return new TournamentDetailsServiceModel
            {
                Id = id,
                Category = tournament.Category,
                Name = tournament.Name,
                Groups = groups,
                IsStarted = tournament.IsStarted,
                IsFinished = tournament.IsFinished,
                Matches = schedule,
            };

        }


        

        private Tournament GetTournamentById(int id)
            => this.data
                   .Tournaments
                   .FirstOrDefault(t => t.Id == id);

        private List<Group> GetGroupsByTournamentId(int id)
               => this.data
                           .Groups
                           .Where(g => g.TournamentId == id)
                           .ToList();

        private List<Team> GetTeamsByGroupId(int id)
               => this.data
                           .Teams
                           .Where(t => t.GroupId == id)
                           .ToList();

        private int GetTeamsCount(Group group)
               => this.data
                           .Teams
                           .Where(t => t.GroupId == group.Id)
                           .Count();

        private static void AddTeamsToGroups(List<Team> allTeams, Tournament tournament)
        {
            while (allTeams.Any(t => t.IsSelected == false))
            {
                foreach (var group in tournament.Groups)
                {
                    var currentTeam = allTeams.FirstOrDefault(t => t.IsSelected == false);
                    if (currentTeam != null)
                    {
                        group.Teams.Add(currentTeam);
                        currentTeam.IsSelected = true;
                    }
                }
            }
        }

        private static int GetGroupsCount(int teamsCount)
        {
            var groupsCount = 0;
            if (teamsCount / MaxGroupsCount >= MinTeamsCount)
            {
                groupsCount = MaxGroupsCount;
            }
            else if (teamsCount / MidGroupsCount >= MinTeamsCount)
            {
                groupsCount = MidGroupsCount;
            }
            else if (teamsCount / MinGroupsCount >= MinTeamsCount)
            {
                groupsCount = MinGroupsCount;
            }
            return groupsCount;
        }

        private int GetMaxTeamsCountInGroup(List<Group> groups)
        {
            var maxTeams = 0;
            foreach (var item in groups)
            {
                var currentTeamsCount = GetTeamsCount(item);
                if (currentTeamsCount > maxTeams)
                {
                    maxTeams = currentTeamsCount;
                }
            }
            return maxTeams;
        }

        private int Factorial(int num)
        {
            var fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            };
            return fact;
        }

    }
}
