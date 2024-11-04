using DreamRosterBuilding.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Player.Dtos
{
    public class UpdatePlayerDto // -> Dto for transfering update request to business layer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public HairColor HairColor { get; set; }
        public Skin Skin { get; set; }
        public Tattoo? Tattoo { get; set; }
        public int TeamId { get; set; }
        public int NationId { get; set; }
        public List<int> SkillIds { get; set; }
        public List<int> PositionIds { get; set; }
        public string ModifiedUser { get; set; } // -> I will get this from httpcontext, in my scenario username=usermailadress
    }
}
