
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterGenderRepository : BaseRepository
    {
        public List<Master_Gender> GetGenderList()
        {
            var genderlist = dbcontext.Master_Gender.Where(x => x.IsActive).ToList();
            return genderlist;
        }
       
    }
}