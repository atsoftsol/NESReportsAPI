using NESReportsDAL;
using NESReportsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsBLL
{
    public class FeedBackBLL
    {
        FeedBackDAL FeedBackReportDAL = new FeedBackDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <param name="ClassCodes"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public FeedBackDTO GetFeedBackReportSummary(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes, int feedbacktype, string feedbackcategory, string StartDate, string EndDate)
        {
            try
            {
                return FeedBackReportDAL.GetFeedBackSummary(StateCodes, DistrictCodes, BranchCodes, ClassCodes, feedbacktype, feedbackcategory, StartDate, EndDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FeedBackType> GetFeedBack()
        {
            try
            {
                return FeedBackReportDAL.GetFeedBack();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FeedBackCategory> GetFeedBackCategory()
        {
            try
            {
                return FeedBackReportDAL.GetFeedBackCategory();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
