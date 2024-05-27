using EquipmentManagement.Application.Contract.Persistence;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;

namespace EquipmentManagement.Persistence.Repository
{
	public class WarningRepository : RepositoryBase<Warning, int>, IWarningRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public WarningRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}


	}
}
