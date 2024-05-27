﻿using EquipmentManagement.Application.Feature.Location.Commands.CreateLocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Application.Feature.Form.Commands.CreateForm;

public class CreateForm : IRequest<string>
{
	public string Email { get; set; } = string.Empty;
	public string ProjectName { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string MSSV { get; set; } = string.Empty;
	public string Equipment { get; set; } = string.Empty;
	public bool OnSite { get; set; }
	public string LinkGgDrive { get; set; } = string.Empty;
	public bool Seen { get; set; } = false;
	public DateTimeOffset CreatedAt { get; set; }

}
