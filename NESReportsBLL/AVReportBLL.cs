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
        public string GetUsageStateByStates(string StateCodes)
        {
            try
            {
                return avReportDAL.GetUsageStateByStates(StateCodes);
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
        public string GetUsageDistrictByStates(string StateCodes)
        {
            try
            {
                return avReportDAL.GetUsageDistrictByStates(StateCodes);
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
        public string GetUsageDistrictsByStatesandDistrict(string StateCodes, string DistrictCodes)
        {
            try
            {
                return avReportDAL.GetUsageDistrictsByStatesandDistrict(StateCodes, DistrictCodes);
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
        public string GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes)
        {
            try
            {
                return avReportDAL.GetUsageBranchByStateandDistrict(StateCodes, DistrictCodes);
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
        public string GetUsageBranchByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes)
        {
            return avReportDAL.GetUsageBranchByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes);
        }
    }
}
