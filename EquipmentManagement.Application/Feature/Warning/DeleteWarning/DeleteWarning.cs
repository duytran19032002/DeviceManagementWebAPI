using EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Warning.DeleteWarning
{
	public class DeleteWarning : IRequest<string>
	{
		public string Name { get; set; } = string.Empty;
	}
}
