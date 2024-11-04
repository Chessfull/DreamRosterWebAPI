using DreamRosterBuilding.Business.Operations.Player.Dtos;
using DreamRosterBuilding.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DreamRosterBuilding.WebApi.Models.Player
{
    public class UpdatePlayerRequest // -> Request for using while updating player
    {
        [Required]
        [StringLength(30, ErrorMessage = "Player name length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public HairColor HairColor { get; set; }

        [Required]
        public Skin Skin { get; set; }

        public Tattoo? Tattoo { get; set; }

        // ID for related entities - In my scenario User will select only team and nation with dropdown list from necessary endpoints like GetTeams GetNations
        [Required(ErrorMessage = "Team ID is required.")]
        public int TeamId { get; set; }
        [Required(ErrorMessage = "NationID is required.")]
        public int NationId { get; set; }

        // Many-to-many related IDs - In my scenario User will select these areas with dropdown list, bullet etc. from necessary controller api like GetPlayerSkills
        [Required(ErrorMessage = "At least one skill is required.")]
        public List<int> SkillIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "At least one position is required.")]
        public List<int> PositionIds { get; set; } = new List<int>();

    }
}
