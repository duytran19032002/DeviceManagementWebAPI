using AutoMapper;
using EquipmentManagement.Application.Feature.Form.Commands.CreateForm;
using EquipmentManagement.Application.Feature.Form.Query.GetForm;
using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using EquipmentManagement.Application.Feature.Location.Commands.UpdateLocation;
using EquipmentManagement.Application.Feature.Location.Queries.GetAllLocations;
using EquipmentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.MappingProfile
{
	public class FormProfile : Profile
	{
		public FormProfile()
		{
			CreateMap<CreateForm, GoogleForm>().ReverseMap();
			CreateMap<GoogleForm, GetGoogleFormDTO>().ReverseMap();
		}
	}
}
