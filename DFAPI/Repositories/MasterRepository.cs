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
        public List<ActivityMaster> GetActivityRoles(DataContext context)
        {
            List<ActivityMaster> activityMaster = new List<ActivityMaster>();
            try
            {
                activityMaster = context.ActivityMaster.FromSqlRaw("exec df_Get_ActivityRoles").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return activityMaster;
        }

        public long InsertActivityRoles(DataContext context, ActivityMaster activityMaster)
        {
            long rowsAffected = 0;
            try
            {
                if (activityMaster.ActivityRoleName != null)
                {
                    context.ActivityMaster.Add(activityMaster);
                    context.SaveChanges();
                    rowsAffected = activityMaster.RoleID;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Services
        /// <summary>
        /// Call the database to get Services
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<ServiceMaster> GetServices(DataContext context)
        {
            List<ServiceMaster> serviceMaster = new List<ServiceMaster>();
            try
            {
                serviceMaster = context.Services.FromSqlRaw("exec df_Get_Services").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return serviceMaster;
        }
        #endregion

        #region Unit Of Sales
        /// <summary>
        /// Call the database to get Unit Of Sales
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<UnitOfSalesMaster> GetUnitOfSales(DataContext context)
        {
            List<UnitOfSalesMaster> unitOfSalesMaster = new List<UnitOfSalesMaster>();
            try
            {
                unitOfSalesMaster = context.UnitOfSales.FromSqlRaw("exec df_Get_UnitOfSales").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitOfSalesMaster;
        }
        #endregion
    }
}
