﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NESReportsBLL;
using NESReportsDTO;

namespace NESReportsAPI.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonHeaderController : ApiController
    {

        CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("states")]
        public List<States> GetStates()
        {
            try
            { 
                return commonHeaderBLL.GetStates();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("districts/{stateIds}")]
        public List<Districts> GetDistrict(string stateIds)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetDistrict(stateIds);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("branches/{districtIds}")]
        public List<Branches> GetBranches(string districtIds)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetBranches(districtIds);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("courses")]
        public List<Course> GetClasses()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetClasses();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("categorybyreport/{reportType}")]
        public AVReportDTO GetCategoryByReportId(int reportType)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetCategoryByReportId(reportType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("subcategorybyreportandcategory/{reportType}/{category}")]
        public AVReportDTO GetSubCategoryByReportTypeAndCategory(int reportType, int category)
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetSubCategoryByReportTypeAndCategory(reportType, category);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <returns></returns>
        [Route("reportcategory")]
        public AVReportDTO GetReports()
        {
            try
            {
                CommonHeaderBLL commonHeaderBLL = new CommonHeaderBLL();
                return commonHeaderBLL.GetReports();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
