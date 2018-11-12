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
        #region Mysql

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
                return commonHeaderDAL.GetDistrict(stateIds);
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



        #endregion

        #region Oracle

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<States> GetStateList()
        {
            try
            {
                return commonHeaderDAL.GetStates();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public List<Districts> GetDistrictList(string stateIds)
        {
            try
            {
                return commonHeaderDAL.GetDistrict(stateIds);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtIds"></param>
        /// <returns></returns>
        public List<Branches> GetOBranches(string districtIds)
        {
            try
            {
                return commonHeaderDAL.GetOBranches(districtIds);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<Course> GetOCourse()
        {
            try
            {
                return commonHeaderDAL.GetOCourses();
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
        public List<ReportCategory> GetCategoryByReportId(int ReportType)
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
        public List<ReportSubCategory> GetSubCategoryByReportTypeAndCategory(int ReportType, int category)
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
        public List<ReportType> GetReports()
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

        #endregion

    }
}
