
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterPaymentRepository : BaseRepository
    {
        public List<Master_Payment> GetPaymentList()
        {
            var paymentlist = dbcontext.Master_Payment.Where(x => x.IsActive).ToList();
            return paymentlist;
        }
       
    }
}