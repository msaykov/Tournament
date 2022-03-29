namespace Football_Tournament.Services.Teams
{
    using Football_Tournament.Data;
    using Football_Tournament.Data.Models;
    using Football_Tournament.Models.Teams;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeamService : ITeamsService
    {
        private readonly TournamentDbContext data;

        public TeamService(TournamentDbContext data)
        => this.data = data;

        public void AddTeam(string name, string logo, int id)
        {
            var teamEntity = new Team
            {
                Name = name,
                Logo = logo,
                TournamentId = id
            };
            //var groupId = GetGroupId(id);
            //teamEntity.GroupId = groupId;
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

        //private int GetGroupId(int tournamentId)
        //{
        //    var groupEntity = this.data
        //        .Groups
        //        .FirstOrDefault();
        //    if (groupEntity != null)
        //    {
        //        return groupEntity.Id;
        //    }
        //    else
        //    {
        //        groupEntity = new Group
        //        {
        //            Name = "Group A",
        //            TournamentId = tournamentId,
        //        };

        //        this.data.Add(groupEntity);
        //        var groupId = this.data.SaveChanges();
        //        return groupId;
        //    }

        //}


    }
}
