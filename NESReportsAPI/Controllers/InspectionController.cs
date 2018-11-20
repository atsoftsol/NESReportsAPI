using NESReportsBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NESReportsAPI.Controllers
{
    [RoutePrefix("api/inspection")]
    public class InspectionController : ApiController
    {
        InspectionBLL inspectionBLL = new InspectionBLL();

        /// <summary>
        /// Get Inspection
        /// </summary>
        /// <returns></returns>
        [Route("inspectiontype")]
        public IHttpActionResult GetInspectionType()
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionType());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Inspection By ReportType
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("inspectionCategory")]
        public IHttpActionResult GetInspectionCategory(int reportType)
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionCategory(reportType));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Inspection By ReportType
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("inspectionCategory")]
        public IHttpActionResult GetInspectionCategory(int reportType, int category)
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionSubCategory(reportType, category));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
