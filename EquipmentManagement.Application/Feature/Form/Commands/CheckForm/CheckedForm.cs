using MediatR;

namespace EquipmentManagement.Application.Feature.Form.Commands.CheckForm;

public class CheckedForm : IRequest<string>
{
	public string ProjectName { get; set; } = string.Empty;	

}
