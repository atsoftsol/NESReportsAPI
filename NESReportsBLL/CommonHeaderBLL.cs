using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESReportsDAL;

namespace NESReportsBLL
{
    public class CommonHeaderBLL
    {
        CommonHeaderDAL commonHeaderDAL = new CommonHeaderDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStates()
        {
            try
            {
                return commonHeaderDAL.GetStates();
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public string GetDistrict(int stateID)
        {
            try
            {
                return commonHeaderDAL.GetDistrict(stateID);
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
        /// <returns></returns>
        public string GetCategoryByReportId(int ReportType)
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
        public string GetSubCategoryByReportTypeAndCategory(int ReportType, int category)
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
        public string GetReports()
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
