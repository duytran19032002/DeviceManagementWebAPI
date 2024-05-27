using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Models.SMS
{
	public class SmsMessage
	{
		public string FROM { get; set; }
		public string Body { get; set; }
		public string To { get; set; }
	}
}
