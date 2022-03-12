
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterTimeSlotRepository : BaseRepository
    {
        public List<Master_TimeSlot> GetTimeSlotList()
        {
            var timeslotlist = dbcontext.Master_TimeSlot.Where(x => x.IsActive).ToList();
            return timeslotlist;
        }
       
    }
}