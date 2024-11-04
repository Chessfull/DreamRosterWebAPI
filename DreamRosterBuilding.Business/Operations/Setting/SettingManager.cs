using DreamRosterBuilding.Data.Entities;
using DreamRosterBuilding.Data.Repositories;
using DreamRosterBuilding.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Setting
{
    public class SettingManager:ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SettingEntity> _repository;

        public SettingManager(IUnitOfWork unitOfWork, IRepository<SettingEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public bool GetMaintenanceState()
        {
            return _repository.GetById(1).MaintenanceMood;
        }

        public async Task ToggleMaintenance()
        {
            var setting = _repository.GetById(1);

            setting.MaintenanceMood= !setting.MaintenanceMood;

            _repository.Update(setting);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("There is a error while trying to toggle maintenance setting ...");
            }
        }
    }
}
