<<<<<<< HEAD:RoadRangerBackEnd/Report/IReportSender.cs
﻿using RoadRangerBackEnd.Cars;
=======
﻿using Road_rangerVS.Recognition;
using Road_rangerVS.Cars;
>>>>>>> 14143fd53e9df87f9d61baa2872c61231ac6452d:Road-rangerVS/Report/IReportSender.cs

namespace RoadRangerBackEnd.Report
{
    public interface IReportSender
    {
        void SendGeneretedMail(Car car);
        void SendMail(string subject, string body);
    }
}
