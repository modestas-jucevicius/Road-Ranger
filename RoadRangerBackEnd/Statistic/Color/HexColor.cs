﻿
using System;

namespace RoadRangerBackEnd.Statistic
{
    public class HexColor : IColor
    {
        private Random random = new Random();
        public string GetRandom()
        {
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}
