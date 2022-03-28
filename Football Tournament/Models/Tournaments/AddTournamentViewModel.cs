namespace Football_Tournament.Models.Tournaments
{
    using System.ComponentModel.DataAnnotations;
    using static Football_Tournament.Data.DataConstants;

    public class AddTournamentViewModel
    {
        [Display(Name = "Tournament Name")]
        [Required]
        [StringLength(TournamentNameMaxLength, MinimumLength = TournamentNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Name { get; set; }
                
        [Required]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength, ErrorMessage = NamesErrorMsg)]
        public string Category { get; set; }
    }
}
