using MySql.Data.MySqlClient;
using NESReportsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDAL
{
    public class AVReportDAL
    {
        /// <summary>
        /// State Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageSummary(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_STATE_WIDE_USAGE_SUMMARY", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  State Wise Usage Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetStateWiseUsageDetail(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_STATE_WIDE_USAGE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  District Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageSummary(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_DISTRICT_WIDE_USAGE_SUMMARY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  District Wise Usage Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageDetail(string DistrictCode, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_DISTRICT_WIDE_USAGE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DistrictCode", CommonDAL.AddingDoubleCodes(DistrictCode));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  Branch Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageSummary(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_BRANCH_WIDE_USAGE_SUMMARY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  Branch Wise Usage Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetBranchWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCode, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_BRANCH_WIDE_USGAE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@BranchCode", CommonDAL.AddingDoubleCodes(BranchCode));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  Class Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassWiseUsageSummary(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_CLASS_WIDE_USGAE_SUMMARY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@BranchCodes", CommonDAL.AddingDoubleCodes(BranchCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// District Wise Usage Report by State and District 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetUsageDistrictsByStatesandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetUsageDistrictsByStatesandDistrict", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Branch Wise Usage Reports By State and District
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetUsageBranchByStateandDistrict", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Branch wise Usage Reports By State and District and Branch
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <param name="BranchCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetUsageBranchByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetUsageBranchByStateandDistrictandBranch", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@BranchCodes", BranchCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Class wise Usage Reports by State and District and Branch
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetClassByStateandDistrictandBranch", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@BranchCodes", BranchCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Subject Wise Usage Summary Reports by State and District and Branch and Class
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetSubjectWiseUsageSummary(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_SUBJECT_WIDE_USAGE_SUMMARY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@BranchCodes", BranchCodes);
                        cmd.Parameters.AddWithValue("@ClassCode", ClassCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Subject Wise Usage Detail Reports by State and District and Branch and Class and Subject
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <param name="DistrictCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetSubjectWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes,string SubjectCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_SUBJECT_WIDE_USAGE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
                        cmd.Parameters.AddWithValue("@DistrictCodes", DistrictCodes);
                        cmd.Parameters.AddWithValue("@BranchCodes", BranchCodes);
                        cmd.Parameters.AddWithValue("@ClassCode", ClassCodes);
                        cmd.Parameters.AddWithValue("@SubjectCodes", SubjectCodes);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
