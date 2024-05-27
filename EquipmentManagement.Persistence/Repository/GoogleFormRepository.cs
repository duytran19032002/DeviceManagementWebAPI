using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence;
using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using EquipmentManagement.Persistence.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Persistence.Repository
{
	public class GoogleFormRepository : RepositoryBase<GoogleForm, int>, IGoogleFormRepository
	{
		private readonly ManageEquipmentDbContext _manageEquipmentDbContext;
		public GoogleFormRepository(ManageEquipmentDbContext manageEquipmentDbContext) : base(manageEquipmentDbContext)
		{
			_manageEquipmentDbContext = manageEquipmentDbContext;
		}


	}
}
