﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESReportsDTO;

namespace NESReportsDAL
{
    public class FeedBackDAL
    {
        /// <summary>
        /// State Wise Usage Summary 
        /// </summary>
        /// <param name="StateCodes"></param>
        /// <returns></returns>
        public FeedBackDTO GetFeedBackSummary(string StateCodes, string DistrictCodes, string BranchCode, string ClassCode, int feedbacktype, string feedbackcategory, string StartDate, string EndDate)
        {
            try
            {
                string sortingType = "State";
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_FEEDBACKREPORT", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iSTATEID", OracleDbType.Varchar2).Value = StateCodes;

                        if (DistrictCodes == string.Empty)
                        {
                            cmd.Parameters.Add("iDISTRICT", OracleDbType.Varchar2).Value = DBNull.Value;
                        }
                        else
                        {
                            sortingType = "District";
                            cmd.Parameters.Add("iDISTRICT", OracleDbType.Varchar2).Value = DistrictCodes;
                        }

                        if (BranchCode == string.Empty)
                        {
                            cmd.Parameters.Add("iBRANCH", OracleDbType.Varchar2).Value = DBNull.Value;
                        }
                        else
                        {
                            sortingType = "Branch";
                            cmd.Parameters.Add("iBRANCH", OracleDbType.Varchar2).Value = BranchCode;
                        }

                        if (ClassCode == string.Empty)
                        {
                            cmd.Parameters.Add("iCLASS", OracleDbType.Varchar2).Value = DBNull.Value;
                        }
                        else
                        {
                            sortingType = "Class";
                            cmd.Parameters.Add("iCLASS", OracleDbType.Varchar2).Value = ClassCode;
                        }

                        cmd.Parameters.Add("iFEEDBACKTYPE", OracleDbType.Int32).Value = feedbacktype;

                        if (feedbackcategory == string.Empty || feedbackcategory == "\"\"")
                        {
                            cmd.Parameters.Add("iFEEDBACKCATEGORY", OracleDbType.Varchar2).Value = DBNull.Value;
                        }
                        else
                        {
                            sortingType = "Class";
                            cmd.Parameters.Add("iFEEDBACKCATEGORY", OracleDbType.Varchar2).Value = feedbackcategory;
                        }


                        cmd.Parameters.Add("iSTARTDATE", OracleDbType.Varchar2).Value = StartDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("iENDDATE", OracleDbType.Varchar2).Value = EndDate.Replace(@"\", "").Replace(@"""", @"");
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            return CommonDAL.OracleDataTableFeedBackReportToJsonstring(cmd, sortingType);
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FeedBackType> GetFeedBack()
        {
            List<FeedBackType> FeedBackTypeList = new List<FeedBackType>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;

                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_FEEDBACKTYPE", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                            using (OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sqlDataAdapter.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        FeedBackType feedBackType = new FeedBackType();
                                        feedBackType.FeedBackTypeId = int.Parse(dr["SLNO"].ToString());
                                        feedBackType.FeedBackTypeName = dr["FEEDBACKTYPE"].ToString();
                                     //   feedBackType.IsDeleted = int.Parse(dr["ISDELETED"].ToString());
                                        FeedBackTypeList.Add(feedBackType);
                                    }
                                }

                            }
                        }
                    }
                }
                return FeedBackTypeList;
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
                List<FeedBackCategory> FeedBackCategoryList = new List<FeedBackCategory>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_FEEDBACKCATEGORY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                            using (OracleDataAdapter sqlDataAdapter = new OracleDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sqlDataAdapter.Fill(dt);

                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        FeedBackCategory feedBackCategory = new FeedBackCategory();
                                        feedBackCategory.FeedBackCategoryId = int.Parse(dr["SLNO"].ToString());
                                        feedBackCategory.FeedBackCategoryName = dr["CATEGORYNAME"].ToString();
                                       // feedBackCategory.IsDeleted = int.Parse(dr["ISDELETED"].ToString());
                                        FeedBackCategoryList.Add(feedBackCategory);
                                    }
                                }
                            }
                        }
                    }
                }

                return FeedBackCategoryList;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
