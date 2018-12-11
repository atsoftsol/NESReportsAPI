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
        public List<InspectionCategory> GetInspectionCategory(string ReportId)
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
                        cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Varchar2).Value = ReportId;
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
        public List<InspectionSubCategory> GetInspectionSubCategory(string ReportId, string categoryId)
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
                        cmd.Parameters.Add("iCATEGORYSLNO", OracleDbType.Varchar2).Value = categoryId;
                        cmd.Parameters.Add("iREPORTTYPESLNO", OracleDbType.Varchar2).Value = ReportId;
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
                                    inspectionSubCategory.SubCategoryId = int.Parse(dr["SUBCATEGORYSLNO"].ToString());
                                    inspectionSubCategory.Name = dr["SUBCATEGORYNAME"].ToString();
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

        /// <summary>
        /// Get Inspection Segment
        /// </summary>
        /// <returns></returns>
        public List<InspectionSegment> GetInspectionSegment()
        {
            try
            {
                List<InspectionSegment> inspectionSegmentList = new List<InspectionSegment>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleMasterString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_SEGMENT", con))
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
                                    InspectionSegment inspectionSegment = new InspectionSegment();
                                    inspectionSegment.SegmentId = int.Parse(dr["SEGMENTSLNO"].ToString());
                                    inspectionSegment.Name = dr["NAME"].ToString();
                                    inspectionSegmentList.Add(inspectionSegment);
                                }
                            }

                            return inspectionSegmentList;
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
        /// Insert Inspection Segment
        /// </summary>
        /// <returns></returns>
        public InspectionDTO InsertInspectionSegment(InspectionHeader inSpection)
        {
            try
            {
                InspectionDTO inspectionDTO = new InspectionDTO();
                Assembly assembly = new Assembly();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("INSPECTION_DT_INSERT", con))
                    {
                        cmd.Parameters.Add("iTRANSDATE", OracleDbType.Varchar2).Value = inSpection.date;
                        cmd.Parameters.Add("iSTATESLNO", OracleDbType.Int32).Value = inSpection.stateId;
                        cmd.Parameters.Add("iDISTRICTSLNO", OracleDbType.Int32).Value = inSpection.districtId;
                        cmd.Parameters.Add("iBRANCHSLNO", OracleDbType.Int32).Value = inSpection.branchId;
                        cmd.Parameters.Add("iSTATENAME", OracleDbType.Varchar2).Value = inSpection.state;
                        cmd.Parameters.Add("iDISTRICTNAME", OracleDbType.Varchar2).Value = inSpection.district;
                        cmd.Parameters.Add("iBRANCHNAME", OracleDbType.Varchar2).Value = inSpection.branch;
                        cmd.Parameters.Add("DATACURINSPECTION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("DATACURINSPECTIONASSEMBLY", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("DATACURINSPECTIONDISCIPLINE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataSet ds = new DataSet();
                            sda.Fill(ds);

                            if (ds != null && ds.Tables.Count > 0)
                            {
                                DataTable dtInspection = ds.Tables[0];
                                DataTable dtInspectionAsssembly = ds.Tables[1];
                                DataTable dtInspectiondDiscipline = ds.Tables[2];
                                if (dtInspection != null && dtInspection.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtInspection.Rows)
                                    {
                                        inspectionDTO.inspectionId = int.Parse(dr["INSPECTIONSLNO"].ToString());
                                        inspectionDTO.date = dr["TRANSDATE"].ToString();
                                        inspectionDTO.stateId = int.Parse(dr["STATESLNO"].ToString());
                                        inspectionDTO.districtId = int.Parse(dr["DISTRICTSLNO"].ToString());
                                        inspectionDTO.branchId = int.Parse(dr["BRANCHSLNO"].ToString());
                                        inspectionDTO.state = dr["STATENAME"].ToString();
                                        inspectionDTO.district = dr["DISTRICTNAME"].ToString();
                                        inspectionDTO.branch = dr["BRANCHNAME"].ToString();
                                    }

                                    // Manage Assembly 
                                    inspectionDTO.assembly = ManageAssembly(dtInspectionAsssembly); 
                                    List<Discipline> disciplineList = ManageDiscipline(dtInspectiondDiscipline);

                                    /* subcategory = 7 uniform defaulter ; subcategory = 8  Late comers; subcategory = 9  Id defaulters; subcategory = 10 shoe defaulters  */

                                    if (disciplineList.Count > 0)
                                    {
                                        /// Category = 2 and Subcategory = 7
                                        List<UniformDefaulter> uniformDefaulterList = Manageuniformdefaulter(disciplineList);
                                        inspectionDTO.uniformDefaulters = uniformDefaulterList;

                                        /// Category = 2 and Subcategory = 8
                                        List<LateComer> lateComerList = ManageLateComerDefaulter(disciplineList);
                                        inspectionDTO.lateComers = lateComerList;

                                        /// Category = 2 and Subcategory = 9
                                        List<IdDefaulter> idDefaulterList = ManageIdDefaulter(disciplineList);
                                        inspectionDTO.idDefaulters = idDefaulterList;

                                        /// Category = 2 and Subcategory = 10
                                        List<ShoeDefaulter> shoeDefaulterList = ManageShoeDefaulter(disciplineList);
                                        inspectionDTO.shoeDefaulters = shoeDefaulterList;
                                    }


                                }

                            }

                            return inspectionDTO;
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
        /// <param name="dtInspectiondDiscipline"></param>
        /// <returns></returns>
        private static List<Discipline> ManageDiscipline(DataTable dtInspectiondDiscipline)
        {
            List<Discipline> disciplineList = new List<Discipline>();

            foreach (DataRow dr in dtInspectiondDiscipline.Rows)
            {
                Discipline discipline = new Discipline();
                discipline.AdminssionNo = int.Parse(dr["AdmissionNo"].ToString());
                discipline.Student = dr["Student"].ToString();
                discipline.CourseId = int.Parse(dr["CourseId"].ToString());
                discipline.Class = dr["Class"].ToString();
                discipline.UniformId = int.Parse(dr["UniformId"].ToString());
                discipline.CategoryId = int.Parse(dr["CategoryId"].ToString());
                discipline.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                discipline.InspectionId = int.Parse(dr["InspectionId"].ToString());
                discipline.Category = dr["Category"].ToString();
                discipline.SubCategory = dr["Subcategory"].ToString();
                disciplineList.Add(discipline);
            }
            return disciplineList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtInspectionAsssembly"></param>
        /// <returns></returns>
        private Assembly ManageAssembly(DataTable dtInspectionAsssembly)
        {
            Assembly assembly = new Assembly();
            foreach (DataRow dr in dtInspectionAsssembly.Rows)
            {
                assembly.assemblyId = int.Parse(dr["ASSEMBLYSLNO"].ToString());
                assembly.startTime = dr["STARTTIME"].ToString();
                assembly.endTime = dr["ENDINGTIME"].ToString();
                assembly.flagStartTime = dr["FLAGSTARTTIME"].ToString();
                assembly.flagEndTime = dr["FLAGENDTIME"].ToString();
                assembly.delayInMinutes = int.Parse(dr["DELAYTIME"].ToString());
                assembly.foreCloserMinutes = int.Parse(dr["FORECLOSERTIME"].ToString());
                assembly.ekidzSong = bool.Parse(dr["EKIDZSONG"].ToString());
                assembly.warmUpSong = bool.Parse(dr["WARMUPSONG"].ToString());
                assembly.thoughtForTheDay = bool.Parse(dr["THOUGHTFORTHEDAY"].ToString());
            }
            return assembly;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disciplineList"></param>
        /// <returns></returns>
        private static List<ShoeDefaulter> ManageShoeDefaulter(List<Discipline> disciplineList)
        {
            var shoeDefaulterObject = disciplineList.Where(s => s.CategoryId == 2 && s.SubCategoryId == 10);
            List<ShoeDefaulter> shoeDefaulterList = new List<ShoeDefaulter>();
            foreach (var Defaulter in shoeDefaulterObject)
            {
                if (Defaulter != null)
                {
                    ShoeDefaulter shoeDefault = new ShoeDefaulter();
                    shoeDefault.admissionNo = Defaulter.AdminssionNo;
                    shoeDefault.CourseId = Defaulter.CourseId;
                    shoeDefault.Course = Defaulter.Class;
                    shoeDefault.Name = Defaulter.Student;
                    shoeDefaulterList.Add(shoeDefault);
                }
            }
            return shoeDefaulterList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disciplineList"></param>
        /// <returns></returns>
        private static List<IdDefaulter> ManageIdDefaulter(List<Discipline> disciplineList)
        {
            var idDefaulterObject = disciplineList.Where(s => s.CategoryId == 2 && s.SubCategoryId == 9);
            List<IdDefaulter> idDefaulterList = new List<IdDefaulter>();
            foreach (var Defaulter in idDefaulterObject)
            {
                if (Defaulter != null)
                {
                    IdDefaulter idDefaulter = new IdDefaulter();
                    idDefaulter.admissionNo = Defaulter.AdminssionNo;
                    idDefaulter.CourseId = Defaulter.CourseId;
                    idDefaulter.Course = Defaulter.Class;
                    idDefaulter.Name = Defaulter.Student;
                    idDefaulterList.Add(idDefaulter);
                }
            }
            return idDefaulterList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disciplineList"></param>
        /// <returns></returns>
        private static List<LateComer> ManageLateComerDefaulter(List<Discipline> disciplineList)
        {
            var lateComersobject = disciplineList.Where(s => s.CategoryId == 2 && s.SubCategoryId == 8);
            List<LateComer> lateComerList = new List<LateComer>();
            foreach (var Defaulter in lateComersobject)
            {
                if (Defaulter != null)
                {
                    LateComer lateComerDefault = new LateComer();
                    lateComerDefault.admissionNo = Defaulter.AdminssionNo;
                    lateComerDefault.CourseId = Defaulter.CourseId;
                    lateComerDefault.Course = Defaulter.Class;
                    lateComerDefault.Name = Defaulter.Student;
                    lateComerList.Add(lateComerDefault);
                }
            }
            return lateComerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disciplineList"></param>
        /// <returns></returns>
        private static List<UniformDefaulter> Manageuniformdefaulter(List<Discipline> disciplineList)
        {
            var uniformDefaulter = disciplineList.Where(s => s.CategoryId == 2 && s.SubCategoryId == 7);
            List<UniformDefaulter> uniformDefaulterList = new List<UniformDefaulter>();
            foreach (var Defaulter in uniformDefaulter)
            {
                if (Defaulter != null)
                {
                    UniformDefaulter uniformDefault = new UniformDefaulter();
                    uniformDefault.admissionNo = Defaulter.AdminssionNo;
                    uniformDefault.CourseId = Defaulter.CourseId;
                    uniformDefault.Course = Defaulter.Class;
                    uniformDefault.Name = Defaulter.Student;
                    uniformDefaulterList.Add(uniformDefault);
                }
            }
            return uniformDefaulterList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public Assembly InsertInspectionAssembly(Assembly assembly, int inspectionId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("INSPECTION_ASSEMBLY_DT_INSERT", con))
                    {
                        cmd.Parameters.Add("iASSEMBLYSLNO", OracleDbType.Int32).Value = assembly.assemblyId;
                        cmd.Parameters.Add("iINSPECTIONSLNO", OracleDbType.Int32).Value = inspectionId;
                        cmd.Parameters.Add("iSTARTTIME", OracleDbType.TimeStamp).Value = assembly.startTime;
                        cmd.Parameters.Add("iENDINGTIME", OracleDbType.TimeStamp).Value = assembly.endTime;
                        cmd.Parameters.Add("iFLAGSTARTTIME", OracleDbType.TimeStamp).Value = assembly.flagStartTime;
                        cmd.Parameters.Add("iFLAGENDTIME", OracleDbType.TimeStamp).Value = assembly.flagEndTime;
                        cmd.Parameters.Add("iDELAYTIME", OracleDbType.Int32).Value = assembly.delayInMinutes;
                        cmd.Parameters.Add("iFORECLOSERTIME", OracleDbType.Int32).Value = assembly.foreCloserMinutes;
                        cmd.Parameters.Add("iEKIDZSONG", OracleDbType.Blob).Value = assembly.ekidzSong;
                        cmd.Parameters.Add("iWARMUPSONG", OracleDbType.Blob).Value = assembly.warmUpSong;
                        cmd.Parameters.Add("iTHOUGHTFORTHEDAY", OracleDbType.Blob).Value = assembly.thoughtForTheDay;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    assembly.assemblyId = int.Parse(dr["ASSEMBLYSLNO"].ToString());
                                    assembly.startTime = dr["STARTTIME"].ToString();
                                    assembly.endTime = dr["ENDINGTIME"].ToString();
                                    assembly.flagStartTime = dr["FLAGSTARTTIME"].ToString();
                                    assembly.flagEndTime = dr["FLAGENDTIME"].ToString();
                                    assembly.delayInMinutes = int.Parse(dr["DELAYTIME"].ToString());
                                    assembly.foreCloserMinutes = int.Parse(dr["FORECLOSERTIME"].ToString());
                                    assembly.ekidzSong = bool.Parse(dr["EKIDZSONG"].ToString());
                                    assembly.warmUpSong = bool.Parse(dr["WARMUPSONG"].ToString());
                                    assembly.thoughtForTheDay = bool.Parse(dr["THOUGHTFORTHEDAY"].ToString());
                                }
                            }

                            return assembly;
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
        /// <param name="inspectionId"></param>
        /// <returns></returns>
        public Assembly GetInspectionAssembly(int inspectionId)
        {
            try
            {
                Assembly assembly = new Assembly();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_ASSEMBLY_DT", con))
                    {
                        cmd.Parameters.Add("iINSPECTIONSLNO", OracleDbType.Int32).Value = inspectionId;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    assembly.assemblyId = int.Parse(dr["ASSEMBLYSLNO"].ToString());
                                    assembly.startTime = dr["STARTTIME"].ToString();
                                    assembly.endTime = dr["ENDINGTIME"].ToString();
                                    assembly.flagStartTime = dr["FLAGSTARTTIME"].ToString();
                                    assembly.flagEndTime = dr["FLAGENDTIME"].ToString();
                                    assembly.delayInMinutes = int.Parse(dr["DELAYTIME"].ToString());
                                    assembly.foreCloserMinutes = int.Parse(dr["FORECLOSERTIME"].ToString());
                                    assembly.ekidzSong = bool.Parse(dr["EKIDZSONG"].ToString());
                                    assembly.warmUpSong = bool.Parse(dr["WARMUPSONG"].ToString());
                                    assembly.thoughtForTheDay = bool.Parse(dr["THOUGHTFORTHEDAY"].ToString());
                                }
                            }

                            return assembly;
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
        /// <param name="AdminissionNo"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public List<StudentNo> GetStudentInfo(int AdminissionNo, int branchId)
        {
            try
            {
                List<StudentNo> StudentList = new List<StudentNo>();
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_STUDENTINFO", con))
                    {
                        cmd.Parameters.Add("iADMISSION", OracleDbType.Int32).Value = AdminissionNo;
                        cmd.Parameters.Add("iBRANCH", OracleDbType.Int32).Value = branchId;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    StudentNo StudentNo = new StudentNo();
                                    StudentNo.AdminssionNo = int.Parse(dr["AdmissionNo"].ToString());
                                    StudentNo.Student = dr["Student"].ToString();
                                    StudentNo.CourseId = int.Parse(dr["CourseId"].ToString());
                                    StudentNo.Class = dr["Class"].ToString();
                                    StudentNo.Name = dr["Name"].ToString();
                                    StudentList.Add(StudentNo);
                                }
                            }
                        }
                    }
                }

                return StudentList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inspectionId"></param>
        /// <param name="categoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        public int InsertDiscipline(int inspectionId, int categoryId, int subCategoryId, int admissionId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("INSPECTION_UNIFORM_DT_INSERT", con))
                    {
                        cmd.Parameters.Add("iINSPECTIONSLNO", OracleDbType.Int32).Value = inspectionId;
                        cmd.Parameters.Add("iCATEGORYSLNO", OracleDbType.Int32).Value = categoryId;
                        cmd.Parameters.Add("iSUBCATEGORYSLNO", OracleDbType.TimeStamp).Value = subCategoryId;
                        cmd.Parameters.Add("iDEFAULTERSSLNO", OracleDbType.TimeStamp).Value = admissionId;
                        return cmd.ExecuteNonQuery();
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
        /// <param name="inspectionId"></param>
        /// <returns></returns>
        public List<Discipline> GetDisciplineByInspectionId(int inspectionId)
        {
            List<Discipline> disciplineList = new List<Discipline>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["OracleSchoolString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand("GET_INSPECTION_UNIFORM_DT", con))
                    {
                        cmd.Parameters.Add("iINSPECTIONSLNO", OracleDbType.Int32).Value = inspectionId;
                        cmd.Parameters.Add("DATACUR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {

                                    Discipline discipline = new Discipline();
                                    discipline.AdminssionNo = int.Parse(dr["AdmissionNo"].ToString());
                                    discipline.Student = dr["Student"].ToString();
                                    discipline.CourseId = int.Parse(dr["CourseId"].ToString());
                                    discipline.Class = dr["Class"].ToString();
                                    discipline.UniformId = int.Parse(dr["UniformId"].ToString());
                                    discipline.CategoryId = int.Parse(dr["CategoryId"].ToString());
                                    discipline.SubCategoryId = int.Parse(dr["SubCategoryId"].ToString());
                                    discipline.InspectionId = int.Parse(dr["InspectionId"].ToString());
                                    discipline.Category = dr["Category"].ToString();
                                    discipline.SubCategory = dr["Subcategory"].ToString();
                                    disciplineList.Add(discipline);
                                }
                            }
                        }
                        return disciplineList;
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
