namespace Football_Tournament.Services.Teams
{
    using Football_Tournament.Data.Models;
    using Football_Tournament.Models.Teams;
    using System.Collections.Generic;

    public class ViewTeamsServiceModel
    {
        public ICollection<TeamViewModel> Teams { get; set; }
    }
}
