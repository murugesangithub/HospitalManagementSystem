
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterCountryRepository : BaseRepository
    {
        public List<Master_Country> GetCountryList()
        {
            var countrylist = dbcontext.Master_Country.Where(x => x.IsActive).ToList();
            return countrylist;
        }
       
    }
}