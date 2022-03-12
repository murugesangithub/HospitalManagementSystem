
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterMaritalStatusRepository : BaseRepository
    {
        public List<Master_MaritalStatus> GetMaritalStatusList()
        {
            var maritalstatuslist = dbcontext.Master_MaritalStatus.Where(x => x.IsActive).ToList();
            return maritalstatuslist;
        }


    }
}