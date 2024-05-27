using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Specification.Commands.UpdateSpec;

public class UpdateSpec : IRequest<string>
{

	public List<UpdateSpecification> Specs { get; set; }
	public string EquipmentTypeId { get; set; }
}
public class UpdateSpecification
{
	public string Name { get; set; }
	public string Value { get; set; }
	public string Unit { get; set; }
}
