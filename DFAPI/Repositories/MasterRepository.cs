using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                activityMaster = context.ActivityMaster.OrderByDescending(b => b.ID).ToList();
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
                serviceMaster = context.ServiceMaster.OrderByDescending(b => b.ID).ToList();
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
                //unitOfSalesMaster = context.UnitOfSalesMaster.ToList();
                unitOfSalesMaster = context.UnitOfSalesMaster.FromSqlRaw("exec df_Get_Units").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitOfSalesMaster;
        }

        public List<UnitOfSalesMaster> GetUnitOfSalesByID(DataContext context, UnitOfSalesMaster unitOfSales)
        {
            List<UnitOfSalesMaster> unitOfSalesMaster = new List<UnitOfSalesMaster>();
            try
            {
                unitOfSalesMaster = context.UnitOfSalesMaster.Where((el) => el.ID == unitOfSales.ID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitOfSalesMaster;
        }

        public long InsertUpdateUnitOfSales(DataContext context, UnitOfSalesMaster unitOfSalesMaster)
        {
            long rowsAffected = 0;
            try
            {
                //context.UnitOfSalesMaster.Add(unitOfSalesMaster);
                //context.SaveChanges();
                //rowsAffected = 1;

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@Unit1Name", Value = unitOfSalesMaster.Unit1Name },
                    new SqlParameter { ParameterName = "@Unit2Name", Value = unitOfSalesMaster.Unit2Name },
                     new SqlParameter { ParameterName = "@Display", Value = unitOfSalesMaster.Display },
                    new SqlParameter { ParameterName = "@ID", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.BigInt }
                };
                context.Database.ExecuteSqlRaw("exec df_insertUpdate_Unit @Unit1Name, @Unit2Name, @Display, @ID out", parms.ToArray());
                rowsAffected = Convert.ToInt32(parms[3].Value);
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        //public long UpdateUnitOfSales(DataContext context, UnitOfSalesMaster unitOfSalesMaster)
        //{
        //    long rowsAffected = 0;
        //    try
        //    {
        //        context.UnitOfSalesMaster.Update(unitOfSalesMaster);
        //        context.SaveChanges();
        //        rowsAffected = 1;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return rowsAffected;
        //}

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
                categoryMasters = context.CategoryMaster.FromSqlRaw("exec df_Get_Categories").ToList();
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
                    new SqlParameter { ParameterName = "@UnitID", Value = categoryMaster.UnitID },
                    new SqlParameter { ParameterName = "@ID", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.BigInt }
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_Category @CategoryName, @RoleID, @ServiceID, @HSNSACCode, @GSTRate, @Display, @UnitID, @ID out", parms.ToArray());
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
                context.Database.ExecuteSqlRaw("exec df_Update_Category @ID, @CategoryName, @RoleID, @ServiceID, @HSNSACCode, @GSTRate, @Display, @UnitID", parms.ToArray());
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

        #region Product
        public List<Products> GetProducts(DataContext context)
        {
            List<Products> products = new List<Products>();
            try
            {
                products = context.Products.FromSqlRaw("exec df_Get_Products").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public List<Products> GetServiceProducts(DataContext context)
        {
            List<Products> products = new List<Products>();
            try
            {
                products = context.Products.FromSqlRaw("exec df_Get_ServiceProducts").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public List<ActivityMaster> GetMainActivities(DataContext context)
        {
            List<ActivityMaster> mainActivities = new List<ActivityMaster>();
            try
            {
                mainActivities = context.ActivityMaster.FromSqlRaw("exec df_Get_MainActivities").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return mainActivities;
        }

        public List<ServiceMaster> GetServicesByRoleID(DataContext context, ActivityMaster activityMaster)
        {
            List<ServiceMaster> servicesByRoleID = new List<ServiceMaster>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ActivityRoleID", Value = activityMaster.ID }
                };
                servicesByRoleID = context.ServiceMaster.FromSqlRaw("exec df_Get_ServicesByRoleID @ActivityRoleID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return servicesByRoleID;
        }

        public List<CategoryByService> GetCategoriesByServiceID(DataContext context, Products products)
        {
            List<CategoryByService> categoriesByServiceID = new List<CategoryByService>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ActivityID", Value = products.ActivityID },
                new SqlParameter { ParameterName = "@ServiceID", Value = products.ServiceID }
                };
                categoriesByServiceID = context.CategoryByService.FromSqlRaw("exec df_Get_CategoriesByServiceID @ActivityID, @ServiceID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return categoriesByServiceID;
        }

        public List<UnitOfSalesMaster> GetUnitByCategoryID(DataContext context, CategoryMaster categoryMaster)
        {
            List<UnitOfSalesMaster> unitByCategoryID = new List<UnitOfSalesMaster>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@CategoryID", Value = categoryMaster.ID }
                };
                unitByCategoryID = context.UnitOfSalesMaster.FromSqlRaw("exec df_Get_UnitByCategoryID @CategoryID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitByCategoryID;
        }

        public List<ProductsByCategory> GetProductsByCategoryID(DataContext context, Products products)
        {
            List<ProductsByCategory> productByCategoryID = new List<ProductsByCategory>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ActivityID", Value = products.ActivityID },
                new SqlParameter { ParameterName = "@ServiceID", Value = products.ServiceID },
                new SqlParameter { ParameterName = "@CategoryID", Value = products.CategoryID }
                };
                productByCategoryID = context.ProductsByCategory.FromSqlRaw("exec df_Get_ProductsByCategoryID @ActivityID, @ServiceID, @CategoryID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return productByCategoryID;
        }

        public List<UnitOfSalesMaster> GetUnitByProductID(DataContext context, ProductMaster productMaster)
        {
            List<UnitOfSalesMaster> unitByProductID = new List<UnitOfSalesMaster>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ProductID", Value = productMaster.ProductID }
                };
                unitByProductID = context.UnitOfSalesMaster.FromSqlRaw("exec df_Get_UnitByProductID @ProductID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitByProductID;
        }

        public long InsertProduct(DataContext context, ProductMaster productMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ProductName", Value = productMaster.ProductName },
                    new SqlParameter { ParameterName = "@ActivityID", Value = productMaster.ActivityID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = productMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = productMaster.CategoryID },
                    new SqlParameter { ParameterName = "@UnitOfSalesID", Value = productMaster.UnitOfSalesID },
                    new SqlParameter { ParameterName = "@Display", Value = productMaster.Display },
                    new SqlParameter { ParameterName = "@ID", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.BigInt }
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_Product @ProductName, @ActivityID, @ServiceID, @CategoryID, @UnitOfSalesID, @Display", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateProducts(DataContext context, ProductMaster productMaster)
        {
            long rowsAffected = 0;
            try
            {
                ProductMaster currProduct = context.ProductMaster.Where(x => x.ProductID == productMaster.ProductID).First();
                if (currProduct != null)
                {
                    if (productMaster.ActivityID != null)
                    {
                        currProduct.ActivityID = productMaster.ActivityID;
                    }
                    if (productMaster.ServiceID != null)
                    {
                        currProduct.ServiceID = productMaster.ServiceID;
                    }
                    if (productMaster.UnitOfSalesID != null)
                    {
                        currProduct.UnitOfSalesID = productMaster.UnitOfSalesID;
                    }
                    if (productMaster.CategoryID != null)
                    {
                        currProduct.CategoryID = productMaster.CategoryID;
                    }
                    if (productMaster.ProductName != null)
                    {
                        currProduct.ProductName = productMaster.ProductName;
                    }
                    if (productMaster.Display != null)
                    {
                        currProduct.Display = productMaster.Display;
                    }
                    if (productMaster.RateWithMaterials != null)
                    {
                        currProduct.RateWithMaterials = productMaster.RateWithMaterials;
                    }
                    if (productMaster.RateWithoutMaterials != null)
                    {
                        currProduct.RateWithoutMaterials = productMaster.RateWithoutMaterials;
                    }
                    if (productMaster.SelectedUnitID != null)
                    {
                        currProduct.SelectedUnitID = productMaster.SelectedUnitID;
                    }
                    //if (productMaster.AlternateUnitOfSales != null)
                    //{
                    //    currProduct.AlternateUnitOfSales = productMaster.AlternateUnitOfSales;
                    //}
                    if (productMaster.ShortSpecification != null)
                    {
                        currProduct.ShortSpecification = productMaster.ShortSpecification;
                    }
                    if (productMaster.Specification != null)
                    {
                        currProduct.Specification = productMaster.Specification;
                    }
                    if (productMaster.ServiceDisplay != null)
                    {
                        currProduct.ServiceDisplay = productMaster.ServiceDisplay;
                    }
                    if (productMaster.IsActive != null)
                    {
                        currProduct.IsActive = productMaster.IsActive;
                    }
                    if (productMaster.CreationTStamp != null)
                    {
                        currProduct.CreationTStamp = productMaster.CreationTStamp;
                    }
                    context.ProductMaster.Update(currProduct);
                    context.SaveChanges();


                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ProductID", Value = productMaster.ProductID },
                    new SqlParameter { ParameterName = "@SelectedUnitID", Value = productMaster.SelectedUnitID },
                    new SqlParameter { ParameterName = "@ConversionRate", Value = productMaster.AlternateUnitOfSales },
                };
                    context.Database.ExecuteSqlRaw("exec df_update_UnitConversionRate @ProductID, @SelectedUnitID, @ConversionRate", parms.ToArray());
                    
                    rowsAffected = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Department
        public List<DepartmentMaster> GetDepartments(DataContext context)
        {
            List<DepartmentMaster> departmentMaster = new List<DepartmentMaster>();
            try
            {
                departmentMaster = context.DepartmentMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return departmentMaster;
        }

        public long InsertDepartment(DataContext context, DepartmentMaster departmentMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DepartmentMaster.Add(departmentMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateDepartment(DataContext context, DepartmentMaster departmentMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DepartmentMaster.Update(departmentMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteDepartment(DataContext context, DepartmentMaster departmentMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DepartmentMaster.Remove(departmentMaster);
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

        #region Designation
        public List<DesignationMaster> GetDesignations(DataContext context)
        {
            List<DesignationMaster> designationMaster = new List<DesignationMaster>();
            try
            {
                designationMaster = context.DesignationMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return designationMaster;
        }

        public long InsertDesignation(DataContext context, DesignationMaster designationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DesignationMaster.Add(designationMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateDesignation(DataContext context, DesignationMaster designationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DesignationMaster.Update(designationMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteDesignation(DataContext context, DesignationMaster designationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.DesignationMaster.Remove(designationMaster);
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

        #region E Way Bill
        public List<EWayBills> GetEWayBills(DataContext context)
        {
            List<EWayBills> eWayBills = new List<EWayBills>();
            try
            {
                eWayBills = context.EWayBills.FromSqlRaw("exec df_Get_EWayBills").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return eWayBills;
        }

        public long InsertEWayBill(DataContext context, EWayBillMaster eWayBillMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.EWayBillMaster.Add(eWayBillMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateEWayBill(DataContext context, EWayBillMaster eWayBillMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.EWayBillMaster.Update(eWayBillMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteEWayBill(DataContext context, EWayBillMaster eWayBillMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.EWayBillMaster.Remove(eWayBillMaster);
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

        #region States
        public List<StateMaster> GetStates(DataContext context)
        {
            List<StateMaster> stateMaster = new List<StateMaster>();
            try
            {
                stateMaster = context.StateMaster.Where((el) => el.IsActive == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return stateMaster;
        }
        #endregion

        #region Cities
        public List<CityMaster> GetCities(DataContext context)
        {
            List<CityMaster> cityMaster = new List<CityMaster>();
            try
            {
                cityMaster = context.CityMaster.Where((el) => el.IsActive == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return cityMaster;
        }
        #endregion
    }
}
