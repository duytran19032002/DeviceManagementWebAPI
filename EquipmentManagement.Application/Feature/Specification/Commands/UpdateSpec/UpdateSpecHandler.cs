using AutoMapper;
using EquipmentManagement.Application.Contract.Persis;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Exceptions;
using EquipmentManagement.Application.Feature.Specification.Commands.CreateSpec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Specification.Commands.UpdateSpec
{
	public class UpdateSpecHandler : IRequestHandler<UpdateSpec, string>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _specRepository;
		private readonly ISpecificationRepository _specificationRepository;

		public UpdateSpecHandler(IMapper mapper, IUnitOfWork specRepository, ISpecificationRepository specificationRepository)
		{
			_mapper = mapper;
			_specRepository = specRepository;
			_specificationRepository = specificationRepository;
		}
		public async Task<string> Handle(UpdateSpec request, CancellationToken cancellationToken)
		{
			//validate
			var validator = new UpdateSpecValidation();
			var validatorResult = await validator.ValidateAsync(request);
			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid spec", validatorResult);
			}
			//convert
			//var specToCreate = _mapper.Map<Domain.Specification>(request


			var spect = _specificationRepository.FindByCondition(x=>x.EquipmentTypeId==request.EquipmentTypeId,trackChanges: true).ToList();
			_specificationRepository.RemoveRange(spect);
			var P = new List<Domain.Specification>();
			foreach (var sp in request.Specs)
			{
				if (sp != null)
				{
					var a = new Domain.Specification
					{
						EquipmentTypeId = request.EquipmentTypeId,
						Name = sp.Name,
						Value = sp.Value,
						Unit = sp.Unit,
					};
					P.Add(a);		
				}
			}
			 _specRepository.specificationRepository.AddRange(P);
			//add to db
			await _specRepository.SaveChangeAsync();
			//return 
			return request.EquipmentTypeId;
		}
	}
}
