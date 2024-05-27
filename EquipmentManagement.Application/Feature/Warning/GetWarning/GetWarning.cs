using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Supplier.Queries.GetAllSupplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Warning.GetWarning
{
	public record GetWarning : IRequest<List<Domain.Warning>>;
	public class GetWarningHandler : IRequestHandler<GetWarning, List<Domain.Warning>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GetWarningHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;

		}

		public async Task<List<Domain.Warning>> Handle(GetWarning request, CancellationToken cancellationToken)
		{
			//query
			var data = _unitOfWork.warningRepository.FindAll();


			//return
			return data.ToList();
		}
	}
}
