using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class AppointmentRepository : BaseRepository
    {

        //insert



        public void AppointmentDetailInsertion(AppointmentViewModel appointmentViewModel)
        {

            AppointmentDetail appointmentDetail = new AppointmentDetail()
            {
                TokenNumber = appointmentViewModel.TokenNumber,
                FirstName = appointmentViewModel.FirstName,
                LastName = appointmentViewModel.LastName,
                Email = appointmentViewModel.Email,
                Address = appointmentViewModel.Address,
                Age = Convert.ToInt32(appointmentViewModel.Age),
                PhoneNumber = appointmentViewModel.PhoneNumber,
                ConsultingDoctor = appointmentViewModel.ConsultingDoctor,
                DateofAppointment = appointmentViewModel.DateofAppointment,
                Problem = appointmentViewModel.Problem,
                //DateofBirth = appointmentViewModel.DateofBirth,
                Gender = appointmentViewModel.Gender,
                TimeSlot = appointmentViewModel.TimeSlot,
                Department = appointmentViewModel.Department,

                IsActive = true,


            };

            dbcontext.AppointmentDetails.Add(appointmentDetail);
            dbcontext.SaveChanges();



        }
        //update
        public void AppointmentDetailUpdation(AppointmentViewModel appointmentViewModel)
        {

            var isAppointmentDetailExist = dbcontext.AppointmentDetails.Where(x => x.IsActive && x.TokenNumber == appointmentViewModel.TokenNumber).FirstOrDefault();
            if (isAppointmentDetailExist != null)
            {

                isAppointmentDetailExist.TokenNumber = appointmentViewModel.TokenNumber;
                isAppointmentDetailExist.FirstName = appointmentViewModel.FirstName;
                isAppointmentDetailExist.LastName = appointmentViewModel.LastName;
                isAppointmentDetailExist.Email = appointmentViewModel.Email;
                isAppointmentDetailExist.Address = appointmentViewModel.Address;
                isAppointmentDetailExist.Age = Convert.ToInt32(appointmentViewModel.Age);
                isAppointmentDetailExist.PhoneNumber = appointmentViewModel.PhoneNumber;
                isAppointmentDetailExist.ConsultingDoctor = appointmentViewModel.ConsultingDoctor;
                isAppointmentDetailExist.DateofAppointment = appointmentViewModel.DateofAppointment;
                isAppointmentDetailExist.Problem = appointmentViewModel.Problem;
                //isAppointmentDetailExist.DateofBirth = appointmentViewModel.DateofBirth;
                isAppointmentDetailExist.Gender = appointmentViewModel.Gender;
                isAppointmentDetailExist.TimeSlot = appointmentViewModel.TimeSlot;
                isAppointmentDetailExist.Department = appointmentViewModel.Department;

                isAppointmentDetailExist.IsActive = true;

                dbcontext.Entry(isAppointmentDetailExist);
                dbcontext.SaveChanges();

            }
        }

        //select

        public JQGridResponse<AppointmentViewModel> GetAppointmentList(JQGridSort jQGridSort)
        {
            IQueryable<AppointmentViewModel> list = GetAppointmentListQuery();
            var predicate = JQGridSorting.GeneratePredicate<AppointmentViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<AppointmentViewModel> GetAppointmentListQuery()
        {
            var result = dbcontext.AppointmentDetails.Where(x => x.IsActive).Select(s => new AppointmentViewModel()
            {
                TokenNumber = s.TokenNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                Age = s.Age.ToString(),
                DateofAppointment = s.DateofAppointment,
                //DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                ConsultingDoctor = s.ConsultingDoctor,
                TimeSlotDesc = dbcontext.Master_TimeSlot.Where(x => x.TimeSlotId == s.TimeSlot).Select(b => b.Description).FirstOrDefault(),
                TimeSlot = s.TimeSlot,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,

                IsActive = s.IsActive,

            }).ToList();
            result.ForEach(x => x.EncryptTokenNumber = Cryptography.EncryptStringToBytes_Aes(x.TokenNumber.ToString()));

            return result.AsQueryable();
        }

        public AppointmentViewModel GetAppointmentByAppointmentDetailId(int tokenNumber)
        {
            var result = dbcontext.AppointmentDetails.Where(x => x.IsActive && x.TokenNumber == tokenNumber).Select(s => new AppointmentViewModel()
            {
                TokenNumber = s.TokenNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
               Gender = s.Gender,
                Age = s.Age.ToString(),
                DateofAppointment = s.DateofAppointment,
                //DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                ConsultingDoctor = s.ConsultingDoctor,
                TimeSlotDesc = dbcontext.Master_TimeSlot.Where(x => x.TimeSlotId == s.TimeSlot).Select(b => b.Description).FirstOrDefault(),
                TimeSlot = s.TimeSlot,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,

                IsActive = s.IsActive,

            }).FirstOrDefault();

            return result;
        }

        //delete
        public void AppointmentDeletion(int tokenNumber)
        {
            var appointmentdetail = dbcontext.AppointmentDetails.Where(x => x.IsActive && x.TokenNumber == tokenNumber).FirstOrDefault();
            if (appointmentdetail != null)
            {
                appointmentdetail.IsActive = false;
                dbcontext.Entry(appointmentdetail);
                dbcontext.SaveChanges();
            }


        }


        //icon


        public AppointmentViewModel GetAppointmentDetail(int tokenNumber)
        {
            var result = dbcontext.AppointmentDetails.Where(x => x.IsActive && x.TokenNumber == tokenNumber).Select(s => new AppointmentViewModel()
            {
                TokenNumber = s.TokenNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                Age = s.Age.ToString(),
                DateofAppointment = s.DateofAppointment,
                //DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                ConsultingDoctor = s.ConsultingDoctor,
                TimeSlotDesc = dbcontext.Master_TimeSlot.Where(x => x.TimeSlotId == s.TimeSlot).Select(b => b.Description).FirstOrDefault(),
                TimeSlot = s.TimeSlot,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,

                IsActive = s.IsActive,

            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }
    }
}