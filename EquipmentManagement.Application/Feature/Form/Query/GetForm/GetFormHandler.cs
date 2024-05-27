using AutoMapper;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.Persistence.Generic;
using EquipmentManagement.Application.Feature.Borrow.Queries.GetAllBorrow;
using EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Form.Query.GetForm;

public class GetFormHandler : IRequestHandler<GetForm, List<GetGoogleFormDTO>>
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAppLogger<GetForm> _logger;

	public GetFormHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetForm> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<List<GetGoogleFormDTO>> Handle(GetForm request, CancellationToken cancellationToken)
	{
		//query
		var forms = _unitOfWork.googleFormRepository.FindAll().ToList();
		//logging
		if(!string.IsNullOrEmpty(request.ProjectName))
		{
			forms = forms.Where(x => x.ProjectName == request.ProjectName).ToList();
		}
		if(!string.IsNullOrEmpty(request.Email))
		{
			forms = forms.Where(x => x.Email == request.Email).ToList();
		}
		if(!string.IsNullOrEmpty(request.UserName))
		{
			forms = forms.Where(x => x.UserName == request.UserName).ToList();
		}
		if(request.OnSide != null)
		{
			forms = forms.Where(x => x.OnSite == request.OnSide).ToList();
		}
		if(request.StartDate != null)
		{
			forms = forms.Where(x => x.CreatedAt >= request.StartDate).ToList();
		}
		if(request.EndDate != null)
		{
			forms = forms.Where(x => x.CreatedAt <= request.EndDate).ToList();
		}
		if(request.Seen!= null)
		{
			forms = forms.Where(x => x.CheckSeen == request.Seen).ToList();
		}
		if(forms == null)
		{
			_logger.LogWarning("No form found");
			return null;
		}


		_logger.LogInformation("get location successfully");
		// convert
		var data = _mapper.Map<List<GetGoogleFormDTO>>(forms);
		//return
		return data;
	}
}