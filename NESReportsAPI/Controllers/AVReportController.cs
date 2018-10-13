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
        [Route("api/AVReport/GetBranchWiseUsageReport/{branchCodes}/{districtCodes}/{stateCodes}")]
        public string GetBranchWiseUsageReport(string branchCodes, string districtCodes, string stateCodes)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty && districtCodes != string.Empty && branchCodes != string.Empty)
                {
                    return avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes);
                }
                else 
                {
                    return avReportBLL.GetUsageBranchByStateandDistrictandBranch(stateCodes, districtCodes, branchCodes);
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
        [Route("api/AVReport/GetDistrictWiseUsageReport/{districtCodes}/{stateCodes}")]
        public string GetDistrictWiseUsageReport(string districtCodes, string stateCodes)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty && districtCodes != string.Empty)
                {
                    return avReportBLL.GetUsageDistrictsByStatesandDistrict(stateCodes, districtCodes);
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
        [Route("api/AVReport/GetStateWiseUsageReport/{stateCodes}")]
        public string GetStateWiseUsageReport(string stateCodes)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes != string.Empty )
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes);
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
        [Route("api/AVReport/GetUsageReport/{stateCodes}")]
        public string GetUsageReport(string stateCodes, string districtCodes, string branchCodes)
        {

            try
            {
                AVReportBLL avReportBLL = new AVReportBLL();

                if (stateCodes == "null" && districtCodes == "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes);
                }
                else if (stateCodes != "null" && districtCodes == "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageStateByStates(stateCodes);
                }
                else if (stateCodes != "null" && districtCodes != "null" && branchCodes == "null")
                {
                    return avReportBLL.GetUsageDistrictsByStatesandDistrict(stateCodes, districtCodes);
                }
                else //IF(stateCode != "null" && DistrictCode != "null" && BranchCode != "null")
                {
                    return avReportBLL.GetUsageBranchByStateandDistrict(stateCodes, districtCodes);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
