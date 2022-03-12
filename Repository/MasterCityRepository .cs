using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterCityRepository : BaseRepository
    {
        

        public List<Master_City> GetCitylist()
        {
           var citylist = dbcontext.Master_City.Where(x => x.IsActive).ToList();
            return citylist;

        }
        

       
    }
}