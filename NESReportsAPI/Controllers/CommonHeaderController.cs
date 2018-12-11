using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NESReportsBLL;
using NESReportsDTO;

namespace NESReportsAPI.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonHeaderController : ApiController
    {
        CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();

        /// <summary>
        /// Get States
        /// </summary>
        /// <returns></returns>
        [Route("states")]
        public IHttpActionResult GetStates()
        {
            try
            {
                return Ok(commonHeaderBLL.GetStateList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Districts
        /// </summary>
        /// <returns></returns>
        [Route("districts")]
        public IHttpActionResult GetDistrict(string stateIds)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetDistrict(stateIds));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Branchs
        /// </summary>
        /// <param name="districtIds"></param>
        /// <returns></returns>
        [Route("branches")]
        public IHttpActionResult GetBranches(string districtIds)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetOBranches(districtIds));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Course
        /// </summary>
        /// <returns></returns>
        [Route("courses")]
        public IHttpActionResult GetClasses()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetOCourse());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns></returns>
        [Route("subjects")]
        public IHttpActionResult GetSubjects()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetSubjects());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Category By ReportId
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("categorybyreport/{reportType}")]
        public IHttpActionResult GetCategoryByReportId(int reportType)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetCategoryByReportId(reportType));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Sub-Category By Report Type and Category
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("subcategorybyreportandcategory/{reportType}/{category}")]
        public IHttpActionResult GetSubCategoryByReportTypeAndCategory(int reportType, int category)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetSubCategoryByReportTypeAndCategory(reportType, category));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Reports 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        [Route("reportcategory")]
        public IHttpActionResult GetReports()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetReports());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Get Content 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        [Route("content")]
        public IHttpActionResult GetContent()
        {
            try
            {
                
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return Ok(commonHeaderBLL.GetContent());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public IHttpActionResult CheckLogin([FromBody] Login login)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                AdminLogin adminLogin = commonHeaderBLL.CheckLogin(login.username, login.password);

                if(string.IsNullOrEmpty(adminLogin.userName))
                {
                    return NotFound();
                }

                return Ok(adminLogin);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
