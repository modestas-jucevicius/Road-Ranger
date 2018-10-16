using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_rangerVS.Recognition;
using Road_rangerVS.Search;

namespace Road_rangerVS.Models
{
	class HistoryModel
	{
		private readonly ICapturedCarFinder finder = new CapturedCarFinder();

		public ICapturedCarFinder getFinder()
		{
			return this.finder;
		}
	}
}
