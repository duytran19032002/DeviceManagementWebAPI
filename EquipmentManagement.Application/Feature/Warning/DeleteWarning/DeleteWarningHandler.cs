using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using MediatR;

namespace EquipmentManagement.Application.Feature.Warning.DeleteWarning
{
	public class DeleteWarningHandler : IRequestHandler<DeleteWarning, string>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteWarningHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<string> Handle(DeleteWarning request, CancellationToken cancellationToken)
		{


			var warning =  _unitOfWork.warningRepository.FindByCondition(x=>x.Name==request.Name).ToList();
			if (warning == null)
			{
				throw new NotFoundException(nameof(Warning), request.Name);
			}

			_unitOfWork.warningRepository.RemoveRange(warning);
			await _unitOfWork.SaveChangeAsync();
			return request.Name;
		}
	}
}
