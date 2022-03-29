namespace Football_Tournament.Models.Teams
{
    using System.ComponentModel.DataAnnotations;
    using static Football_Tournament.Data.DataConstants;

    public class TeamViewModel
        
    {
        [Display(Name = "Team Name")]
        [Required]
        [StringLength(TeamNameMaxLength, MinimumLength = TeamNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Name { get; set; }

        [Display(Name = "Logo URL")]
        [Required]
        public string Logo { get; set; }
    }
}
