
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterPaymentStatusRepository : BaseRepository
    {
        public List<Master_PaymentStatus> GetPaymentStatusList()
        {
            var paymentstatuslist = dbcontext.Master_PaymentStatus.Where(x => x.IsActive).ToList();
            return paymentstatuslist;

        }

    }
}