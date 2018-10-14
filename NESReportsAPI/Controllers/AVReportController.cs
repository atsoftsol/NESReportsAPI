using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NESReportsBLL;

namespace NESReportsAPI.Controllers
{
    public class AVReportController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="stateCodes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AVReport/GetBranchWiseUsageReport/{branchCodes}/{districtCodes}/{stateCodes}/{StartDate}/{EndDate}")]
        public string GetBranchWiseUsageReport(string branchCodes, string districtCodes, string stateCodes, string StartDate, string EndDate)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty && districtCodes != string.Empty && branchCodes != string.Empty)
                {
                    return avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes, StartDate, EndDate);
                }
                else 
                {
                    return avReportBLL.GetUsageBranchByStateandDistrictandBranch(stateCodes, districtCodes, branchCodes, StartDate, EndDate);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtCodes"></param>
        /// <param name="stateCodes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AVReport/GetDistrictWiseUsageReport/{districtCodes}/{stateCodes}/{StartDate}/{EndDate}")]
        public string GetDistrictWiseUsageReport(string districtCodes, string stateCodes, string StartDate, string EndDate)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty && districtCodes != string.Empty)
                {
                    return avReportBLL.GetUsageDistrictsByStatesandDistrict(stateCodes, districtCodes, StartDate, EndDate);
                }
                else
                {
                    return string.Empty;// avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AVReport/GetStateWiseUsageReport/{stateCodes}/{StartDate}/{EndDate}")]
        public string GetStateWiseUsageReport(string stateCodes, string StartDate, string EndDate)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty )
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes, StartDate, EndDate);
                }
                else
                {
                    return string.Empty;// avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AVReport/GetUsageReport/{stateCodes}/{StartDate}/{EndDate}")]
        public string GetUsageReport(string stateCodes, string districtCodes, string branchCodes, string StartDate, string EndDate)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes == "null" && districtCodes == "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes, StartDate, EndDate);
                }
                else if (stateCodes != "null" && districtCodes == "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes, StartDate, EndDate);
                }
                else if (stateCodes != "null" && districtCodes != "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageDistrictsByStatesandDistrict(stateCodes, districtCodes, StartDate, EndDate);
                }
                else //IF(stateCode != "null" && DistrictCode != "null" && BranchCode != "null")
                {
                    return avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes, StartDate, EndDate);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <param name="districtCodes"></param>
        /// <param name="branchCodes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AVReport/GetClassUsageReport/{classCodes}/{branchCodes}/{districtCodes}/{stateCodes}/{StartDate}/{EndDate}")]
        public string GetClassUsageReport(string stateCodes, string districtCodes, string branchCodes, string classCodes, string StartDate, string EndDate)
        {
            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty && districtCodes != string.Empty && branchCodes != string.Empty)
                {
                    return avReportBLL.GetClassByStateandDistrictandBranch(stateCodes, districtCodes, branchCodes, StartDate, EndDate);
                }
                else
                {
                    return avReportBLL.GetClassByStateandDistrictandBranch(stateCodes, districtCodes, branchCodes, StartDate, EndDate);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

    }
}
