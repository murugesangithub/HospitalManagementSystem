using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class LoggingRepository : BaseRepository
    {


        public void ErrorLogInsertion(ErrorLogViewModel errorLogViewModel)
        {

            ErrorLog errorLog = new ErrorLog()
            {
                Subject = errorLogViewModel.Subject,
                Description = errorLogViewModel.Description,
                IPAddress = errorLogViewModel.IPAddress,

            };
            dbcontext.ErrorLogs.Add(errorLog);
            dbcontext.SaveChanges();



        }
    }
}