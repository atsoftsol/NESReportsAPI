using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using NESReportsDTO;
using MySql.Data.MySqlClient;

namespace NESReportsDAL
{
    public class CommonHeaderDAL
    {
        /// <summary>
        /// get States List
        /// </summary>
        /// <returns></returns>
        public List<States> GetStatesList()
        {
            try
            {
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@p_country_id";
                param.Value = 1;
                DataSet ds = CommonDAL.GetRecordWithExtendedTimeOut("GET_STATES", param);
                List<States> model = new List<States>();
                if (ds != null)
                {
                    //Pass datatable from dataset to our DAL Method.
                    model = CommonDAL.CreateListFromTable<States>(ds.Tables[0]);
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateIds"></param>
        /// <returns></returns>
        public List<Districts> GetDistrictList(string stateIds)
        {
            try
            {
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@p_state_ids";
                param.Value = CommonDAL.AddingDoubleCodes(stateIds);
                DataSet dsDistrict = CommonDAL.GetRecordWithExtendedTimeOut("GET_DISTRICTS", param);
                List<Districts> model = new List<Districts>();
                if (dsDistrict != null)
                {
                    //Pass datatable from dataset to our DAL Method.
                    model = CommonDAL.CreateListFromTable<Districts>(dsDistrict.Tables[0]);
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtIds"></param>
        /// <returns></returns>
        public List<Branches> GetBranches(string districtIds)
        {
            try
            {
                MySqlParameter[] parameters = {
                new MySqlParameter("@p_district_ids",  CommonDAL.AddingDoubleCodes(districtIds))
                     };

                DataSet dsDistrict = CommonDAL.GetRecordWithExtendedTimeOut("GET_BRANCHES", parameters);
                List<Branches> model = new List<Branches>();
                if (dsDistrict != null)
                {
                    //Pass datatable from dataset to our DAL Method.
                    model = CommonDAL.CreateListFromTable<Branches>(dsDistrict.Tables[0]);
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Classes
        /// </summary>
        /// <returns></returns>
        public List<Course> GetClasses()
        {
            try
            {
                DataSet dsCourse = CommonDAL.GetRecordWithExtendedTimeOut("GET_COURSES");
                List<Course> model = new List<Course>();
                if (dsCourse != null)
                {
                    //Pass datatable from dataset to our DAL Method.
                    model = CommonDAL.CreateListFromTable<Course>(dsCourse.Tables[0]);
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Subjects
        /// </summary>
        /// <returns></returns>
        public List<Subject> GetSubjects()
        {
            try
            {
                DataSet dsSubjects = CommonDAL.GetRecordWithExtendedTimeOut("GET_SUBJECTS");
                List<Subject> model = new List<Subject>();

                if (dsSubjects != null)
                {
                    //Pass datatable from dataset to our DAL Method.
                    model = CommonDAL.CreateListFromTable<Subject>(dsSubjects.Tables[0]);
                }
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get States
        /// </summary>
        /// <returns></returns>
        public AVReportDTO GetStates()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_STATES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iCOUNTRYSLNO", OracleDbType.Int32).Value = 1;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// Get Districts
        /// </summary>
        /// <param name="stateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetDistrict(int stateCodes)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_DISTRICTS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iSTATESLNO", OracleDbType.Int32).Value = stateCodes;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// Get Category By Report ID
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetCategoryByReportId(int reportType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_REPORT_CATEGORY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = reportType;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// Get Sub Category By Report Type and Category
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetSubCategoryByReportTypeAndCategory(int reportType, int category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_SUB_CATEGORY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("iCATEGORYSLNO", OracleDbType.Int32).Value = category;
                    cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = reportType;
                    cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                    {
                        return CommonDAL.OracleDataTableToJsonstring(cmd);
                    }
                }
            }

        }

        /// <summary>
        /// Get Reports
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public AVReportDTO GetReports()
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
