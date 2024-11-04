using System.ComponentModel.DataAnnotations;

namespace DreamRosterBuilding.WebApi.Models.Team
{
    public class UpdateTeamRequest
    {
        [Required]
        public int NationId { get; set; }
        [Required]
        public int LeaugeId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Team name length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
