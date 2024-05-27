using EquipmentManagement.Application.Models.Gmail;
using EquipmentManagement.Application.Models.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Contract.SMS
{
	public interface ISmsSender
	{
		bool SendSms(SmsMessage sms);
	}
}
