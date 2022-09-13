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
            List<ActivityMaster> activityMasterMain = new List<ActivityMaster>();
            long rowsAffected = 0;
            try
            {
                activityMasterMain = context.ActivityMaster.Where(b => b.ActivityRoleName == activityMaster.ActivityRoleName).ToList();
                if (!activityMasterMain.Any())
                {
                    context.ActivityMaster.Add(activityMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateActivityRoles(DataContext context, ActivityMaster activityMaster)
        {
            List<ActivityMaster> activityMasterMain = new List<ActivityMaster>();
            long rowsAffected = 0;
            try
            {
                activityMasterMain = context.ActivityMaster.Where(b => (b.ActivityRoleName == activityMaster.ActivityRoleName && b.ID != activityMaster.ID)).ToList();
                if (!activityMasterMain.Any())
                {
                    context.ActivityMaster.Update(activityMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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
            List<ServiceMaster> serviceMasterMain = new List<ServiceMaster>();
            long rowsAffected = 0;
            try
            {
                serviceMasterMain = context.ServiceMaster.Where(b => b.ServiceName == serviceMaster.ServiceName).ToList();
                if (!serviceMasterMain.Any())
                {
                    context.ServiceMaster.Add(serviceMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateServices(DataContext context, ServiceMaster serviceMaster)
        {
            List<ServiceMaster> serviceMasterMain = new List<ServiceMaster>();
            long rowsAffected = 0;
            try
            {
                serviceMasterMain = context.ServiceMaster.Where(b => (b.ServiceName == serviceMaster.ServiceName && b.ID != serviceMaster.ID)).ToList();
                if (!serviceMasterMain.Any())
                {
                    context.ServiceMaster.Update(serviceMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@Unit1Name", Value = unitOfSalesMaster.Unit1Name },
                    new SqlParameter { ParameterName = "@Unit2Name", Value = unitOfSalesMaster.Unit2Name },
                    new SqlParameter { ParameterName = "@Unit1ID", Value = unitOfSalesMaster.Unit1ID },
                    new SqlParameter { ParameterName = "@Unit2ID", Value = unitOfSalesMaster.Unit2ID },
                    new SqlParameter { ParameterName = "@Display", Value = unitOfSalesMaster.Display },
                    new SqlParameter { ParameterName = "@ID", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.BigInt }
                };
                context.Database.ExecuteSqlRaw("exec df_insertUpdate_Unit @Unit1Name, @Unit2Name, @Unit1ID, @Unit2ID, @Display, @ID out", parms.ToArray());
                rowsAffected = Convert.ToInt32(parms[5].Value);
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
        public List<CategoryMasterResponse> GetCategories(DataContext context)
        {
            List<CategoryMasterResponse> categoryMasters = new List<CategoryMasterResponse>();
            try
            {
                categoryMasters = context.CategoryMasterResponse.FromSqlRaw("exec df_Get_Categories").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return categoryMasters;
        }

        public long InsertCategory(DataContext context, CategoryMasterResponse categoryMaster)
        {
            List<CategoryMaster> categoryMastersMain = new List<CategoryMaster>();
            long rowsAffected = 0;
            try
            {
                categoryMastersMain = context.CategoryMaster.Where(b => b.CategoryName == categoryMaster.CategoryName).ToList();
                if (!categoryMastersMain.Any())
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
                    context.Database.ExecuteSqlRaw("exec df_Insert_Category @CategoryName, @RoleID, @ServiceID, @HSNSACCode, @GSTRate, @Display, @UnitID", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateCategory(DataContext context, CategoryMasterResponse categoryMaster)
        {
            List<CategoryMaster> categoryMastersMain = new List<CategoryMaster>();
            long rowsAffected = 0;
            try
            {
                categoryMastersMain = context.CategoryMaster.Where(b => (b.CategoryName == categoryMaster.CategoryName && b.ID != categoryMaster.ID)).ToList();
                if (!categoryMastersMain.Any())
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
                else
                {
                    rowsAffected = -2;
                }
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

        #region Product / Service Product
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

        public List<ProductsByCategory> GetProductsByCategoryIDForBrands(DataContext context, Products products)
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
                productByCategoryID = context.ProductsByCategory.FromSqlRaw("exec df_Get_ProductsByCategoryIDForBrands @ActivityID, @ServiceID, @CategoryID", parms.ToArray()).ToList();
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
            List<ProductMaster> productMasterList = new List<ProductMaster>();
            long rowsAffected = 0;
            try
            {
                productMasterList = context.ProductMaster.Where(b => b.ProductName == productMaster.ProductName).ToList();
                if (!productMasterList.Any())
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
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateProducts(DataContext context, ProductMaster productMaster)
        {
            List<ProductMaster> productMasterList = new List<ProductMaster>();
            long rowsAffected = 0;
            try
            {
                productMasterList = context.ProductMaster.Where(b => (b.ProductName == productMaster.ProductName && b.ProductID != productMaster.ProductID)).ToList();
                if (!productMasterList.Any())
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

                        if (productMaster.SelectedUnitID != null)
                        {
                            List<SqlParameter> parms = new List<SqlParameter>
                        {
                            new SqlParameter { ParameterName = "@ProductID", Value = productMaster.ProductID },
                            new SqlParameter { ParameterName = "@SelectedUnitID", Value = productMaster.SelectedUnitID },
                            new SqlParameter { ParameterName = "@ConversionRate", Value = productMaster.AlternateUnitOfSales },
                        };
                            context.Database.ExecuteSqlRaw("exec df_update_UnitConversionRate @ProductID, @SelectedUnitID, @ConversionRate", parms.ToArray());
                        }
                        rowsAffected = 1;
                    }
                    else
                    {
                        rowsAffected = -2;
                    }
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
            List<DepartmentMaster> departmentMasterMain = new List<DepartmentMaster>();
            long rowsAffected = 0;
            try
            {
                departmentMasterMain = context.DepartmentMaster.Where(b => b.DepartmentName == departmentMaster.DepartmentName).ToList();
                if (!departmentMasterMain.Any())
                {
                    context.DepartmentMaster.Add(departmentMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateDepartment(DataContext context, DepartmentMaster departmentMaster)
        {
            List<DepartmentMaster> departmentMasterMain = new List<DepartmentMaster>();
            long rowsAffected = 0;
            try
            {
                departmentMasterMain = context.DepartmentMaster.Where(b => (b.DepartmentName == departmentMaster.DepartmentName && b.ID != departmentMaster.ID)).ToList();
                if (!departmentMasterMain.Any())
                {
                    context.DepartmentMaster.Update(departmentMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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

        #region Location Type
        public List<LocationTypeMasterMapped> GetLocationTypes(DataContext context)
        {
            List<LocationTypeMasterMapped> list = new List<LocationTypeMasterMapped>();
            try
            {
                list = context.LocationTypeMasterMapped.FromSqlRaw("exec df_Get_LocationTypes").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public long InsertLocationType(DataContext context, LocationType locationType)
        {
            List<LocationTypeMaster> locationTypeMain = new List<LocationTypeMaster>();
            long rowsAffected = 0;
            try
            {
                locationTypeMain = context.LocationTypeMaster.Where(b => b.BranchType == locationType.BranchType).ToList();
                if (!locationTypeMain.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@BranchType", Value = locationType.BranchType },
                    new SqlParameter { ParameterName = "@ActivityID", Value = locationType.ActivityID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = locationType.ServiceID },
                    new SqlParameter { ParameterName = "@Display", Value = locationType.Display }
                };
                    context.Database.ExecuteSqlRaw("exec df_Insert_LocationType @BranchType, @ActivityID, @ServiceID, @Display", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateLocationType(DataContext context, LocationType locationType)
        {
            List<LocationTypeMaster> locationTypeMain = new List<LocationTypeMaster>();
            long rowsAffected = 0;
            try
            {
                locationTypeMain = context.LocationTypeMaster.Where(b => (b.BranchType == locationType.BranchType && b.ID != locationType.ID)).ToList();
                if (!locationTypeMain.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = locationType.ID },
                    new SqlParameter { ParameterName = "@BranchType", Value = locationType.BranchType },
                    new SqlParameter { ParameterName = "@ActivityID", Value = locationType.ActivityID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = locationType.ServiceID },
                    new SqlParameter { ParameterName = "@Display", Value = locationType.Display }
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_LocationType @ID, @BranchType, @ActivityID, @ServiceID, @Display", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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
            List<DesignationMaster> designationMasterMain = new List<DesignationMaster>();
            long rowsAffected = 0;
            try
            {
                designationMasterMain = context.DesignationMaster.Where(b => b.DesignationName == designationMaster.DesignationName).ToList();
                if (!designationMasterMain.Any())
                {
                    context.DesignationMaster.Add(designationMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateDesignation(DataContext context, DesignationMaster designationMaster)
        {
            List<DesignationMaster> designationMasterMain = new List<DesignationMaster>();
            long rowsAffected = 0;
            try
            {
                designationMasterMain = context.DesignationMaster.Where(b => (b.DesignationName == designationMaster.DesignationName && b.ID != designationMaster.ID)).ToList();
                if (!designationMasterMain.Any())
                {
                    context.DesignationMaster.Update(designationMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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
            List<EWayBillMaster> eWayBillMasterMain = new List<EWayBillMaster>();
            long rowsAffected = 0;
            try
            {
                eWayBillMasterMain = context.EWayBillMaster.Where(b => b.StateID == eWayBillMaster.StateID).ToList();
                if (!eWayBillMasterMain.Any())
                {
                    context.EWayBillMaster.Add(eWayBillMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateEWayBill(DataContext context, EWayBillMaster eWayBillMaster)
        {
            List<EWayBillMaster> eWayBillMasterMain = new List<EWayBillMaster>();
            long rowsAffected = 0;
            try
            {
                eWayBillMasterMain = context.EWayBillMaster.Where(b => (b.StateID == eWayBillMaster.StateID && b.ID != eWayBillMaster.ID)).ToList();
                if (!eWayBillMasterMain.Any())
                {
                    context.EWayBillMaster.Update(eWayBillMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
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

        public List<CityMaster> GetCitiesByID(DataContext context, StateMaster stateMaster)
        {
            List<CityMaster> cityMasters = new List<CityMaster>();
            try
            {
                cityMasters = context.CityMaster.Where((el) => el.StateID == stateMaster.ID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return cityMasters;
        }

        #endregion

        #region Users
        public List<Users> GetUserByID(DataContext context, Users user)
        {
            List<Users> users = new List<Users>();
            try
            {
                users = context.Users.Where((el) => el.UserID == user.UserID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        public List<UserProfile> GetUserProfile(DataContext context, Users user)
        {
            List<UserProfile> userProfiles = new List<UserProfile>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserID", Value = user.UserID },
                };
                userProfiles = context.UserProfile.FromSqlRaw("exec df_Get_UserProfile @UserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userProfiles;
        }

        public long InsertUserProfile(DataContext context, UserProfile userProfile)
        {
            List<UserProfile> locationTypeMain = new List<UserProfile>();
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserID", Value = userProfile.UserID },
                    new SqlParameter { ParameterName = "@CompanyName", Value = userProfile.CompanyName },
                    new SqlParameter { ParameterName = "@CompanyLogo", Value = userProfile.CompanyLogo },
                    new SqlParameter { ParameterName = "@ContactPersonName", Value = userProfile.ContactPersonName },
                    new SqlParameter { ParameterName = "@ContactPersonNumber", Value = userProfile.ContactPersonNumber },
                    new SqlParameter { ParameterName = "@LocationName", Value = userProfile.LocationName },
                    new SqlParameter { ParameterName = "@AddressLine", Value = userProfile.AddressLine },
                    new SqlParameter { ParameterName = "@StateID", Value = userProfile.StateID },
                    new SqlParameter { ParameterName = "@CityID", Value = userProfile.CityID },
                    new SqlParameter { ParameterName = "@Pincode", Value = userProfile.Pincode },
                    new SqlParameter { ParameterName = "@GSTNumber", Value = userProfile.GSTNumber },
                    new SqlParameter { ParameterName = "@PAN", Value = userProfile.PAN },
                    new SqlParameter { ParameterName = "@AccountNumber", Value = userProfile.AccountNumber },
                    new SqlParameter { ParameterName = "@BankName", Value = userProfile.BankName },
                    new SqlParameter { ParameterName = "@BranchName", Value = userProfile.BranchName },
                    new SqlParameter { ParameterName = "@IFSCCode", Value = userProfile.IFSCCode },
                    new SqlParameter { ParameterName = "@CompanyNamePrefix", Value = userProfile.CompanyNamePrefix },
                    new SqlParameter { ParameterName = "@QuotationBudgetPrefix",Value =userProfile.QuotationBudgetPrefix},
                    new SqlParameter { ParameterName = "@EmployeeCodePrefix", Value = userProfile.EmployeeCodePrefix },
                    new SqlParameter { ParameterName = "@PurchaseOrderPrefix", Value = userProfile.PurchaseOrderPrefix },
                    new SqlParameter { ParameterName = "@SalesOrderPrefix", Value = userProfile.SalesOrderPrefix },
                    new SqlParameter { ParameterName = "@ShowBrand", Value = userProfile.ShowBrand }
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_UserProfile @UserID, @CompanyName, @CompanyLogo, @ContactPersonName, @ContactPersonNumber, @LocationName, @AddressLine, @StateID, @CityID, @Pincode, @GSTNumber, @PAN, @AccountNumber, @BankName, @BranchName, @IFSCCode, @CompanyNamePrefix, @QuotationBudgetPrefix, @EmployeeCodePrefix, @PurchaseOrderPrefix, @SalesOrderPrefix, @ShowBrand", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUserStatus(DataContext context, UserStatusRequest userStatusRequest)
        {
            List<Users> user = new List<Users>();
            long rowsAffected = 0;
            try
            {
                user = context.Users.Where(u => (u.UserID == userStatusRequest.UserID)).ToList();

                if (user.Any()) {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserID", Value = userStatusRequest.UserID },
                    new SqlParameter { ParameterName = "@Status", Value = userStatusRequest.Status },
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_UserStatus @UserID, @Status", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
                    
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public List<UsersList> GetUserApprovedList(DataContext context)
        {
            List<UsersList> usersLists = new List<UsersList>();
            try
            {
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_ApprovedUserList").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return usersLists;
        }

        public List<UsersList> GetUserDeclinedList(DataContext context)
        {
            List<UsersList> usersLists = new List<UsersList>();
            try
            {
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_DeclinedUserList").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return usersLists;
        }

        public List<UsersList> GetUserPendingList(DataContext context)
        {
            List<UsersList> usersLists = new List<UsersList>();
            try
            {
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_PendingUserList").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return usersLists;
        }

        #endregion

        #region User Department
        public List<UserDepartmentMappingList> GetUserDepartments(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserDepartmentMappingList> userDepartmentMappingLists = new List<UserDepartmentMappingList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userDepartmentMappingLists = context.UserDepartmentMappingList.FromSqlRaw("exec df_Get_UserDepartments_v1 @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userDepartmentMappingLists;
        }

        public long InsertUserDepartment(DataContext context, UserDepartmentMapping userDepartmentMapping)
        {
            List<UserDepartmentMapping> userDepartmentMappings = new List<UserDepartmentMapping>();
            long rowsAffected = 0;
            try
            {
                userDepartmentMappings = context.UserDepartmentMapping
                    .Where(udm => (udm.AddedByUserID == userDepartmentMapping.AddedByUserID &&
                    udm.DepartmentID == userDepartmentMapping.DepartmentID)).ToList();

                if (!userDepartmentMappings.Any())
                {
                    context.UserDepartmentMapping.Add(userDepartmentMapping);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUserDepartment(DataContext context, UserDepartmentMapping userDepartmentMapping)
        {
            List<UserDepartmentMapping> userDepartmentMappingsMain = new List<UserDepartmentMapping>();
            long rowsAffected = 0;
            try
            {
                userDepartmentMappingsMain = context.UserDepartmentMapping
                    .Where(udm => (udm.AddedByUserID == userDepartmentMapping.AddedByUserID &&
                    udm.DepartmentID == userDepartmentMapping.DepartmentID &&
                    udm.ID != userDepartmentMapping.ID)).ToList();

                if (!userDepartmentMappingsMain.Any())
                {
                    context.UserDepartmentMapping.Update(userDepartmentMapping);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        #endregion

        #region User Designation
        public List<UserDesignationMappingList> GetUserDesignation(DataContext context, UserDesignationMapping userDesignationMapping)
        {
            List<UserDesignationMappingList> userDesignationMappingLists = new List<UserDesignationMappingList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = userDesignationMapping.AddedByUserID },
                };
                userDesignationMappingLists = context.UserDesignationMappingList.FromSqlRaw("exec df_Get_UserDesignations_v1 @UserId, @UserType", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userDesignationMappingLists;
        }

        public long InsertUserDesignation(DataContext context, UserDesignationMapping userDesignationMapping)
        {
            List<UserDesignationMapping> userDesignationMappingList = new List<UserDesignationMapping>();
            long rowsAffected = 0;
            try
            {
                userDesignationMappingList = context.UserDesignationMapping
                    .Where(udm => (udm.AddedByUserID == userDesignationMapping.AddedByUserID &&
                    udm.DesignationID == userDesignationMapping.DesignationID)).ToList();

                if (!userDesignationMappingList.Any())
                {
                    context.UserDesignationMapping.Add(userDesignationMapping);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUserDesignation(DataContext context, UserDesignationMapping userDesignationMapping)
        {
            List<UserDesignationMapping> userDesignationMappingList = new List<UserDesignationMapping>();
            long rowsAffected = 0;
            try
            {
                userDesignationMappingList = context.UserDesignationMapping
                    .Where(udm => (udm.AddedByUserID == userDesignationMapping.AddedByUserID &&
                    udm.DesignationID == userDesignationMapping.DesignationID &&
                    udm.ID != userDesignationMapping.ID)).ToList();

                if (!userDesignationMappingList.Any())
                {
                    context.UserDesignationMapping.Update(userDesignationMapping);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        #endregion

        #region User Employees
        public long InsertUserEmployee(DataContext context, UserEmployeeRequest userEmployeeRequest)
        {
            List<EmployeeMaster> userEmployee_mobile = new List<EmployeeMaster>();
            List<EmployeeMaster> userEmployee_aadhar = new List<EmployeeMaster>();
            long rowsAffected = 0;
            try
            {
                userEmployee_aadhar = context.EmployeeMaster.Where(udm => (udm.AadharNo == userEmployeeRequest.AadharNo)).ToList();
                userEmployee_mobile = context.EmployeeMaster.Where(udm => (udm.MobileNo == userEmployeeRequest.MobileNo)).ToList();

                if (!userEmployee_mobile.Any() && !userEmployee_aadhar.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = userEmployeeRequest.AddedByUserID },
                     new SqlParameter { ParameterName = "@EmployeeName", Value = userEmployeeRequest.EmployeeName },
                     new SqlParameter { ParameterName = "@MobileNo", Value = userEmployeeRequest.MobileNo },
                     new SqlParameter { ParameterName = "@AadharNo", Value = userEmployeeRequest.AadharNo },
                };
                    context.Database.ExecuteSqlRaw("exec df_Insert_User_Employee @AddedByUserID, @EmployeeName, @MobileNo, @AadharNo", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    if (userEmployee_mobile.Any())
                    {
                        rowsAffected = -2;
                    }
                    else if (userEmployee_aadhar.Any())
                    {
                        rowsAffected = -3;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public List<UserEmployeeSearchResponse> GetUserEmployeeSearchList(DataContext context, UserEmployeeSearchRequest userEmployeeSearchRequest)
        {
            List<UserEmployeeSearchResponse> userEmployeeSearchResponses = new List<UserEmployeeSearchResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = userEmployeeSearchRequest.AddedByUserID },
                    new SqlParameter { ParameterName = "@AadharNo", Value = string.IsNullOrEmpty(userEmployeeSearchRequest.AadharNo) ? "" : userEmployeeSearchRequest.AadharNo  },
                    new SqlParameter { ParameterName = "@MobileNo", Value = string.IsNullOrEmpty(userEmployeeSearchRequest.MobileNo) ? "" : userEmployeeSearchRequest.MobileNo },
                };
                userEmployeeSearchResponses = context.UserEmployeeSearchResponse.FromSqlRaw("exec df_Get_EmployeeSearchList @AddedByUserID, @AadharNo, @MobileNo", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userEmployeeSearchResponses;
        }

        public List<UserEmployeeListResponse> GetUserEmployeeList(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserEmployeeListResponse> UserEmployeeList = new List<UserEmployeeListResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                UserEmployeeList = context.UserEmployeeListResponse.FromSqlRaw("exec df_Get_UserEmployeeList @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return UserEmployeeList;
        }

        public List<UserBranchForEmployeeResponse> GetBranchForEmployee(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserBranchForEmployeeResponse> userBranchForEmployeeResponses = new List<UserBranchForEmployeeResponse>();
            List<BranchMaster> branchMasters = new List<BranchMaster>();
            try
            {
                branchMasters = context.BranchMaster
                    .Where(bm => (bm.UserID == empoyeeMappingRequest.AddedByUserID)).ToList();

                if (branchMasters.Any())
                {
                    userBranchForEmployeeResponses.Add(new UserBranchForEmployeeResponse
                    { ID = branchMasters[0].ID, LocationName = branchMasters[0].LocationName });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return userBranchForEmployeeResponses;
        }












        public List<UserDepartmentForBranchEmployeeResponse> GetUserDepartmentForBranchEmployee(DataContext context, UserMappingRequest userMappingRequest)
        {
            List<UserDepartmentForBranchEmployeeResponse> userDepartmentForBranchEmployeeResponses = new List<UserDepartmentForBranchEmployeeResponse>();
            List<UserDepartmentMappingList> userDepartmentMappingLists = new List<UserDepartmentMappingList>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserId", Value = userMappingRequest.UserId },
                    new SqlParameter { ParameterName = "@UserType", Value = userMappingRequest.UserType },
                };
                userDepartmentMappingLists = context.UserDepartmentMappingList.FromSqlRaw("exec df_Get_UserDepartmentForBranchEmployee @UserId, @UserType", parms.ToArray()).ToList();

                if (userDepartmentMappingLists.Any())
                {
                    foreach (UserDepartmentMappingList userDepartmentMappingList in userDepartmentMappingLists)
                    {
                        userDepartmentForBranchEmployeeResponses.Add(new UserDepartmentForBranchEmployeeResponse
                        {
                            DepartmentID = userDepartmentMappingList.DepartmentID,
                            DepartmentName = userDepartmentMappingList.DepartmentName
                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return userDepartmentForBranchEmployeeResponses;
        }

        public List<UserDesignationForBranchEmployeeResponse> GetUserDesignatonForBranchEmployee(DataContext context, UserMappingRequest userMappingRequest)
        {
            List<UserDesignationForBranchEmployeeResponse> userDesignationForBranchEmployeeResponses = new List<UserDesignationForBranchEmployeeResponse>();
            List<UserDesignationMappingList> userDesignationMappingLists = new List<UserDesignationMappingList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserId", Value = userMappingRequest.UserId },
                    new SqlParameter { ParameterName = "@UserType", Value = userMappingRequest.UserType },
                };
                userDesignationMappingLists = context.UserDesignationMappingList.FromSqlRaw("exec df_Get_UserDesignationForBranchEmployee @UserId, @UserType", parms.ToArray()).ToList();

                if (userDesignationMappingLists.Any())
                {
                    foreach (UserDesignationMappingList userDesignationMappingList in userDesignationMappingLists)
                    {
                        userDesignationForBranchEmployeeResponses.Add(new UserDesignationForBranchEmployeeResponse
                        {
                            DesignationID = userDesignationMappingList.DesignationID,
                            DesignationName = userDesignationMappingList.DesignationName
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return userDesignationForBranchEmployeeResponses;
        }



        

        public List<UserReportingEmployeeResponse> GetReportingEmployeeList(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserReportingEmployeeResponse> userReportingEmployeeResponses  = new List<UserReportingEmployeeResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userReportingEmployeeResponses = context.UserReportingEmployeeResponse.FromSqlRaw("exec df_Get_ReportingEmployee @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userReportingEmployeeResponses;
        }

        public List<EmployeeReportingAuthorityResponse> GetEmployeeReportingAuthorities(DataContext context, EmployeeReportingAuthorityRequest employeeReportingAuthorityRequest)
        {
            List<EmployeeReportingAuthorityResponse> employeeReportingAuthorityResponses = new List<EmployeeReportingAuthorityResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = employeeReportingAuthorityRequest.AddedByUserID },
                    new SqlParameter { ParameterName = "@EmployeeID", Value = employeeReportingAuthorityRequest.EmployeeID },
                };
                employeeReportingAuthorityResponses = context.EmployeeReportingAuthorityResponse.FromSqlRaw("exec df_Get_EmployeeReportingAuthorities @AddedByUserID, @EmployeeID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return employeeReportingAuthorityResponses;
        }



        public long UpdateEmployeeVerificationStatus(DataContext context, UserEmployeeVerifyRequest userEmployeeVerifyRequest)
        {
            List<EmployeeMaster> employeeMasters = new List<EmployeeMaster>();
            long rowsAffected = 0;
            try
            {
                employeeMasters = context.EmployeeMaster.Where(b => (b.ID == userEmployeeVerifyRequest.EmployeeID && b.verifyStatus == false)).ToList();
                if (employeeMasters.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = userEmployeeVerifyRequest.AddedByUserID },
                    new SqlParameter { ParameterName = "@EmployeeID", Value = userEmployeeVerifyRequest.EmployeeID },
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_User_Employee_Status @AddedByUserID, @EmployeeID", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUserEmployee(DataContext context, EmployeeVerificationRequest employeeVerificationRequest)
        {
            List<Users> user = new List<Users>();
            List<EmployeeMaster> employeeMasters = new List<EmployeeMaster>();
            long rowsAffected = 0;
            try
            {
                employeeMasters = context.EmployeeMaster.Where(udm => (udm.ID == employeeVerificationRequest.EmployeeID)).ToList();
                user = context.Users.Where(udm => (udm.UserID == employeeMasters[0].UserID)).ToList();

                if (user.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                     new SqlParameter { ParameterName = "@OTP", Value = employeeVerificationRequest.OTP },
                     new SqlParameter { ParameterName = "@EmployeeID", Value = employeeVerificationRequest.EmployeeID},
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_UserEmployee @OTP, @EmployeeID", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public List<EmployeeResponse> GetEmployeeDetailsByID(DataContext context, EmployeeIDRequest employeeIDRequest)
        {
            List<EmployeeResponse> employeeResponses = new List<EmployeeResponse>();
            List<EmployeeMaster> employeeMasters = new List<EmployeeMaster>();
            List<EmployeeReportingAuthority> employeeReportingAuthority = new List<EmployeeReportingAuthority>();
            List<BankDetails> bankDetails = new List<BankDetails>();
            List<Users> user = new List<Users>();
            try
            {
                employeeMasters = context.EmployeeMaster.Where(bm => (bm.ID == employeeIDRequest.ID)).ToList();
                user = context.Users.Where(bm => (bm.UserID == employeeMasters[0].UserID)).ToList();
                employeeReportingAuthority = context.EmployeeReportingAuthority.Where(bm => (bm.EmployeeID == employeeIDRequest.ID)).ToList();
                bankDetails = context.BankDetails.Where(bm => (bm.UserID == user[0].UserID)).ToList();

                employeeResponses.Add(new EmployeeResponse
                {
                    Employee = employeeMasters,
                    EmployeeReportingAuthority = employeeReportingAuthority,
                    BankDetails = bankDetails,
                });

            }
            catch (Exception)
            {
                throw;
            }
            return employeeResponses;
        }

        public long UpdateEmployeeDetails(DataContext context, UpdateEmployeeRequest updateEmployeeRequest)
        {
            List<EmployeeMaster> employeeMasters = new List<EmployeeMaster>();
            long rowsAffected = 0;
            try
            {
                if (updateEmployeeRequest.ID > 0)
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = updateEmployeeRequest.ID },
                    new SqlParameter { ParameterName = "@MobileNo", Value = updateEmployeeRequest.MobileNo },
                    new SqlParameter { ParameterName = "@AadharNo", Value = updateEmployeeRequest.AadharNo },
                    new SqlParameter { ParameterName = "@FatherName", Value = updateEmployeeRequest.FatherName },
                    new SqlParameter { ParameterName = "@Address", Value = updateEmployeeRequest.Address },
                    new SqlParameter { ParameterName = "@StateID", Value = updateEmployeeRequest.StateID },
                    new SqlParameter { ParameterName = "@CityID", Value = updateEmployeeRequest.CityID },
                    new SqlParameter { ParameterName = "@Pincode", Value = updateEmployeeRequest.Pincode },
                    new SqlParameter { ParameterName = "@ProfilePhoto", Value = updateEmployeeRequest.ProfilePhoto },
                    new SqlParameter { ParameterName = "@BloodGroup", Value = updateEmployeeRequest.BloodGroup },
                    new SqlParameter { ParameterName = "@DOB", Value = updateEmployeeRequest.DOB },
                    new SqlParameter { ParameterName = "@DOJ", Value = updateEmployeeRequest.DOJ },
                    new SqlParameter { ParameterName = "@EmergencyContactName", Value = updateEmployeeRequest.EmergencyContactName },
                    new SqlParameter { ParameterName = "@EmergencyContactNo", Value = updateEmployeeRequest.EmergencyContactNo },
                    new SqlParameter { ParameterName = "@IDCardValidity", Value = updateEmployeeRequest.IDCardValidity },
                    new SqlParameter { ParameterName = "@LoginActiveStatus", Value = updateEmployeeRequest.LoginActiveStatus },
                    new SqlParameter { ParameterName = "@BranchID", Value = updateEmployeeRequest.BranchID },
                    new SqlParameter { ParameterName = "@DepartmentID", Value = updateEmployeeRequest.DepartmentID },
                    new SqlParameter { ParameterName = "@DesignationID", Value = updateEmployeeRequest.DesignationID },
                    new SqlParameter { ParameterName = "@EmployeeType", Value = updateEmployeeRequest.EmployeeType },
                    new SqlParameter { ParameterName = "@LastWorkDate", Value = updateEmployeeRequest.LastWorkDate },
                    new SqlParameter { ParameterName = "@WagesType", Value = updateEmployeeRequest.WagesType },
                    new SqlParameter { ParameterName = "@Salary", Value = updateEmployeeRequest.Salary },
                    new SqlParameter { ParameterName = "@AccountHolderName", Value = updateEmployeeRequest.AccountHolderName },
                    new SqlParameter { ParameterName = "@AccountNumber", Value = updateEmployeeRequest.AccountNumber },
                    new SqlParameter { ParameterName = "@BankName", Value = updateEmployeeRequest.BankName },
                    new SqlParameter { ParameterName = "@BranchName", Value = updateEmployeeRequest.BranchName },
                    new SqlParameter { ParameterName = "@IFSCCode", Value = updateEmployeeRequest.IFSCCode },

                };
                    context.Database.ExecuteSqlRaw("exec df_Update_UserEmployeeDetails @ID, @MobileNo, @AadharNo, @FatherName, @Address, @StateID, @CityID, " +
                        "@Pincode, @ProfilePhoto, @BloodGroup, @DOB, @DOJ, @EmergencyContactName, @EmergencyContactNo, @IDCardValidity, @LoginActiveStatus, " +
                        "@BranchID, @DepartmentID, @DesignationID, @EmployeeType, @LastWorkDate, @WagesType, @Salary, @AccountHolderName, @AccountNumber, " +
                        "@BankName, @BranchName, @IFSCCode", parms.ToArray());
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected = -2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateEmployeeReportingAuthority(DataContext context, EmployeeReportingAuthority employeeReportingAuthority)
        {
            List<EmployeeReportingAuthority> employeeReportingAuthorityMain = new List<EmployeeReportingAuthority>();
            long rowsAffected = 0;
            try
            {
                context.EmployeeReportingAuthority.Add(employeeReportingAuthority);
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

        #region Branch
        public List<UserBranchList> GetUserBranches(DataContext context, UserMappingRequest userMappingRequest)
        {
            List<UserBranchList> userDesignationMappingLists = new List<UserBranchList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserId", Value = userMappingRequest.UserId },
                    new SqlParameter { ParameterName = "@UserType", Value = userMappingRequest.UserType },
                };
                userDesignationMappingLists = context.UserBranchList.FromSqlRaw("exec df_Get_UserBranchDetails @UserId, @UserType", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userDesignationMappingLists;
        }

        public List<CompanyList> GetUserCompanyName(DataContext context, UserMappingRequest userMappingRequest)
        {
            List<CompanyList> companyLists = new List<CompanyList>();
            List<Companies> companies = new List<Companies>();
            try
            {
                companies = context.Companies
                    .Where(c => (c.UserID == userMappingRequest.UserId)).ToList();

                if (companies.Any())
                {
                    companyLists[0].CompanyID = companies[0].CompanyID;
                    companyLists[0].CompanyName = companies[0].CompanyName;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return companyLists;
        }

        public List<LocationTypeMaster> GetLocationTypeForBranch(DataContext context)
        {
            List<LocationTypeMaster> locationTypeList = new List<LocationTypeMaster>();
            try
            {
                locationTypeList = context.LocationTypeMaster
                    .Where(ltm => (ltm.ID == 2 &&
                    ltm.ID == 3)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return locationTypeList;
        }

        public long InsertUserBranch(DataContext context, BranchMaster branchMaster)
        {
            List<BranchMaster> branchMasters_regional = new List<BranchMaster>();
            List<BranchMaster> branchMasters_branch = new List<BranchMaster>();
            long rowsAffected = 0;
            try
            {
                branchMasters_regional = context.BranchMaster
                    .Where(udm => (udm.UserID == branchMaster.UserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.StateID == branchMaster.StateID)).ToList();

                branchMasters_branch = context.BranchMaster
                    .Where(udm => (udm.UserID == branchMaster.UserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.CityID == branchMaster.CityID &&
                    udm.LocationName == branchMaster.LocationName)).ToList();

                if (!branchMasters_regional.Any() && !branchMasters_branch.Any())
                {
                    context.BranchMaster.Add(branchMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    if (!branchMasters_regional.Any())
                    {
                        rowsAffected = -2;
                    }
                    else if (!branchMasters_branch.Any())
                    {
                        rowsAffected = -3;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateUserBranch(DataContext context, BranchMaster branchMaster)
        {
            List<BranchMaster> branchMasters_regional = new List<BranchMaster>();
            List<BranchMaster> branchMasters_branch = new List<BranchMaster>();
            long rowsAffected = 0;
            try
            {
                branchMasters_regional = context.BranchMaster
                    .Where(udm => (udm.UserID == branchMaster.UserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.StateID == branchMaster.StateID &&
                    udm.ID != branchMaster.ID)).ToList();

                branchMasters_branch = context.BranchMaster
                    .Where(udm => (udm.UserID == branchMaster.UserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.CityID == branchMaster.CityID &&
                    udm.LocationName == branchMaster.LocationName &&
                    udm.ID != branchMaster.ID)).ToList();

                if (!branchMasters_regional.Any() && !branchMasters_branch.Any())
                {
                    context.BranchMaster.Add(branchMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    if (!branchMasters_regional.Any())
                    {
                        rowsAffected = -2;
                    }
                    else if (!branchMasters_branch.Any())
                    {
                        rowsAffected = -3;
                    }
                }
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
