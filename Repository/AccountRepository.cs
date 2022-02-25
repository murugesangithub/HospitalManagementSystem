using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class AccountRepository : BaseRepository
    {
        public RegisterViewModel LogOn(string email, string password)
        {
            password = Cryptography.EncryptStringToBytes_Aes(password);
            return dbcontext.UserDetails.Where(x => x.IsActive && x.Email == email && x.Password == password).Select(s => new RegisterViewModel()
            {
                UserDetailId = s.UserDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                //Password = s.Password,
                Role = s.Role,
                RoleDesc = dbcontext.Roles.Where(x => x.RoleId == s.Role).Select(b => b.Description).FirstOrDefault(),
                ProfileImage = s.ProfileImage ?? string.Empty,
                IsActive = s.IsActive,

            }).FirstOrDefault();

        }

        public IQueryable<Role> GetRoleQuery()
        {
            return dbcontext.Roles.Where(x => x.IsActive);

        }
        public JQGridResponse<RegisterViewModel> GetUserList(JQGridSort jQGridSort)
        {
            IQueryable<RegisterViewModel> list = GetUserQuery();
            var predicate = JQGridSorting.GeneratePredicate<RegisterViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<RegisterViewModel> GetUserQuery()
        {
            var result = dbcontext.UserDetails.Where(x => x.IsActive).Select(s => new RegisterViewModel()
            {
                UserDetailId = s.UserDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                //Password = s.Password,
                Role = s.Role,
                RoleDesc = dbcontext.Roles.Where(x => x.RoleId == s.Role).Select(b => b.Description).FirstOrDefault(),
                ProfileImage = s.ProfileImage ?? string.Empty,
                IsActive = s.IsActive,

            }).ToList();
            result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result.AsQueryable();
        }

        public bool IsUserExistforInsert(string email)
        {
            return dbcontext.UserDetails.Where(x => x.IsActive && x.Email == email).Any();
        }
        public bool IsUserExistforUpdate(int userId, string email)
        {
            return dbcontext.UserDetails.Where(x => x.IsActive && x.UserDetailId != userId && x.Email == email).Any();
        }

        public void UserDetailInsertion(RegisterViewModel registerViewModel)
        {
            var passwordEncrypted = Cryptography.EncryptStringToBytes_Aes(registerViewModel.Password);
            UserDetail userDetail = new UserDetail()
            {
                UserDetailId = registerViewModel.UserDetailId,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = passwordEncrypted,
                Role = registerViewModel.Role,

                IsActive = true,
            };
            if (registerViewModel.ProfileImage.Length > 0)
            {
                userDetail.ProfileImage = registerViewModel.ProfileImage;
            }
            dbcontext.UserDetails.Add(userDetail);
            dbcontext.SaveChanges();



        }


        public void UserDetailUpdation(RegisterViewModel registerViewModel)
        {

            var userDetail = dbcontext.UserDetails.Where(x => x.IsActive && x.UserDetailId == registerViewModel.UserDetailId).FirstOrDefault();
            if (userDetail != null)
            {

                userDetail.FirstName = registerViewModel.FirstName;
                userDetail.LastName = registerViewModel.LastName;
                if (!string.IsNullOrEmpty(registerViewModel.Email))
                {
                    userDetail.Email = registerViewModel.Email;
                }

                if (!string.IsNullOrEmpty(registerViewModel.Password))
                {
                    var passwordEncrypted = Cryptography.EncryptStringToBytes_Aes(registerViewModel.Password);
                    userDetail.Password = passwordEncrypted;
                }
                if (registerViewModel.Role != default(int))
                {
                    userDetail.Role = registerViewModel.Role;
                }

                if (registerViewModel.ProfileImage.Length > 0)
                {
                    userDetail.ProfileImage = registerViewModel.ProfileImage;
                }

                dbcontext.Entry(userDetail);
                dbcontext.SaveChanges();
            }


        }

        public void UpdatePassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userDetail = dbcontext.UserDetails.Where(x => x.IsActive && x.UserDetailId == resetPasswordViewModel.UserDetailId).FirstOrDefault();
            if (userDetail != null)
            {
                if (!string.IsNullOrEmpty(resetPasswordViewModel.Password))
                {
                    var passwordEncrypted = Cryptography.EncryptStringToBytes_Aes(resetPasswordViewModel.Password);
                    userDetail.Password = passwordEncrypted;
                }
                dbcontext.Entry(userDetail);
                dbcontext.SaveChanges();
            }

        }


        public RegisterViewModel GetUserByUserDetailId(int userDetailId)
        {
            return dbcontext.UserDetails.Where(x => x.IsActive && x.UserDetailId == userDetailId).Select(s => new RegisterViewModel()
            {
                UserDetailId = s.UserDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                //Password = s.Password,
                Role = s.Role,
                RoleDesc = dbcontext.Roles.Where(x => x.RoleId == s.Role).Select(b => b.Description).FirstOrDefault(),
                ProfileImage = s.ProfileImage ?? string.Empty,
                IsActive = s.IsActive,

            }).FirstOrDefault() ?? new RegisterViewModel();
        }

        public void UserDeletion(int userDetailId)
        {
            var userdetail = dbcontext.UserDetails.Where(x => x.IsActive && x.UserDetailId == userDetailId).FirstOrDefault();
            if (userdetail != null)
            {
                userdetail.IsActive = false;
                dbcontext.Entry(userdetail);
                dbcontext.SaveChanges();
            }


        }
    }
}