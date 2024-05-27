using EquipmentManagement.Application.Contract.Email;
using EquipmentManagement.Application.Contract.Gmail;
using EquipmentManagement.Application.Contract.Logging;
using EquipmentManagement.Application.Contract.SMS;
using EquipmentManagement.Application.Models.Email;
using EquipmentManagement.Application.Models.Gmail;
using EquipmentManagement.Application.Models.SMS;
using EquipmentManagement.Infrastructure.EmailService;
using EquipmentManagement.Infrastructure.GmailService;
using EquipmentManagement.Infrastructure.Logging;
using EquipmentManagement.Infrastructure.SmsService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentManagement.Infrastructure
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();

			services.Configure<GmailSettings>(configuration.GetSection("GmailSettings"));
			services.AddTransient<IGmailSender, GmailSender>();

			services.Configure<SmsSettings>(configuration.GetSection("SmsSettings"));
			services.AddTransient<ISmsSender, SmsSender>();

			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			return services;
		}
	}
}