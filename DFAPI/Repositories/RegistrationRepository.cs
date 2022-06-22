using DFAPI.Entities;
using DFAPI.Helpers;

namespace DFAPI.Repositories
{
    public class RegistrationRepository
    {
        #region Insert User
        public long InsertUser(DataContext context, Users user)
        {
            long rowsAffected = 0;
            try
            {
                context.Users.Add(user);
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
        public List<Users> LoginUser(DataContext context, Users users)
        {
            List <Users> objUsers=new List<Users> ();
            try
            {
                objUsers = context.Users.Where(u => u.PhoneNumber == users.PhoneNumber && u.Password == users.Password).ToList();
            }catch (Exception)
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
    }
}
