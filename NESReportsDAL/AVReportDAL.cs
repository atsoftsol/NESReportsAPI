using MySql.Data.MySqlClient;
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
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetUsageStateByStates(string StateCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetUsageStateByStates", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
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
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GetUsageDistrictByStates", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", StateCodes);
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
        public string GetUsageDistrictsByStatesandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
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
        public string GetUsageBranchByStateandDistrict(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
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
        public string GetUsageBranchByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
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
        public string GetClassByStateandDistrictandBranch(string StateCodes, string DistrictCodes, string BranchCodes, string StartDate, string EndDate)
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
