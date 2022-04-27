
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterHospitalRepository : BaseRepository
    {
        public List<Master_Hospital> GetHospitalNameList()
        {
            var hospitalnamelist = dbcontext.Master_Hospital.Where(x => x.IsActive).ToList();
            return hospitalnamelist;

        }
    }
}