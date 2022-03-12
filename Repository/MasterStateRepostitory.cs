using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterStateRepository : BaseRepository
    {


        public List<Master_State> GetStatelist()
        {
            var statelist = dbcontext.Master_State.Where(x => x.IsActive).ToList();
            return statelist;

        }



    }
}