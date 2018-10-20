using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESReportsDAL;
using NESReportsDTO;
namespace NESReportsBLL
{
    public class AVReportBLL
    {
        AVReportDAL avReportDAL = new AVReportDAL();

        /// <summary>
        /// State Wise Usgae Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageSummary(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetStateWiseUsageSummary(StateCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {
              
            }

            return null;
        }

        /// <summary>
        /// State Wise Usgae Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageDetail(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetStateWiseUsageDetail(StateCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        
        /// <summary>
        /// District Wise Usgae Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageSummary(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetDistrictWiseUsageSummary(StateCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// District Wise Usgae Detail 
        /// </summary>
        /// <param name="DistrictCode"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageDetail(string DistrictCode, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetDistrictWiseUsageDetail(DistrictCode, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }
            return null;
        }


        /// <summary>
        /// Branch Wise Usgae Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageSummary(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetBranchWiseUsageSummary(StateCodes, DistrictCodes, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }


        /// <summary>
        /// Brnach Wise Usgae Detail 
        /// </summary>
        /// <param name="DistrictCode"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCode, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetBranchWiseUsageDetail(StateCodes, DistrictCodes, BranchCode, StartDate, EndDate);
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        /// <summary>
        /// Class Wise Usgae Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassWiseUsageSummary(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetClassWiseUsageSummary(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
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
        public AVReportDTO GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
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
        public AVReportDTO GetUsageBranchByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
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
        public AVReportDTO GetClassByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            return avReportDAL.GetClassByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
        }
    }
}
