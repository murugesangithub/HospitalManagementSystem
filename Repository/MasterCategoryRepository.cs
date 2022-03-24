
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterCategoryRepository : BaseRepository
    {
        public List<Master_Category> GetCategoryList()
        {
            var categorylist = dbcontext.Master_Category.Where(x => x.IsActive).ToList();
            return categorylist;
        }
       
    }
}