using MediatR;

namespace EquipmentManagement.Application.Feature.Form.Query.GetForm;

public class GetForm : IRequest<List<GetGoogleFormDTO>>
{
	public string? ProjectName { get; set; } = string.Empty;
	public string? Email { get; set; } = string.Empty;
	public string? UserName { get; set; } = string.Empty;
	public bool? OnSide { get; set; }
	public bool? Seen { get; set; } = false;
	public DateTimeOffset? StartDate { get; set; }

	public DateTimeOffset? EndDate { get; set; }
}
