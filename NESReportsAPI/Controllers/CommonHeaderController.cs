using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NESReportsBLL;

namespace NESReportsAPI.Controllers
{
    public class CommonHeaderController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CommonHeader/GetStates")]
        public string GetStates()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetStates();
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CommonHeader/GetDistricts/{stateID}")]
        public string GetDistrict(int stateID)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetDistrict(stateID);
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CommonHeader/GetCategoryByReportId/{ReportType}")]
        public string GetCategoryByReportId(int ReportType)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetCategoryByReportId(ReportType);
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CommonHeader/GetSubCategoryByReportTypeAndCategory/{ReportType}/{category}")]
        public string GetSubCategoryByReportTypeAndCategory(int ReportType, int category)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetSubCategoryByReportTypeAndCategory(ReportType, category);
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CommonHeader/GetReportCategory")]
        public string GetReports()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetReports();
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
