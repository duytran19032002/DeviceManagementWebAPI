using EquipmentManagement.API.Hubs;
using EquipmentManagement.API.Models;
using EquipmentManagement.Application.Contract.Gmail;
using EquipmentManagement.Application.Feature.Form.Commands.CheckForm;
using EquipmentManagement.Application.Feature.Form.Commands.CreateForm;
using EquipmentManagement.Application.Feature.Form.Commands.DeleteForm;
using EquipmentManagement.Application.Feature.Form.Query.GetForm;
using EquipmentManagement.Application.Feature.Tag.Commands.CreateTag;
using EquipmentManagement.Application.Feature.Tag.Commands.DeleteTag;
using EquipmentManagement.Application.Feature.Tag.Commands.UpdateTag;
using EquipmentManagement.Application.Feature.Tag.Queries.GetAllTag;
using EquipmentManagement.Application.Feature.Warning.DeleteWarning;
using EquipmentManagement.Application.Feature.Warning.GetWarning;
using EquipmentManagement.Application.Models.Gmail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using SendGrid.Helpers.Mail;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace EquipmentManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IHubContext<NotificationHub> _hubContext;
		private readonly IGmailSender _gmailSender;
		public NotificationsController(IMediator mediator, IHubContext<NotificationHub> hubContext, IGmailSender gmailSender)
		{
			_mediator = mediator;
			_hubContext = hubContext;
			_gmailSender = gmailSender;
		}
		[HttpGet]
		public async Task<IActionResult> GetForm([FromQuery] string? projectName,
			bool? onSide,
			string? email,
			bool? seen,
			string? userName,
			DateTimeOffset? endDate,
			DateTimeOffset? startDate,
			int pageSize = 200, int pageNumber = 1)
		{
			var forms = await _mediator.Send(new GetForm {ProjectName=projectName,OnSide = onSide,Email = email,Seen= seen,UserName= userName,EndDate=endDate,StartDate= startDate });

			forms = forms.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(forms);
		}

		[HttpPost]
		public  async Task<IActionResult> PostForm([FromBody] Dictionary<string, object> data)
		{
			/* {"Email":"duy","Tên 
		đề tài của nhóm":"fablab","Họ và tên người sử 
		dụng":"ngocduy","MSSV/MSCB/CCCD":"2012846","Danh sách thiết bị sử 
		dụng":"iot","Hình thức sử dụng":"Sử dụng tại chỗ","Chi tiết dự 
		án":["1dLWMjaVgwFwEGrjR3XFYJeR4nbYHfO0o"]}
		  * 
		  */
			var email = data["Email"].ToString();
			var tenDeTaiCuaNhom = data["Tên đề tài của nhóm"].ToString();
			var hoVaTenNguoiSuDung = data["Họ và tên người sử dụng"].ToString();
			var mssvMscbCccd = data["MSSV/MSCB/CCCD"].ToString();
			var danhSachThietBiSuDung = data["Danh sách thiết bị sử dụng"].ToString();
			var hinhThucSuDung = data["Hình thức sử dụng"].ToString();



			if (!data.ContainsKey("Chi tiết dự án") || data["Chi tiết dự án"] == null)
			{
				data["Chi tiết dự án"] = "chưa điền nội dung";
			}
			var chiTietDuAn = data["Chi tiết dự án"].ToString();



			var details = JsonSerializer.Deserialize<List<string>>(chiTietDuAn);
			var firstElement = details[0];
			var link = $"https://docs.google.com/document/d/{firstElement}/edit";
			//var chiTietDuAn = ((JArray)data["Chi tiết dự án"])[0].ToString();
			var form = new CreateForm
			{
				Email = email,
				ProjectName = tenDeTaiCuaNhom,
				UserName = hoVaTenNguoiSuDung,
				MSSV = mssvMscbCccd,
				Equipment = danhSachThietBiSuDung,
				OnSite = hinhThucSuDung.Equals("Sử dụng tại chỗ"),
				LinkGgDrive = link,
				CreatedAt = DateTimeOffset.UtcNow.ToOffset(new TimeSpan(7, 0, 0)),
				Seen = false
			};


			
			await _mediator.Send(form);
			var a = JsonSerializer.Serialize(form);
			await _hubContext.Clients.All.SendAsync("FormNotification", a);

			var gmail = new GmailMessage
			{
				To = form.Email,
				Subject = "Form nộp thành công",
				Body = "Chúng tôi đã ghi nhận dự án của bạn, dự án sẽ được kiểm tra và xử lí trong vòng 24h. " +
				"From Fablab Innovation with love"

			};

				await _gmailSender.SendGmail(gmail);

			return Ok(a);



		}
		[HttpDelete]
		public async Task<IActionResult> DeleteSupplier([FromQuery] string projectName)
		{
			var command = new DeleteForm { ProjectName= projectName };
			var formToDel = await _mediator.Send(command);
			return Ok(formToDel);
		}
		[HttpPut]
		public async Task<IActionResult> CheckForm([FromBody] CheckedForm projectName)
		{
			var id = await _mediator.Send(projectName);
			return Ok(id);

		}


		[HttpGet("Warning")]
		public async Task<IActionResult> GetWarning([FromQuery] 

	DateTime? endDate,
	DateTime? startDate,
	int pageSize = 200, int pageNumber = 1)
		{


			var warnings = await _mediator.Send(new GetWarning() );
			if (endDate != null && startDate != null)
			{
				warnings = warnings.Where(x => x.Timestampe <= endDate).Where(x => x.Timestampe >= startDate).OrderByDescending(x => x.Timestampe).ToList();
			}
			warnings = warnings.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			return Ok(warnings);
		}




		[HttpDelete("Warning")]
		public async Task<IActionResult> DeleteWarning([FromQuery] string name)
		{
			var command = new DeleteWarning { Name = name };
			var formToDel = await _mediator.Send(command);
			return Ok(formToDel);
		}
	}
}
