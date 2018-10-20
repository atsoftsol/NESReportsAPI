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
    [RoutePrefix("api/avreport")]
    public class AVReportController : ApiController
    {
        AVReportBLL avReportBLL = new AVReportBLL();

       
        /// <summary>
        /// State Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("statewiseusagesummary/{stateCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetStateWiseUsageSummary(string stateCodes, string startDate, string endDate)
        {
            if (stateCodes != string.Empty)
            {
                AVReportDTO jsonData = avReportBLL.GetStateWiseUsageSummary(stateCodes, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetStateWiseUsageSummary(stateCodes, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }

       
        /// <summary>
        /// State Wise Usgae Detail
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("statewiseusagedetails/{stateCode}/{startDate}/{endDate}")]
        public IHttpActionResult GetStateWiseUsageDetail(string stateCode, string startDate, string endDate)
        {
            if (stateCode != string.Empty)
            {
                AVReportDTO jsonData = avReportBLL.GetStateWiseUsageDetail(stateCode, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetStateWiseUsageDetail(stateCode, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// District Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("districtwiseusagesummary/{stateCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetDistrictWiseUsageSummary(string stateCodes, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(stateCodes))
            {
                AVReportDTO jsonData = avReportBLL.GetDistrictWiseUsageSummary(stateCodes, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetDistrictWiseUsageSummary(stateCodes, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// District Wise Usgae Detail
        /// </summary>
        /// <param name="districtCode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("districtwiseusagedetails/{districtCode}/{startDate}/{endDate}")]
    
        public IHttpActionResult GetDistrictWiseUsageDetail(string districtCode, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(districtCode))
            {
                AVReportDTO jsonData = avReportBLL.GetDistrictWiseUsageDetail(districtCode, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetDistrictWiseUsageDetail(districtCode, startDate, endDate));
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                return InternalServerError();
            }
        }


        /// <summary>
        /// Branch Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("branchwiseusagesummary/{stateCodes}/{districtCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetBranchWiseUsageSummary(string stateCodes, string districtCodes, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(stateCodes) && !string.IsNullOrEmpty(districtCodes))
            {
                AVReportDTO jsonData = avReportBLL.GetBranchWiseUsageSummary(stateCodes, districtCodes, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetBranchWiseUsageSummary(stateCodes, districtCodes, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Branch Wise Usage Detail
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("branchwiseusagedetails/{stateCode}/{districtCode}/{branchCode}/{startDate}/{endDate}")]
        public IHttpActionResult GetBranchWiseUsageDetail(string stateCode, string districtCode, string branchCode, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(branchCode))
            {
                AVReportDTO jsonData = avReportBLL.GetBranchWiseUsageDetail(stateCode, districtCode, branchCode, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetBranchWiseUsageDetail(stateCode, districtCode, branchCode, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Class Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("classwiseusagesummary/{stateCodes}/{districtCodes}/{branchCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetClassWiseUsageSummary(string stateCodes, string districtCodes, string branchCodes, string startDate, string endDate)
        {
            if (!string.IsNullOrEmpty(stateCodes) && !string.IsNullOrEmpty(districtCodes) && !string.IsNullOrEmpty(branchCodes))
            {
                AVReportDTO jsonData = avReportBLL.GetClassWiseUsageSummary(stateCodes, districtCodes, branchCodes, startDate, endDate);

                if (jsonData != null)
                {
                    return Ok(avReportBLL.GetClassWiseUsageSummary(stateCodes, districtCodes, branchCodes, startDate, endDate));
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
