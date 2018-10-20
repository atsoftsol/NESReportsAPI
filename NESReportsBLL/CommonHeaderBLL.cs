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
        /// 
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
            } 
            return null;
        }
  
        /// <summary>
        /// 
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
            }

            return null;
        }

        public List<Branches> GetBranches(string districtIds)
        {
            try
            {
                return commonHeaderDAL.GetBranches(districtIds);
            }
            catch (Exception)
            {
            }

            return null;
        }

        public List<Course> GetClasses()
        {
            try
            {
                return commonHeaderDAL.GetClasses();
            }
            catch (Exception)
            {
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        public AVReportDTO GetCategoryByReportId(int ReportType)
        {
            try
            {
                return commonHeaderDAL.GetCategoryByReportId(ReportType);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
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
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AVReportDTO GetReports()
        {
            try
            {
                return commonHeaderDAL.GetReports();
            }
            catch (Exception ex)
            {

            }

            return null;
        }

    }
}
