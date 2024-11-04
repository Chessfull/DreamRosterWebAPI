using DreamRosterBuilding.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DreamRosterBuilding.WebApi.Models.Player
{
    public class PatchPlayerRequest
    {
        [StringLength(30, ErrorMessage = "Player name length must be between {2} and {1}.", MinimumLength = 3)]
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public HairColor? HairColor { get; set; }
        public Skin? Skin { get; set; }
        public Tattoo? Tattoo { get; set; }

        // ID for related entities - In my scenario User will select only team and nation with dropdown list from necessary endpoints like GetTeams GetNations
        public int? TeamId { get; set; }
        public int? NationId { get; set; }

        // Many-to-many related IDs - In my scenario User will select these areas with dropdown list, bullet etc. from necessary controller api like GetPlayerSkills
        public List<int>? SkillIds { get; set; } = new List<int>();
        public List<int>? PositionIds { get; set; } = new List<int>();
    }
}
