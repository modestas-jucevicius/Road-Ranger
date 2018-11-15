using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRangerWebAPI.Interfaces
{
	public interface ICrud
	{
		void Create(Object item);
		Object Read(string id);
		void Update(Object item);
		void Delete(string id);
	}
}
