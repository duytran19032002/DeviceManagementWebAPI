using EquipmentManagement.Application.Feature.Location.Commands.DeleteLocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Form.Commands.DeleteForm;

public class DeleteForm : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;
}
