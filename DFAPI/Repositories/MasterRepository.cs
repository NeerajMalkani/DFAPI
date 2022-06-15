using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class MasterRepository
    {
        #region Activity Roles
        /// <summary>
        /// Call the database to get Activity Roles
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<ActivityRoles> GetActivityRoles(DataContext context)
        {
            List<ActivityRoles> activityRoles = new List<ActivityRoles>();
            try
            {
                activityRoles = context.ActivityRoles.FromSqlRaw("exec df_Get_ActivityRoles").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return activityRoles;
        }
        #endregion

        #region Services
        /// <summary>
        /// Call the database to get Services
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<Services> GetServices(DataContext context)
        {
            List<Services> services = new List<Services>();
            try
            {
                services = context.Services.FromSqlRaw("exec df_Get_ActivityRoles").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return services;
        }
        #endregion

        #region Unit Of Sales
        /// <summary>
        /// Call the database to get Unit Of Sales
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<Services> GetUnitOfSales(DataContext context)
        {
            List<Services> services = new List<Services>();
            try
            {
                services = context.Services.FromSqlRaw("exec df_Get_UnitOfSales").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return services;
        }
        #endregion
    }
}
