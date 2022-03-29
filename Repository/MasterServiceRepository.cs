
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterServiceRepository : BaseRepository
    {
        public List<Master_Service> GetServiceList()
        {
            var servicelist = dbcontext.Master_Service.Where(x => x.IsActive).ToList();
            return servicelist;

        }
    }
}