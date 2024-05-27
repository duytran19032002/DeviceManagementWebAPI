using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Warning.DeleteWarning;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag
{
	public class DeleteTagHandler : IRequestHandler<DeleteTag, string>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteTagHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<string> Handle(DeleteTag request, CancellationToken cancellationToken)
		{


			var warning = await _unitOfWork.tagRepository.GetByIdAsync(request.TagId);
			if (warning == null)
			{
				throw new NotFoundException(nameof(Tag), request.TagId);
			}

			_unitOfWork.tagRepository.Remove(warning);
			await _unitOfWork.SaveChangeAsync();
			return request.TagId;
		}
	}
}
