using DreamRosterBuilding.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Player.Dtos
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public HairColor HairColor { get; set; }
        public Skin Skin { get; set; }
        public Tattoo? Tattoo { get; set; }
        public string Team { get; set; }
        public string Nation { get; set; }
        public List<PlayerSkillDto> Skills { get; set; } 
        public List<PlayerPositionDto> Positions { get; set; } 
        public string ModifiedUser { get; set; } // -> I will get this from httpcontext, in my scenario username=usermailadress
        public string CreatedUser { get; set; } // -> I will get this from httpcontext, in my scenario username=usermailadress
    }
}
