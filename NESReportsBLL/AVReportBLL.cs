using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESReportsDAL;
namespace NESReportsBLL
{
    public class AVReportBLL
    {
        AVReportDAL avReportDAL = new AVReportDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetUsageStateByStates(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetUsageStateByStates(StateCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetUsageDistrictByStates(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetUsageDistrictByStates(StateCodes,StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetUsageDistrictsByStatesandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetUsageDistrictsByStatesandDistrict(StateCodes, DistrictCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetUsageBranchByStateandDistrict(StateCodes, DistrictCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <returns></returns>
        public string GetUsageBranchByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            return avReportDAL.GetUsageBranchByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <returns></returns>
        public string GetClassByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            return avReportDAL.GetClassByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
        }
    }
}
