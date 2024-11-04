using DreamRosterBuilding.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Icon
{
    public interface IIconService
    {
        int GetIconId(HairColor hairColor,Skin skin,Tattoo? tattoo);
    }
}
