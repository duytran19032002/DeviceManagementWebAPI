using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EquipmentManagement.API.Models
{
	public class FormData
	{
		[JsonProperty("Email")]
		[DisplayName("Email")]
		[DataMember(Name = "Email")]
		public string Email { get; set; }



		[JsonProperty("Tên đề tài của nhóm")]
		[DisplayName("Tên đề tài của nhóm")]
		[DataMember(Name = "Tên đề tài của nhóm")]
		public string TenDeTaiCuaNhom { get; set; }

		[JsonProperty("Họ và tên người sử dụng")]
		[DisplayName("Họ và tên người sử dụng")]
		[DataMember(Name = "Họ và tên người sử dụng")]
		public string HoVaTenNguoiSuDung { get; set; }

		[JsonProperty("MSSV/MSCB/CCCD")]
		[DisplayName("MSSV/MSCB/CCCD")]
		[DataMember(Name = "MSSV/MSCB/CCCD")]
		public string MSSV_MSCB_CCCD { get; set; }

		[JsonProperty("Danh sách thiết bị sử dụng")]
		[DisplayName("Danh sách thiết bị sử dụng")]
		[DataMember(Name = "Danh sách thiết bị sử dụng")]
		public string DanhSachThietBiSuDung { get; set; }

		[JsonProperty("Hình thức sử dụng")]
		[DisplayName("Hình thức sử dụng")]
		[DataMember(Name = "Hình thức sử dụng")]
		public string HinhThucSuDung { get; set; }

		[JsonProperty("Chi tiết dự án")]
		[DisplayName("Chi tiết dự án")]
		[DataMember(Name = "Chi tiết dự án")]
		public List<string> ChiTietDuAn { get; set; }
	}
}
