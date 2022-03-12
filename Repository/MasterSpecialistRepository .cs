using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterSpecialistRepository : BaseRepository
    {

        public List<Master_Specialist> GetSpecialistlist()
        {
            var specialistlist = dbcontext.Master_Specialist.Where(x => x.IsActive).ToList();
            return specialistlist;
        }



    }
}
