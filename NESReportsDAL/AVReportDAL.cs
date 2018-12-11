using MySql.Data.MySqlClient;
using NESReportsDTO;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
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
        #region mysql

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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  District Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrictWiseUsageSummary(string StateCodes, string DistrictCodes, string StartDate, string EndDate)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Class Wise Usage Detail 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetClassWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCode, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_CLASS_WIDE_USAGE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@BranchCodes", CommonDAL.AddingDoubleCodes(BranchCodes));
                        cmd.Parameters.AddWithValue("@ClassCode", CommonDAL.AddingDoubleCodes(ClassCode));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception)
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
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@BranchCodes", CommonDAL.AddingDoubleCodes(BranchCodes));
                        cmd.Parameters.AddWithValue("@ClassCode", CommonDAL.AddingDoubleCodes(ClassCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception)
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
        public AVReportDTO GetSubjectWiseUsageDetail(string StateCodes, string DistrictCodes, string BranchCodes, string ClassCodes, string SubjectCodes, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("GET_SUBJECT_WIDE_USAGE_DETAIL", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateCodes", CommonDAL.AddingDoubleCodes(StateCodes));
                        cmd.Parameters.AddWithValue("@DistrictCodes", CommonDAL.AddingDoubleCodes(DistrictCodes));
                        cmd.Parameters.AddWithValue("@BranchCodes", CommonDAL.AddingDoubleCodes(BranchCodes));
                        cmd.Parameters.AddWithValue("@ClassCodes", CommonDAL.AddingDoubleCodes(ClassCodes));
                        cmd.Parameters.AddWithValue("@SubjectCodes", CommonDAL.AddingDoubleCodes(SubjectCodes));
                        cmd.Parameters.AddWithValue("@StartDate", StartDate.Replace(@"\", "").Replace(@"""", @""));
                        cmd.Parameters.AddWithValue("@EndDate", EndDate.Replace(@"\", "").Replace(@"""", @""));
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            return CommonDAL.DataTableToJsonstring(cmd);
                        }
                    }
                }
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }

        }

        #endregion


        /// <summary>
        /// State Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetAvReportSummary(string StateCodes, string DistrictCodes, string BranchCode, string ClassCode, string subjectCode, string contentCode, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_AVREPORT1", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iSTATEID", OracleDbType.Varchar2).Value = StateCodes;

                        if (DistrictCodes == string.Empty)
                            cmd.Parameters.Add("iDISTRICT", OracleDbType.Varchar2).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add("iDISTRICT", OracleDbType.Varchar2).Value = DistrictCodes;

                        if (BranchCode == string.Empty)
                            cmd.Parameters.Add("iBRANCH", OracleDbType.Varchar2).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add("iBRANCH", OracleDbType.Varchar2).Value = BranchCode;

                        if (ClassCode == string.Empty)
                            cmd.Parameters.Add("iCLASS", OracleDbType.Varchar2).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add("iCLASS", OracleDbType.Varchar2).Value = ClassCode;

                        if (subjectCode == string.Empty)
                            cmd.Parameters.Add("iSUBJECT", OracleDbType.Varchar2).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add("iSUBJECT", OracleDbType.Varchar2).Value = subjectCode;

                        if (contentCode == string.Empty)
                            cmd.Parameters.Add("iCONTENT", OracleDbType.Varchar2).Value = DBNull.Value;
                        else
                            cmd.Parameters.Add("iCONTENT", OracleDbType.Varchar2).Value = contentCode;

                        cmd.Parameters.Add("iSTARTDATE", OracleDbType.Varchar2).Value = StartDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("iENDDATE", OracleDbType.Varchar2).Value = EndDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        bool strengthstatus = true;

                        if (subjectCode != string.Empty || contentCode != string.Empty)
                        {
                            strengthstatus = false;
                        }

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            return CommonDAL.OracleDataTableToJsonstring(cmd, strengthstatus);
                        }
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// State Wise Usage Details 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetAvReportDetails(int StateCodes, int DistrictCodes, int BranchCode, int ClassCode, int subjectCode, int contentCode, string StartDate, string EndDate)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_AVREPORTSUMMARY1", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iSTATEID", OracleDbType.Int32).Value = StateCodes;
                        cmd.Parameters.Add("iDISTRICT", OracleDbType.Int32).Value = DistrictCodes;
                        cmd.Parameters.Add("iBRANCH", OracleDbType.Int32).Value = BranchCode;
                        cmd.Parameters.Add("iCLASS", OracleDbType.Int32).Value = ClassCode;
                        cmd.Parameters.Add("iSUBJECT", OracleDbType.Int32).Value = subjectCode;
                        cmd.Parameters.Add("iCONTENT", OracleDbType.Int32).Value = contentCode;
                        cmd.Parameters.Add("iSTARTDATE", OracleDbType.Varchar2).Value = StartDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("iENDDATE", OracleDbType.Varchar2).Value = EndDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        bool strengthstatus = true;

                        if (subjectCode != 0 || contentCode != 0)
                        {
                            strengthstatus = false;
                        }

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            return CommonDAL.OracleDataTableToJsonstring(cmd, strengthstatus);
                        }
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
