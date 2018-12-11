using NESReportsDAL;
using NESReportsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsBLL
{
    public class InspectionBLL
    {
        InspectionDAL inspectionDAL = new InspectionDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<InspectionType> GetInspectionType()
        {
            try
            {
                return inspectionDAL.GetInspectionType();
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
        /// <returns></returns>
        public List<InspectionCategory> GetInspectionCategory(string ReportId)
        {
            try
            {
                return inspectionDAL.GetInspectionCategory(ReportId);
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
                return inspectionDAL.GetInspectionSubCategory(ReportId, categoryId);
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
        public List<InspectionSegment> GetInspectionSegment()
        {
            try
            {
                return inspectionDAL.GetInspectionSegment();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inSpection"></param>
        /// <returns></returns>
        public InspectionDTO InsertInspectionSegment(InspectionHeader inSpection)
        {
            try
            {
                return inspectionDAL.InsertInspectionSegment(inSpection);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="inspectionId"></param>
        /// <returns></returns>
        public Assembly InsertInspectionAssembly(Assembly assembly, int inspectionId)
        {
            try
            {
                return inspectionDAL.InsertInspectionAssembly(assembly, inspectionId);
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
                return inspectionDAL.GetStudentInfo(AdminissionNo, branchId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertDiscipline(int inspectionId, int categoryId, int subCategoryId, int admissionId)
        {
            try
            {
                return inspectionDAL.InsertDiscipline(inspectionId, categoryId, subCategoryId, admissionId);
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
            try
            {
                return inspectionDAL.GetDisciplineByInspectionId(inspectionId);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
