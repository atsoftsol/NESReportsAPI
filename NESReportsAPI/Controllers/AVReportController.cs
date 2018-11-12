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
            try
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
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
            try
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
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// District Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("districtwiseusagesummary/{stateCodes}/{districtCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetDistrictWiseUsageSummary(string stateCodes, string districtCodes, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateCodes))
                {
                    AVReportDTO jsonData = avReportBLL.GetDistrictWiseUsageSummary(stateCodes, districtCodes, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(avReportBLL.GetDistrictWiseUsageSummary(stateCodes, districtCodes, startDate, endDate));
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
        public IHttpActionResult GetDistrictWiseUsageDetail([FromUri] string districtCode, string startDate, string endDate)
        {
            try
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
            try
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
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
            try
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
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
        [Route("coursewiseusagesummary/{stateCodes}/{districtCodes}/{branchCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetClassWiseUsageSummary(string stateCodes, string districtCodes, string branchCodes, string startDate, string endDate)
        {
            try
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
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Class Wise Usage Detail
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("coursewiseusagedetails/{stateCodes}/{districtCodes}/{branchCodes}/{courseCode}/{startDate}/{endDate}")]
        public IHttpActionResult GetClassWiseUsageDetail(string stateCodes, string districtCodes, string branchCodes, string courseCode, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateCodes) && !string.IsNullOrEmpty(districtCodes) && !string.IsNullOrEmpty(branchCodes) && !string.IsNullOrEmpty(courseCode))
                {
                    AVReportDTO jsonData = avReportBLL.GetClassWiseUsageDetail(stateCodes, districtCodes, branchCodes, courseCode, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(avReportBLL.GetClassWiseUsageDetail(stateCodes, districtCodes, branchCodes, courseCode, startDate, endDate));
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Subject Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <param name="classCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("subjectwiseusagesummary/{stateCodes}/{districtCodes}/{branchCodes}/{courseCodes}/{startDate}/{endDate}")]
        public IHttpActionResult GetSubjectWiseUsageSummary(string stateCodes, string districtCodes, string branchCodes, string courseCodes, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateCodes) && !string.IsNullOrEmpty(districtCodes) && !string.IsNullOrEmpty(branchCodes))
                {
                    AVReportDTO jsonData = avReportBLL.GetSubjectWiseUsageSummary(stateCodes, districtCodes, branchCodes, courseCodes, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(avReportBLL.GetSubjectWiseUsageSummary(stateCodes, districtCodes, branchCodes, courseCodes, startDate, endDate));
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Subject Wise Usage Details
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <param name="ClassCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("subjectwiseusagedetails/{stateCodes}/{districtCodes}/{branchCodes}/{courseCodes}/{subjectCode}/{startDate}/{endDate}")]
        public IHttpActionResult GetSubjectWiseUsageDetail(string stateCodes, string districtCodes, string branchCodes, string courseCodes, string subjectCode, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateCodes) && !string.IsNullOrEmpty(districtCodes) && !string.IsNullOrEmpty(branchCodes))
                {
                    AVReportDTO jsonData = avReportBLL.GetSubjectWiseUsageDetail(stateCodes, districtCodes, branchCodes, courseCodes, subjectCode, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(avReportBLL.GetSubjectWiseUsageDetail(stateCodes, districtCodes, branchCodes, courseCodes, subjectCode, startDate, endDate));
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        //[Route("getIds")]
        //public IHttpActionResult GetIds(string ids)
        //{
        //    return Ok(ids);
        //}
    }
}
