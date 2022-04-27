
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MasterRoomTypeRepository : BaseRepository
    {
        public List<Master_RoomType> GetRoomTypeList()
        {
            var roomTypelist = dbcontext.Master_RoomType.Where(x => x.IsActive).ToList();
            return roomTypelist;
        }
       
    }
}