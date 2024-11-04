using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Team.Dtos
{
    public class AddTeamDto
    {
        public int NationId { get; set; }
        public int LeaugeId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ModifiedUser { get; set; }
        public string CreatedUser { get; set; }

    }
}
