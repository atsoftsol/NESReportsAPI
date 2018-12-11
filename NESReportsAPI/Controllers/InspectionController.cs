using NESReportsBLL;
using NESReportsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NESReportsAPI.Controllers
{
    [RoutePrefix("api/inspection")]
    public class InspectionController : ApiController
    {
        InspectionBLL inspectionBLL = new InspectionBLL();

        /// <summary>
        /// Get Inspection
        /// </summary>
        /// <returns></returns>
        [Route("inspectiontype")]
        public IHttpActionResult GetInspectionType()
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionType());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Inspection By Category
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("inspectionCategory")]
        public IHttpActionResult GetInspectionCategory(string reporttype)
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionCategory(reporttype));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Inspection By SubCategory
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("inspectionsubcategory")]
        public IHttpActionResult GetInspectionSubCategory(string reporttype, string category)
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionSubCategory(reporttype, category));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Inspection By Segment
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        [Route("inspectionsegment")]
        public IHttpActionResult GetInspectionSegment()
        {
            try
            {
                return Ok(inspectionBLL.GetInspectionSegment());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inSpection"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertInspection")]
        public IHttpActionResult InsertInspection(InspectionHeader inSpection)
        {
            try
            {
                return Ok(inspectionBLL.InsertInspectionSegment(inSpection));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="inspectionId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insertinspectionassembly")]
        public IHttpActionResult InsertInspectionAssembly(Assembly assembly, int inspectionId)
        {
            try
            {
                return Ok(inspectionBLL.InsertInspectionAssembly(assembly, inspectionId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdminissionNo"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        [Route("studentInfo")]
        public IHttpActionResult GetStudentInfo(int AdminissionNo, int branchId)
        {
            try
            {
                return Ok(inspectionBLL.GetStudentInfo(AdminissionNo, branchId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
        [Route("insertdiscipline")]
        public IHttpActionResult InsertDiscipline(int inspectionId, int categoryId, int subCategoryId, int admissionId)
        {
            try
            {
                return Ok(inspectionBLL.InsertDiscipline(inspectionId, categoryId, subCategoryId, admissionId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inspectionId"></param>
        /// <returns></returns>
        [Route("discipline")]
        public IHttpActionResult GetDisciplineByInspectionId(int inspectionId)
        {
            try
            {
                return Ok(inspectionBLL.GetDisciplineByInspectionId(inspectionId));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
