
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterDepartmentRepository : BaseRepository
    {
        public List<Master_Department> GetDepartmentList()
        {
            var departmentlist = dbcontext.Master_Department.Where(x => x.IsActive).ToList();
            return departmentlist;
        }
       
    }
}