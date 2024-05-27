namespace EquipmentManagement.Application.Feature.Form.Query.GetForm;

public class GetGoogleFormDTO
{
	public int Id { get; set; }
	public string Email { get; set; } = string.Empty;
	public string ProjectName { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string MSSV { get; set; } = string.Empty;
	public string Equipment { get; set; } = string.Empty;
	public bool OnSite { get; set; }
	public string LinkGgDrive { get; set; } = string.Empty;
	public bool CheckSeen { get; set; } = false;
	public DateTimeOffset CreatedAt { get; set; }
}
