using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Setting
{
    public interface ISettingService
    {
        Task ToggleMaintenance();
        bool GetMaintenanceState();
    }
}
