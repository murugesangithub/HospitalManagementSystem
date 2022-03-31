
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterMedicineRepository : BaseRepository
    {
        public List<Master_Medicine> GetMedicineList()
        {
            var medicinelist = dbcontext.Master_Medicine.Where(x => x.IsActive).ToList();
            return medicinelist;
        }
       
    }
}