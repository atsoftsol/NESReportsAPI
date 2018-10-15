using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace NESReportsDAL
{
    public class CommonHeaderDAL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStates()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_STATES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iCOUNTRYSLNO",OracleDbType.Int32).Value = 1;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetDistrict(int StateCodes)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_DISTRICTS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iSTATESLNO", OracleDbType.Int32).Value = StateCodes;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetCategoryByReportId(int ReportType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_REPORT_CATEGORY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = ReportType;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetSubCategoryByReportTypeAndCategory(int ReportType, int category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_SUB_CATEGORY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iCATEGORYSLNO", OracleDbType.Int32).Value = category;
                    cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = ReportType;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public string GetReports()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_REPORT_TYPES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }
    }
}
