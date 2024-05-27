using EquipmentManagement.Domain;
using EquipmentManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DataContextSeed
{
	public static IHost SeedCustomer(this IHost host)
	{
		using var scope = host.Services.CreateScope();
		var customerContext = scope.ServiceProvider
			.GetRequiredService<ManageEquipmentDbContext>();
		customerContext.Database.MigrateAsync().GetAwaiter().GetResult();




		////////////////////////////////////////

		return host;
	}

	private static async Task CreateArea(ManageEquipmentDbContext dataContext, string LocationId, string Note)
	{
		var data = await dataContext.Location
			.SingleOrDefaultAsync(x => x.LocationId.Equals(LocationId) || x.Note.Equals(Note));

		if (data == null)
		{
			var newData = new Location
			{
				LocationId = LocationId,
				Note = Note

			};

			await dataContext.Location.AddAsync(newData);
			await dataContext.SaveChangesAsync();
		}
	}

	private static async Task CreateTag(ManageEquipmentDbContext dataContext, string TagId, string TagDetail)
	{
		var data = await dataContext.Tag
			.SingleOrDefaultAsync(x => x.TagId.Equals(TagId) || x.TagDetail.Equals(TagDetail));

		if (data == null)
		{
			var newData = new Tag
			{
				TagId = TagId,
				TagDetail = TagDetail
			};

			await dataContext.Tag.AddAsync(newData);
			await dataContext.SaveChangesAsync();
		}
	}
}
