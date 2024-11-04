using DreamRosterBuilding.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Team.Dtos
{
    public class TeamDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public string League { get; set; }
        public string Image { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public List<TeamPlayerDto> Players { get; set; }
    }
}
