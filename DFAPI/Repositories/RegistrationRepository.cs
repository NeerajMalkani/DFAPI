using DFAPI.Entities;
using DFAPI.Helpers;
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

        #region Login User
        public List<Users> LoginUser(DataContext context, Users users)
        {
            List<Users> objUsers = new List<Users>();
            try
            {
                if (users.RoleID == 1)
                {
                    objUsers = context.Users.Where(u => (u.Username == users.Username && u.Password == users.Password)).ToList();
                }
                else
                {
                    objUsers = context.Users.Where(u => (u.PhoneNumber == users.PhoneNumber && u.Password == users.Password)).ToList();
                }

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
