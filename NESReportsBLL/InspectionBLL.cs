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

        public List<InspectionCategory> GetInspectionCategory(int ReportId)
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

        public List<InspectionSubCategory> GetInspectionSubCategory(int ReportId, int categoryId)
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
    }
}
