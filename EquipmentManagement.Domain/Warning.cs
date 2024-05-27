using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Domain
{
	public  class Warning
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public DateTime Timestampe {  get; set; }
	}
}
