using NESReportsDTO;
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
    public class InspectionDAL
    {

        /// <summary>
        /// Get Inspection
        /// </summary>
        /// <returns></returns>
        public List<InspectionType> GetInspectionType()
        {
            try
            {
                List<InspectionType> inspectionTypeList = new List<InspectionType>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleMasterString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_REPORT_TYPES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    InspectionType inspectionType = new InspectionType();
                                    inspectionType.Id = int.Parse(dr["REPORTTYPESLNO"].ToString());
                                    inspectionType.Type = dr["REPORTTYPE"].ToString();
                                    inspectionTypeList.Add(inspectionType);
                                }
                            }

                            return inspectionTypeList;
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
        /// Get Inspection Category 
        /// </summary>
        /// <returns></returns>
        public List<InspectionCategory> GetInspectionCategory(int ReportId)
        {
            try
            {
                List<InspectionCategory> inspectionCategoryList = new List<InspectionCategory>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleMasterString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_REPORT_CATEGORY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = ReportId;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    InspectionCategory inspectionCategory = new InspectionCategory();
                                    inspectionCategory.CategoryId = int.Parse(dr["CATEGORYSLNO"].ToString());
                                    inspectionCategory.Name = dr["CATEGORYNAME"].ToString();
                                    inspectionCategoryList.Add(inspectionCategory);
                                }
                            }

                            return inspectionCategoryList;
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
        /// <param name="ReportId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<InspectionSubCategory> GetInspectionSubCategory(int ReportId, int categoryId)
        {
            try
            {
                List<InspectionSubCategory> inspectionSubCategoryList = new List<InspectionSubCategory>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleMasterString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_SUB_CATEGORY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("iCATEGORYSLNO", OracleDbType.Int32).Value = categoryId;
                        cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Int32).Value = ReportId;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    InspectionSubCategory inspectionSubCategory = new InspectionSubCategory();
                                    inspectionSubCategory.SubCategoryId = int.Parse(dr["CATEGORYSLNO"].ToString());
                                    inspectionSubCategory.Name = dr["CATEGORYNAME"].ToString();
                                    inspectionSubCategoryList.Add(inspectionSubCategory);
                                }
                            }

                            return inspectionSubCategoryList;
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
