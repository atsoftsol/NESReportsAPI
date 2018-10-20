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
        /// State Wise Usgae Summary 
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
                return null;
            }
             
        }

      

        /// <summary>
        ///  State Wise Usgae Detail 
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

            }

            return null;
        }




        /// <summary>
        ///  District Wise Usgae Summary 
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

            }

            return null;
        }


        /// <summary>
        ///  District Wise Usgae Detail 
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

            }

            return null;
        }


        /// <summary>
        ///  Branch Wise Usgae Summary 
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

            }

            return null;
        }


        /// <summary>
        ///  Branch Wise Usgae Detail 
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

            }

            return null;
        }

        /// <summary>
        ///  Class Wise Usgae Summary 
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

            }

            return null;
        }



        /// <summary>
        /// 
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

            }

            return null;
        }

        /// <summary>
        /// 
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

            }

            return null;
        }





    }
}
