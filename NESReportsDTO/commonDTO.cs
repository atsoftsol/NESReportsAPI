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
        public decimal subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
    }

    /// <summary>
    /// Report Type
    /// </summary>
    public class ReportType
    {
        public int reportId { get; set; }
        public string reportName { get; set; }
    }

    /// <summary>
    /// Report Category
    /// </summary>
    public class ReportCategory
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int reportId { get; set; }
    }

    /// <summary>
    /// Report Sub Category
    /// </summary>
    public class ReportSubCategory
    {
        public int subCategoryId { get; set; }
        public string subCategoryName { get; set; }
        public int categoryId { get; set; }
        public int reportId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ContentType
    {
        public decimal contentId { get; set; }
        public string contentName { get; set; }
        public string contentCode { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public  class AdminLogin
    {
        public int id { get; set; }
        public string userName { get; set; }
      
       
    }


    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }


}
