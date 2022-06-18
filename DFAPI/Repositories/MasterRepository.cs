using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class MasterRepository
    {
        #region Activity Roles
        public List<ActivityMaster> GetActivityRoles(DataContext context)
        {
            List<ActivityMaster> activityMaster = new List<ActivityMaster>();
            try
            {
                activityMaster = context.ActivityMaster.ToList();
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
                context.ActivityMaster.Add(activityMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateActivityRoles(DataContext context, ActivityMaster activityMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.ActivityMaster.Update(activityMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteActivityRoles(DataContext context, ActivityMaster activityMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.ActivityMaster.Remove(activityMaster);
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

        #region Services
        public List<ServiceMaster> GetServices(DataContext context)
        {
            List<ServiceMaster> serviceMaster = new List<ServiceMaster>();
            try
            {
                serviceMaster = context.ServiceMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return serviceMaster;
        }

        public long InsertServices(DataContext context, ServiceMaster serviceMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.ServiceMaster.Add(serviceMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateServices(DataContext context, ServiceMaster serviceMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.ServiceMaster.Update(serviceMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteServices(DataContext context, ServiceMaster serviceMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.ServiceMaster.Remove(serviceMaster);
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

        #region Unit Of Sales
        public List<UnitOfSalesMaster> GetUnitOfSales(DataContext context)
        {
            List<UnitOfSalesMaster> unitOfSalesMaster = new List<UnitOfSalesMaster>();
            try
            {
                unitOfSalesMaster = context.UnitOfSalesMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitOfSalesMaster;
        }

        public long InsertUnitOfSales(DataContext context, UnitOfSalesMaster unitOfSalesMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.UnitOfSalesMaster.Add(unitOfSalesMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUnitOfSales(DataContext context, UnitOfSalesMaster unitOfSalesMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.UnitOfSalesMaster.Update(unitOfSalesMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteUnitOfSales(DataContext context, UnitOfSalesMaster unitOfSalesMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.UnitOfSalesMaster.Remove(unitOfSalesMaster);
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

        #region Category
        public List<CategoryMaster> GetCategories(DataContext context)
        {
            List<CategoryMaster> categoryMasters = new List<CategoryMaster>();
            try
            {
                categoryMasters = context.CategoryMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return categoryMasters;
        }

        public long InsertCategory(DataContext context, CategoryMaster categoryMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    new SqlParameter { ParameterName = "@CategoryName", Value = categoryMaster.CategoryName },
                    new SqlParameter { ParameterName = "@RoleID", Value = categoryMaster.RoleID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = categoryMaster.ServiceID },
                    new SqlParameter { ParameterName = "@HSNSACCode", Value = categoryMaster.HSNSACCode },
                    new SqlParameter { ParameterName = "@GSTRate", Value = categoryMaster.GSTRate },
                    new SqlParameter { ParameterName = "@Display", Value = categoryMaster.Display },
                    new SqlParameter { ParameterName = "@UnitID", Value = categoryMaster.UnitID }
                };
                context.CategoryMaster.FromSqlRaw("exec df_Insert_Category @CategoryName, @RoleID, @ServiceID, @HSNSACCode, @GSTRate, @Display, @UnitID", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateCategory(DataContext context, CategoryMaster categoryMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = categoryMaster.ID },
                    new SqlParameter { ParameterName = "@CategoryName", Value = categoryMaster.CategoryName },
                    new SqlParameter { ParameterName = "@RoleID", Value = categoryMaster.RoleID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = categoryMaster.ServiceID },
                    new SqlParameter { ParameterName = "@HSNSACCode", Value = categoryMaster.HSNSACCode },
                    new SqlParameter { ParameterName = "@GSTRate", Value = categoryMaster.GSTRate },
                    new SqlParameter { ParameterName = "@Display", Value = categoryMaster.Display },
                    new SqlParameter { ParameterName = "@UnitID", Value = categoryMaster.UnitID }
                };
                context.CategoryMaster.FromSqlRaw("exec df_Update_Category @ID, @CategoryName, @RoleID, @ServiceID, @HSNSACCode, @GSTRate, @Display, @UnitID", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteCategory(DataContext context, CategoryMaster categoryMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.CategoryMaster.Remove(categoryMaster);
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
