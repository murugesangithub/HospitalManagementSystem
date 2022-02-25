using HospitalManagementSystem.Entity;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class BaseRepository
    {
        public HMSEntities dbcontext;
        public BaseRepository()
        {
            dbcontext = new HMSEntities();
        }

    }
}
