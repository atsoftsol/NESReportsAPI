using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDTO
{

    public class Assembly
    {
        public int assemblyId { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string flagStartTime { get; set; }
        public string flagEndTime { get; set; }
        public bool isStartedOnTime { get; set; }
        public int delayInMinutes { get; set; }
        public bool isEndedOnTime { get; set; }
        public int foreCloserMinutes { get; set; }
        public bool schoolPrayer { get; set; }
        public bool ekidzSong { get; set; }
        public bool warmUpSong { get; set; }
        public bool thoughtForTheDay { get; set; }
    }

    public class UniformDefaulter : StudentInfo
    {

    }

    public class LateComer : StudentInfo
    {

    }

    public class IdDefaulter : StudentInfo
    {

    }

    public class ShoeDefaulter : StudentInfo
    {

    }

    public class StudentInfo
    {
        public int admissionNo { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string Course { get; set; }
    }

    public class InspectionDTO
    {
        public int inspectionId { get; set; }
        public string date { get; set; }
        public string state { get; set; }
        public int stateId { get; set; }
        public string district { get; set; }
        public int districtId { get; set; }
        public string branch { get; set; }
        public int branchId { get; set; }
        public Assembly assembly { get; set; }
        public List<UniformDefaulter> uniformDefaulters { get; set; }
        public List<LateComer> lateComers { get; set; }
        public List<IdDefaulter> idDefaulters { get; set; }
        public List<ShoeDefaulter> shoeDefaulters { get; set; }
    }


    public class InspectionHeader
    {
        public string date { get; set; }
        public string state { get; set; }
        public int stateId { get; set; }
        public string district { get; set; }
        public int districtId { get; set; }
        public string branch { get; set; }
        public int branchId { get; set; }
    }


    public class InspectionType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class InspectionCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }


    public class InspectionSubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
    }

    public class InspectionSegment
    {
        public int SegmentId { get; set; }
        public string Name { get; set; }
    }


    public class StudentNo
    {
        public int AdminssionNo { get; set; }
        public string Student { get; set; }
        public int CourseId { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
    }

    public class Discipline
    {
        public int AdminssionNo { get; set; }
        public string Student { get; set; }
        public int CourseId { get; set; }
        public string Class { get; set; }
        public int UniformId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int InspectionId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }

}
