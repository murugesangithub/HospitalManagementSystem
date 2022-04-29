
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterDesignationRepository : BaseRepository
    {
        public List<Master_Designation> GetDesignationList()
        {
            
            var designationlist = dbcontext.Master_Designation.Where(x => x.IsActive).ToList();
            return designationlist;
        }

    }
}