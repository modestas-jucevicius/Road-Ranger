using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Road_rangerVS.EPolicija;
using Road_rangerVS.Cars;
using System.Threading.Tasks;

namespace RoadRangerTest
{
	[TestClass]
	public class EPolicijaAPITest
	{
		private EPolicijaAPI EPolicijaAPI = EPolicijaAPI.GetInstance();

		[TestMethod]
		public void AskCarStatus_stolenCarPlate_StolenStatus()
		{
			string license = "AAA017";

			CarStatus result = Task.Run(async () =>
			{
				return await EPolicijaAPI.AskCarStatus(license);
			}).GetAwaiter().GetResult();
			

			Assert.AreEqual(CarStatus.STOLEN, result);
		}

		[TestMethod]
		public void AskCarStatus_notStolenCarPlate_NotStolenStatus()
		{
			string license = "AAA000";

			CarStatus result = Task.Run(async () =>
			{
				return await EPolicijaAPI.AskCarStatus(license);
			}).GetAwaiter().GetResult();

			Assert.AreEqual(CarStatus.NOT_STOLEN, result);
		}

		[TestMethod]
		public void AskCarStatus_stolenPlate_StolenPlateStatus()
		{
			string license = "AAA033";

			CarStatus result = Task.Run(async () =>
			{
				return await EPolicijaAPI.AskCarStatus(license);
			}).GetAwaiter().GetResult();

			Assert.AreEqual(CarStatus.STOLEN_PLATE, result);
		}
	}
}
