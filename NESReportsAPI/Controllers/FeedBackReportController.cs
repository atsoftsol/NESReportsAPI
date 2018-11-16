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
    [RoutePrefix("api/feedbackreport")]
    public class FeedBackReportController : ApiController
    {
        FeedBackBLL FeedBackReportBLL = new FeedBackBLL();

        /// <summary>
        /// State Wise Usage Summary
        /// </summary>
        /// <param name="stateIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("feedbackstatewisesummary")]
        public IHttpActionResult GetFeedBackStateWiseReport(string stateIds,int feedbackType, string feedbackCategories, string feedbackSubCategories, string startDate, string endDate)
        {
            try
            {
                if (stateIds != string.Empty)
                {
                    FeedBackDTO jsonData = FeedBackReportBLL.GetFeedBackReportSummary(stateIds, "", "", "", feedbackType,feedbackCategories,feedbackSubCategories, startDate, endDate);

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
        [Route("feedbackdistrictwisesummary")]
        public IHttpActionResult GetFeedBackDistrictWiseReport(string stateIds, string districtIds, int feedbackType, string feedbackCategories, string feedbackSubCategories, string startDate, string endDate)
        {
            try
            {
                if (stateIds != string.Empty)
                {
                    FeedBackDTO jsonData = FeedBackReportBLL.GetFeedBackReportSummary(stateIds, districtIds, "", "", feedbackType, feedbackCategories, feedbackSubCategories ,startDate, endDate);

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
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("feedbackbranchwisesummary")]
        public IHttpActionResult GetFeedBackBranchWiseReport(string stateIds, string districtIds, string branchIds, int feedbackType, string feedbackCategories, string feedbackSubCategories, string startDate, string endDate)
        {
            try
            {
                if (stateIds != string.Empty)
                {
                    FeedBackDTO jsonData = FeedBackReportBLL.GetFeedBackReportSummary(stateIds, districtIds, branchIds, "", feedbackType, feedbackCategories,feedbackSubCategories, startDate, endDate);

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
        /// Course Wise Usage Summary
        /// </summary>
        /// <param name="stateIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Route("feedbackcoursewisesummary")]
        public IHttpActionResult GetFeedBackCourseWiseReport(string stateIds, string districtIds, string branchIds, string courseIds, int feedbackType, string feedbackCategories, string feedbackSubCategories, string startDate, string endDate)
        {
            try
            {
                if (stateIds != string.Empty)
                {
                    FeedBackDTO jsonData = FeedBackReportBLL.GetFeedBackReportSummary(stateIds, districtIds, branchIds, courseIds, feedbackType, feedbackCategories, feedbackSubCategories, startDate, endDate);

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
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedbacktype")]
        public IHttpActionResult GetFeedBack()
        {
            try
            {
                List<FeedBackType> feedBackTypeList = FeedBackReportBLL.GetFeedBack();

                if (feedBackTypeList != null)
                {
                    return Ok(feedBackTypeList);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedbackcategory")]
        public IHttpActionResult GetFeedBackCategory()
        {
            try
            {
                List<FeedBackCategory> feedBackCategoryList = FeedBackReportBLL.GetFeedBackCategory();

                if (feedBackCategoryList != null)
                {
                    return Ok(feedBackCategoryList);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feedbackcategoryIds"></param>
        /// <returns></returns>
        [Route("feedbackSubcategory")]
        public  IHttpActionResult GetFeedBackSubCategory(string feedbackcategoryIds)
        {
            try
            {
                List<FeedBackSubCategory> feedBackSubCategoryList = FeedBackReportBLL.GetFeedBackSubCategory(feedbackcategoryIds);

                if (feedBackSubCategoryList != null)
                {
                    return Ok(feedBackSubCategoryList);
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
