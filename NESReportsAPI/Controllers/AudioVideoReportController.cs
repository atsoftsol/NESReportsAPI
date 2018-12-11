using NESReportsBLL;
using NESReportsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NESReportsAPI.Controllers
{
    [RoutePrefix("api/audiovideoreport")]
    public class AudioVideoReportController : ApiController
    {
        AVReportBLL avReportBLL = new AVReportBLL();

        /// <summary>
        /// State Wise Usage Summary
        /// </summary>
        /// <param name="stateIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("statewiseusagesummary")]
        public IHttpActionResult GetStateWiseUsageSummary(string stateIds, string startDate, string endDate)
        {
            try
            {
                if (stateIds != string.Empty)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, "", "", "", "", "", startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// <param name="stateIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("districtwiseusagesummary")]
        public IHttpActionResult GetDistrictWiseUsageSummary(string stateIds, string districtIds, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateIds))
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, districtIds, "", "", "", "", startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// Branch Wise Usage Summary
        /// </summary>
        /// <param name="stateIds"></param>
        /// <param name="districtIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("branchwiseusagesummary")]
        public IHttpActionResult GetBranchWiseUsageSummary(string stateIds, string districtIds, string branchIds, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateIds) && !string.IsNullOrEmpty(districtIds))
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, districtIds, branchIds, "", "", "", startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// <param name="stateIds"></param>
        /// <param name="districtIds"></param>
        /// <param name="branchIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("coursewiseusagesummary")]
        public IHttpActionResult GetClassWiseUsageSummary(string stateIds, string districtIds, string branchIds, string courseIds, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateIds) && !string.IsNullOrEmpty(districtIds) && !string.IsNullOrEmpty(branchIds) && !string.IsNullOrEmpty(courseIds))
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, districtIds, branchIds, courseIds, "", "", startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// <param name="stateIds"></param>
        /// <param name="districtIds"></param>
        /// <param name="branchIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("subjectwiseusagesummary")]
        public IHttpActionResult GetSubjectWiseUsageSummary(string stateIds, string districtIds, string branchIds, string subjectIds, string courseIds, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateIds) && !string.IsNullOrEmpty(districtIds) && !string.IsNullOrEmpty(branchIds) && !string.IsNullOrEmpty(courseIds) && !string.IsNullOrEmpty(subjectIds))
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, districtIds, branchIds, courseIds, subjectIds, "", startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// Content Wise Usage Summary
        /// </summary>
        /// <param name="stateIds"></param>
        /// <param name="districtIds"></param>
        /// <param name="branchIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("contentwiseusagesummary")]
        public IHttpActionResult GetContentWiseUsageSummary(string stateIds, string districtIds, string branchIds, string subjectIds, string courseIds, string contentIds, string startDate, string endDate)
        {
            try
            {
                if (!string.IsNullOrEmpty(stateIds) && !string.IsNullOrEmpty(districtIds) && !string.IsNullOrEmpty(branchIds) && !string.IsNullOrEmpty(courseIds) && !string.IsNullOrEmpty(subjectIds))
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportSummary(stateIds, districtIds, branchIds, courseIds, subjectIds, contentIds, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// State Wise Usage Summary
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("statewiseusagedetail/{stateId}/{startDate}/{endDate}")]
        public IHttpActionResult GetStateWiseUsageDetail(int stateId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, 0, 0, 0, 0, 0, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        [Route("districtwiseusagedetail/{stateId}/{districtId}/{startDate}/{endDate}")]
        public IHttpActionResult GetDistrictWiseUsageDetail(int stateId, int districtId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0 && districtId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, districtId, 0, 0, 0, 0, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// Branch Wise Usage Summary
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("branchwiseusagedetail/{stateId}/{districtId}/{branchId}/{startDate}/{endDate}")]
        public IHttpActionResult GetBranchWiseUsageDetail(int stateId, int districtId, int branchId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0 && districtId > 0 && branchId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, districtId, branchId, 0, 0, 0, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// <param name="stateId"></param>
        /// <param name="districtId"></param>
        /// <param name="branchId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("coursewiseusagedetail/{stateId}/{districtId}/{branchId}/{courseId}/{startDate}/{endDate}")]
        public IHttpActionResult GetClassWiseUsageDetail(int stateId, int districtId, int branchId, int courseId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0 && districtId > 0 && branchId > 0 && courseId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, districtId, branchId, courseId, 0, 0, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// Subject Wise Usage Detail
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="districtId"></param>
        /// <param name="branchId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("subjectwiseusagedetail/{stateId}/{districtId}/{branchId}/{courseId}/{subjectId}/{startDate}/{endDate}")]
        public IHttpActionResult GetSubjectWiseUsageDetail(int stateId, int districtId, int branchId, int courseId, int subjectId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0 && districtId > 0 && branchId > 0 && courseId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, districtId, branchId, courseId, subjectId, 0, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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
        /// Content Wise Usage Detail
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="districtId"></param>
        /// <param name="branchId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("contentwiseusagedetail/{stateId}/{districtId}/{branchId}/{courseId}/{subjectId}/{contentId}/{startDate}/{endDate}")]
        public IHttpActionResult GetContentWiseUsageDetail(int stateId, int districtId, int branchId, int courseId, int subjectId, int contentId, string startDate, string endDate)
        {
            try
            {
                if (stateId > 0 && districtId > 0 && branchId > 0 && courseId > 0 && subjectId > 0 && contentId > 0)
                {
                    AVReportDTO jsonData = avReportBLL.GetAvReportDetails(stateId, districtId, branchId, courseId, subjectId, contentId, startDate, endDate);

                    if (jsonData != null)
                    {
                        return Ok(jsonData);
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



    }


}
