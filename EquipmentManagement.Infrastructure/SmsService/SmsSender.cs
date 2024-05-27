using EquipmentManagement.Application.Contract.Email;
using EquipmentManagement.Application.Models.Email;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManagement.Application.Contract.SMS;
using EquipmentManagement.Application.Models.SMS;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace EquipmentManagement.Infrastructure.SmsService
{
	public class SmsSender : ISmsSender
	{
		public SmsSettings _smsSettings { get; }
		public SmsSender(IOptions<SmsSettings> smsSettings)
		{
			_smsSettings = smsSettings.Value;
		}

		public bool SendSms(SmsMessage sms)
		{
			try
				{
				TwilioClient.Init(_smsSettings.AccountSid, _smsSettings.AuthToken);


				var message = MessageResource.Create(
								body: sms.Body,
								from: new Twilio.Types.PhoneNumber(sms.FROM),
								to: new Twilio.Types.PhoneNumber(sms.To)
								);
				return true;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
