using EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Picture.Commands.UpdatePicture;

public class UpdatePicture : IRequest<string>
{
	public List<string> FileData { get; set; }
	public string EquipmentTypeId { get; set; }
}

