using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class RegistrationRepository
    {
        #region Get Users
        public List<UserCount> GetUsers(DataContext context)
        {
            List<UserCount> objUsers = new List<UserCount>();
            try
            {
                objUsers = context.UserCount.FromSqlRaw("exec df_Get_UsersCount").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return objUsers;
        }
        #endregion

        #region Insert User
        public List<Users> InsertUser(DataContext context, Users user)
        {
            List<Users> users = new List<Users>();
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                users.Add(user);
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }
        #endregion

        #region Update User Role
        public long UpdateUserRole(DataContext context, Users user)
        {
            long rowsAffected = 0;
            try
            {
                Users userToUpdate = context.Users.Where(u => u.UserID == user.UserID).First();
                userToUpdate.RoleID = user.RoleID;
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Login User
        public List<LoginUser> LoginUser(DataContext context, Users users)
        {
            List<LoginUser> objUsers = new List<LoginUser>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@Username", Value = users.Username },
                    new SqlParameter { ParameterName = "@Password", Value = users.Password },
                };
                objUsers = context.LoginUser.FromSqlRaw("exec df_Get_LoginAdminUser @Username, @Password", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return objUsers;
        }
        #endregion

        #region Update User
        public long UpdateUser(DataContext context, Users user)
        {
            long rowsAffected = 0;
            try
            {
                context.Users.Update(user);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Update User Password
        public long UpdateUserPassword(DataContext context, Users user)
        {
            long rowsAffected = 0;
            try
            {
                Users userToUpdate = context.Users.Where(u => u.PhoneNumber == user.PhoneNumber).First();
                userToUpdate.Password = user.Password;
                userToUpdate.OTP = user.OTP;
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion
    }
}
