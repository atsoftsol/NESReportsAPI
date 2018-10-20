using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESReportsDAL;
using NESReportsDTO;

namespace NESReportsBLL
{
    public class CommonHeaderBLL
    {
        CommonHeaderDAL commonHeaderDAL = new CommonHeaderDAL();

        /// <summary>
        /// Get States
        /// </summary>
        /// <returns></returns>
        public List<States> GetStates()
        {
            try
            {
                return commonHeaderDAL.GetStatesList();
            }
            catch (Exception)
            {
                throw;
            } 
        }
  
        /// <summary>
        /// Get District
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public List<Districts> GetDistrict(string stateIds)
        {
            try
            {
                return commonHeaderDAL.GetDistrictList(stateIds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Branches
        /// </summary>
        /// <param name="districtIds"></param>
        /// <returns></returns>
        public List<Branches> GetBranches(string districtIds)
        {
            try
            {
                return commonHeaderDAL.GetBranches(districtIds);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Classes
        /// </summary>
        /// <returns></returns>
        public List<Course> GetClasses()
        {
            try
            {
                return commonHeaderDAL.GetClasses();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns></returns>
        public List<Subject> GetSubjects()
        {
            try
            {
                return commonHeaderDAL.GetSubjects();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Category By ReportId
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        public AVReportDTO GetCategoryByReportId(int ReportType)
        {
            try
            {
                return commonHeaderDAL.GetCategoryByReportId(ReportType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get SubCategory By Report Type and CategoryId
        /// </summary>
        /// <param name="ReportType"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public AVReportDTO GetSubCategoryByReportTypeAndCategory(int ReportType, int category)
        {
            try
            {
                return commonHeaderDAL.GetSubCategoryByReportTypeAndCategory(ReportType, category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Reports
        /// </summary>
        /// <returns></returns>
        public AVReportDTO GetReports()
        {
            try
            {
                return commonHeaderDAL.GetReports();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
