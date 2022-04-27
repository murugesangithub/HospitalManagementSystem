
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterRoomNumberRepository : BaseRepository
    {
        public List<Master_RoomNumber> GetRoomNumberList()
        {
            var roomNumberlist = dbcontext.Master_RoomNumber.Where(x => x.IsActive).ToList();
            return roomNumberlist;
        }
       
    }
}