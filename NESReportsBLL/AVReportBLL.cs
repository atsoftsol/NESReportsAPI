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
        /// State Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageSummary(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetStateWiseUsageSummary(StateCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// State Wise Usage Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageDetail(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetStateWiseUsageDetail(StateCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// District Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageSummary(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetDistrictWiseUsageSummary(StateCodes,DistrictCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// District Wise Usage Detail 
        /// </summary>
        /// <param name="DistrictCode"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageDetail(string DistrictCode, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetDistrictWiseUsageDetail(DistrictCode, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Branch Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageSummary(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetBranchWiseUsageSummary(StateCodes, DistrictCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Branch Wise Usage Detail 
        /// </summary>
        /// <param name="DistrictCode"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCode, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetBranchWiseUsageDetail(StateCodes, DistrictCodes, BranchCode, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Class Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassWiseUsageSummary(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetClassWiseUsageSummary(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Class Wise Usage detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public AVReportDTO GetClassWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCode, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetClassWiseUsageDetail(StateCodes, DistrictCodes, BranchCodes, ClassCode, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Branch Wise Usage By State and District
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetUsageBranchByStateandDistrict(StateCodes, DistrictCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                return avReportDAL.GetUsageBranchByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Class Wise Usage By State and District and Branch
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetClassByStateandDistrictandBranch(StateCodes, DistrictCodes, BranchCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Subject wise usage Summary
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <param name="ClassCodes"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public AVReportDTO GetSubjectWiseUsageSummary(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetSubjectWiseUsageSummary(StateCodes, DistrictCodes, BranchCodes, ClassCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Subject Wise Usage Details
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <param name="ClassCodes"></param>
        /// <param name="SubjectCodes"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public AVReportDTO GetSubjectWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes, string SubjectCodes, string StartDate, string EndDate)
        {
            try
            {
                return avReportDAL.GetSubjectWiseUsageDetail(StateCodes, DistrictCodes, BranchCodes, ClassCodes, SubjectCodes, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
