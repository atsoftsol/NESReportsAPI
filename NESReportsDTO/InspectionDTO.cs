﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDTO
{

    public class Assembly
    {
        public string startTime { get; set; }
        public bool isStartedOnTime { get; set; }
        public int delayInMinutes { get; set; }
        public bool isEndedOnTime { get; set; }
        public int foreCloserMinutes { get; set; }
        public bool schoolPrayer { get; set; }
        public bool ekidzSong { get; set; }
        public bool warmUpSong { get; set; }
        public bool thoughtForTheDay { get; set; }
    }

    public class UniformDefaulter
    {
    }

    public class LateComer
    {
    }

    public class IdDefaulter
    {
    }

    public class ShoeDefaulter
    {
    }

    public class Uniform
    {
        public List<UniformDefaulter> uniformDefaulters { get; set; }
        public List<LateComer> lateComers { get; set; }
        public List<IdDefaulter> idDefaulters { get; set; }
        public List<ShoeDefaulter> shoeDefaulters { get; set; }
    }

    public class InspectionDTO
    {
        public string date { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string branch { get; set; }
        public Assembly assembly { get; set; }
        public Uniform uniform { get; set; }
    }
}
