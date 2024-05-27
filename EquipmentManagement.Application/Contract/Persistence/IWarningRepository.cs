using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Domain;

namespace EquipmentManagement.Application.Contract.Persistence
{
	public interface IWarningRepository : IRepositoryBaseAsync<Warning, int>
	{
	}
}
