using MediatR;

namespace EquipmentManagement.Application.Feature.Picture.Commands.CreatePicture;

public class CreatePicture : IRequest<string>
{
	public List<string> FileData { get; set; }
	public string EquipmentTypeId { get; set; }
}


