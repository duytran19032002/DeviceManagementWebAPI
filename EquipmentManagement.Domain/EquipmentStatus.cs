﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EquipmentManagement.Domain
{
	public enum EquipmentStatus
	{
		[Display(Name = "Active")]
		[Description("Active")]
		Active = 0,

		[Display(Name = "Inactive")]
		[Description("Inactive")]
		Inactive = 1,

		[Display(Name = "Nonfunctional")]
		[Description("Nonfunctional")]
		Nonfunctional = 2,

		[Display(Name = "Maintenance")]
		[Description("Maintenance")]
		Maintenance = 3
	}
}
