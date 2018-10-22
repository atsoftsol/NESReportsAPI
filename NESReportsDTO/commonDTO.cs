using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDTO
{
    /// <summary>
    /// State DTO
    /// </summary>
    public class States
    {
        public long stateId { get; set; }
        public string stateName { get; set; }
        public string stateCode { get; set; }
    }

    /// <summary>
    /// District DTO
    /// </summary>
    public class Districts
    {
        public long districtId { get; set; }
        public string districtName { get; set; }
        public string districtCode { get; set; }
    }

    /// <summary>
    /// Branches DTO
    /// </summary>
    public class Branches
    {
        public long branchId { get; set; }
        public string branchName { get; set; }
        public string eurekaBranchCode { get; set; }
    }

    /// <summary>
    /// Course DTO
    /// </summary>
    public class Course
    {
        public long courseId { get; set; }
        public string courseName { get; set; }
        public string courseDescription { get; set; }
        public string courseCouName { get; set; }
        public string courseShortName { get; set; }
    }

    /// <summary>
    /// Subject DTO
    /// </summary>
    public class Subject
    {
        public long subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
    }
}
