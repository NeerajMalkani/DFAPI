﻿using DFAPI.Entities;
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

        public List<ProductResponse> GetServiceProducts_v1(DataContext context)
        {
            List<ProductResponse> products = new List<ProductResponse>();
            try
            {
                products = context.ProductResponse.FromSqlRaw("exec df_Get_ServiceProducts_v1").ToList();
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


        public List<DesignTypeMaster> GetDesignTypeImage(DataContext context, DesignTypeMaster designTypeMaster)
        {
            List<DesignTypeMaster> objDesignType = new List<DesignTypeMaster>();
            try
            {
                objDesignType = context.DesignTypeMaster.Where(b => b.ID == designTypeMaster.ID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return objDesignType;
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

        public List<RateCardProductsByCategory> GetContractorRateCardProductsByCategoryID(DataContext context, ContractorRateCardProductRequest contractorRateCardProductRequest)
        {
            List<RateCardProductsByCategory> rateCardProductsByCategory = new List<RateCardProductsByCategory>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ActivityID", Value = contractorRateCardProductRequest.ActivityID },
                new SqlParameter { ParameterName = "@ServiceID", Value = contractorRateCardProductRequest.ServiceID },
                new SqlParameter { ParameterName = "@CategoryID", Value = contractorRateCardProductRequest.CategoryID },
                new SqlParameter { ParameterName = "@ContractorID", Value = contractorRateCardProductRequest.ContractorID },
                new SqlParameter { ParameterName = "@InclusiveMaterial", Value = contractorRateCardProductRequest.InclusiveMaterial }
                };
                rateCardProductsByCategory = context.RateCardProductsByCategory.FromSqlRaw("exec df_Get_ContractorRateCardProductsByCategoryID @ActivityID, @ServiceID, @CategoryID, @ContractorID, @InclusiveMaterial", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return rateCardProductsByCategory;
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

        public List<UnitOfProduct> GetProductUnitByID(DataContext context, ProductMaster productMaster)
        {
            List<UnitOfProduct> unitOfProducts = new List<UnitOfProduct>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ProductID", Value = productMaster.ProductID }
                };
                unitOfProducts = context.UnitOfProduct.FromSqlRaw("exec df_Get_UnitByProductID_v1 @ProductID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return unitOfProducts;
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
                            new SqlParameter { ParameterName = "@ConversionRate", Value = productMaster.AlternateUnitOfSales },
                        };
                            context.Database.ExecuteSqlRaw("exec df_update_UnitConversionRate_v1 @ProductID, @ConversionRate", parms.ToArray());
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

        public List<GeneralUserProfileResponse> GetGeneralUserProfile(DataContext context, Users user)
        {
            List<GeneralUserProfileResponse> generalUserProfileResponses = new List<GeneralUserProfileResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserID", Value = user.UserID },
                };
                generalUserProfileResponses = context.GeneralUserProfileResponse.FromSqlRaw("exec df_Get_GenralUserProfile  @UserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return generalUserProfileResponses;
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

                if (user.Any())
                {
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

        public long UpdateGeneralUserProfile(DataContext context, UpadteGeneralUser upadteGeneralUser)
        {
            List<Users> user = new List<Users>();
            long rowsAffected = 0;
            try
            {
                user = context.Users.Where(u => (u.UserID == upadteGeneralUser.UserID)).ToList();

                if (user.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@UserID", Value = upadteGeneralUser.UserID },
                    new SqlParameter { ParameterName = "@CompanyName", Value = upadteGeneralUser.CompanyName },
                    new SqlParameter { ParameterName = "@ContactPersonName", Value = upadteGeneralUser.ContactPersonName },
                    new SqlParameter { ParameterName = "@ContactPersonNumber", Value = upadteGeneralUser.ContactPersonNumber },
                    new SqlParameter { ParameterName = "@AddressLine", Value = upadteGeneralUser.AddressLine },
                    new SqlParameter { ParameterName = "@StateID", Value = upadteGeneralUser.StateID },
                    new SqlParameter { ParameterName = "@CityID", Value = upadteGeneralUser.CityID },
                    new SqlParameter { ParameterName = "@Pincode", Value = upadteGeneralUser.Pincode },
                    new SqlParameter { ParameterName = "@GSTNumber", Value = upadteGeneralUser.GSTNumber },
                    new SqlParameter { ParameterName = "@PAN", Value = upadteGeneralUser.PAN },
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_GeneralUserProfile @UserID, @CompanyName, @ContactPersonName, @ContactPersonNumber, " +
                        "@AddressLine ,@StateID ,@CityID ,@Pincode ,@GSTNumber ,@PAN", parms.ToArray());
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
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_ApprovedUserList_v1").ToList();
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
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_DeclinedUserList_v1").ToList();
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
                usersLists = context.UsersList.FromSqlRaw("exec df_Get_PendingUserList_v1").ToList();
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
                    .Where(udm => udm.AddedByUserID == userDepartmentMapping.AddedByUserID &&
                    udm.DepartmentID == userDepartmentMapping.DepartmentID).ToList();

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
                    .Where(udm => udm.AddedByUserID == userDepartmentMapping.AddedByUserID &&
                    udm.DepartmentID == userDepartmentMapping.DepartmentID &&
                    udm.ID != userDepartmentMapping.ID).ToList();

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
        public List<UserDesignationMappingList> GetUserDesignation(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserDesignationMappingList> userDesignationMappingLists = new List<UserDesignationMappingList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userDesignationMappingLists = context.UserDesignationMappingList.FromSqlRaw("exec df_Get_UserDesignations_v1 @AddedByUserID", parms.ToArray()).ToList();
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

        public long InsertNewEmployee(DataContext context, NewEmployeeRequest newEmployeeRequest)
        {
            List<EmployeeMaster> userEmployee = new List<EmployeeMaster>();
            long rowsAffected = 0;
            try
            {
                userEmployee = context.EmployeeMaster.Where(udm => udm.ID == newEmployeeRequest.EmployeeID).ToList();

                if (userEmployee.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = newEmployeeRequest.AddedByUserID },
                     new SqlParameter { ParameterName = "@EmployeeID", Value = newEmployeeRequest.EmployeeID },
                };
                    context.Database.ExecuteSqlRaw("exec df_Insert_New_Employee @AddedByUserID, @EmployeeID", parms.ToArray());
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
                    .Where(bm => (bm.AddedByUserID == empoyeeMappingRequest.AddedByUserID)).ToList();

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



        public List<UserDepartmentForBranchEmployeeResponse> GetUserDepartmentForBranchEmployee(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserDepartmentForBranchEmployeeResponse> userDepartmentForBranchEmployeeResponses = new List<UserDepartmentForBranchEmployeeResponse>();
            List<UserDepartmentMappingList> userDepartmentMappingLists = new List<UserDepartmentMappingList>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userDepartmentMappingLists = context.UserDepartmentMappingList.FromSqlRaw("exec df_Get_UserDepartmentForBranchEmployee_V1 @AddedByUserID", parms.ToArray()).ToList();

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

        public List<UserDesignationForBranchEmployeeResponse> GetUserDesignatonForBranchEmployee(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserDesignationForBranchEmployeeResponse> userDesignationForBranchEmployeeResponses = new List<UserDesignationForBranchEmployeeResponse>();
            List<UserDesignationMappingList> userDesignationMappingLists = new List<UserDesignationMappingList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userDesignationMappingLists = context.UserDesignationMappingList.FromSqlRaw("exec df_Get_UserDesignationForBranchEmployee_v1 @AddedByUserID", parms.ToArray()).ToList();

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
            List<UserReportingEmployeeResponse> userReportingEmployeeResponses = new List<UserReportingEmployeeResponse>();
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
                employeeMasters = context.EmployeeMaster.Where(bm => bm.ID == employeeIDRequest.ID).ToList();
                user = context.Users.Where(bm => bm.UserID == employeeMasters[0].UserID).ToList();
                employeeReportingAuthority = context.EmployeeReportingAuthority.Where(bm => bm.EmployeeID == employeeIDRequest.ID && bm.AddedByUserID == employeeIDRequest.AddedByUserID).ToList();
                bankDetails = context.BankDetails.Where(bm => bm.UserID == user[0].UserID).ToList();

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
                    new SqlParameter { ParameterName = "@DOB", Value = (updateEmployeeRequest.DOB == null) ? DBNull.Value : updateEmployeeRequest.DOB },
                    new SqlParameter { ParameterName = "@DOJ", Value = (updateEmployeeRequest.DOJ == null) ? DBNull.Value : updateEmployeeRequest.DOJ },
                    new SqlParameter { ParameterName = "@EmergencyContactName", Value = updateEmployeeRequest.EmergencyContactName },
                    new SqlParameter { ParameterName = "@EmergencyContactNo", Value = updateEmployeeRequest.EmergencyContactNo },
                    new SqlParameter { ParameterName = "@IDCardValidity", Value = (updateEmployeeRequest.IDCardValidity == null) ? DBNull.Value : updateEmployeeRequest.IDCardValidity },
                    new SqlParameter { ParameterName = "@LoginActiveStatus", Value = updateEmployeeRequest.LoginActiveStatus },
                    new SqlParameter { ParameterName = "@BranchID", Value = updateEmployeeRequest.BranchID },
                    new SqlParameter { ParameterName = "@DepartmentID", Value = updateEmployeeRequest.DepartmentID },
                    new SqlParameter { ParameterName = "@DesignationID", Value = updateEmployeeRequest.DesignationID },
                    new SqlParameter { ParameterName = "@EmployeeType", Value = updateEmployeeRequest.EmployeeType },
                    new SqlParameter { ParameterName = "@LastWorkDate", Value = (updateEmployeeRequest.LastWorkDate == null) ? DBNull.Value : updateEmployeeRequest.LastWorkDate },
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

        public long UpdateEmployeeReportingAuthority(DataContext context, EmployeeReportingAuthorityUpdateRequest employeeReportingAuthorityUpdateRequest)
        {
            long rowsAffected = 0;
            try
            {
                if (employeeReportingAuthorityUpdateRequest.ReportingAuthorityID.Trim() != "")
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                    new SqlParameter { ParameterName = "@EmployeeID", Value = employeeReportingAuthorityUpdateRequest.EmployeeID },
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = employeeReportingAuthorityUpdateRequest.AddedByUserID },
                    new SqlParameter { ParameterName = "@ReportingAuthority", Value = employeeReportingAuthorityUpdateRequest.ReportingAuthorityID.Trim() },
                    };
                    context.Database.ExecuteSqlRaw("exec df_Update_EmployeeReportingAuthority @EmployeeID, @AddedByUserID, @ReportingAuthority", parms.ToArray());
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

        #region Branch
        public List<UserBranchList> GetUserBranches(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<UserBranchList> userDesignationMappingLists = new List<UserBranchList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                userDesignationMappingLists = context.UserBranchList.FromSqlRaw("exec df_Get_UserBranchDetails @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userDesignationMappingLists;
        }

        public List<BranchCompanyDetails> BranchCompanyDetails(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<BranchCompanyDetails> branchCompanyDetails = new List<BranchCompanyDetails>();
            List<Companies> companies = new List<Companies>();
            List<Users> users = new List<Users>();

            try
            {
                companies = context.Companies
                    .Where(c => (c.UserID == empoyeeMappingRequest.AddedByUserID)).ToList();

                users = context.Users
                    .Where(c => c.UserID == empoyeeMappingRequest.AddedByUserID).ToList();

                if (companies.Any())
                {

                    branchCompanyDetails.Add(new BranchCompanyDetails
                    {
                        CompanyID = companies[0].CompanyID,
                        CompanyName = companies[0].CompanyName,
                        PAN = users[0].PAN
                    });

                }
            }
            catch (Exception)
            {
                throw;
            }
            return branchCompanyDetails;
        }

        public List<BranchTypes> GetLocationTypeForBranch(DataContext context, ActivityRequest activityRequest)
        {
            List<BranchTypes> branchTypes = new List<BranchTypes>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ActivityID", Value = activityRequest.ActivityID },
                };
                branchTypes = context.BranchTypes.FromSqlRaw("exec df_Get_BranchLocationTypes @ActivityID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return branchTypes;
        }

        public List<EmployeeMaster> GetBranchAdmins(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<EmployeeMaster> employees = new List<EmployeeMaster>();
            try
            {
                employees = context.EmployeeMaster
                    .Where(c => (c.AddedByUserID == empoyeeMappingRequest.AddedByUserID)).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return employees;
        }

        public long InsertUserBranch(DataContext context, BranchMaster branchMaster)
        {
            List<BranchMaster> branchMasters_regional = new List<BranchMaster>();
            List<BranchMaster> branchMasters_branch = new List<BranchMaster>();
            long rowsAffected = 0;
            try
            {
                branchMasters_regional = context.BranchMaster
                    .Where(udm => (udm.AddedByUserID == branchMaster.AddedByUserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.StateID == branchMaster.StateID)).ToList();

                branchMasters_branch = context.BranchMaster
                    .Where(udm => (udm.AddedByUserID == branchMaster.AddedByUserID &&
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
                    .Where(udm => (udm.AddedByUserID == branchMaster.AddedByUserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.StateID == branchMaster.StateID &&
                    udm.ID != branchMaster.ID)).ToList();

                branchMasters_branch = context.BranchMaster
                    .Where(udm => (udm.AddedByUserID == branchMaster.AddedByUserID &&
                    udm.BranchTypeID == 2 &&
                    udm.BranchTypeID == branchMaster.BranchTypeID &&
                    udm.CityID == branchMaster.CityID &&
                    udm.LocationName == branchMaster.LocationName &&
                    udm.ID != branchMaster.ID)).ToList();

                if (!branchMasters_regional.Any() && !branchMasters_branch.Any())
                {
                    context.BranchMaster.Update(branchMaster);
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
        public List<BranchRegionalOfficeList> GetBranchRegionalOffice(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<BranchRegionalOfficeList> branchRegionalOfficeLists = new List<BranchRegionalOfficeList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                branchRegionalOfficeLists = context.BranchRegionalOfficeList.FromSqlRaw("exec df_Get_BranchRegionalLocation @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return branchRegionalOfficeLists;
        }
        #endregion

        #region Contractor

        public List<ContractorActiveServiceList> GetContractorActiveServices(DataContext context, ContractorServiceMapping contractorServiceMapping)
        {
            List<ContractorActiveServiceList> contractorActiveServiceLists = new List<ContractorActiveServiceList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ContractorID", Value = contractorServiceMapping.ContractorID },
                };
                contractorActiveServiceLists = context.ContractorActiveServiceList.FromSqlRaw("exec df_Get_ContractorActiveServices @ContractorID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorActiveServiceLists;
        }

        public long InsertUpdateContractorRateCard(DataContext context, ContractorRateCard contractorRateCard)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@RateCardID", Value = contractorRateCard.RateCardID },
                    new SqlParameter { ParameterName = "@ProductID", Value = contractorRateCard.ProductID },
                    new SqlParameter { ParameterName = "@ActivityID", Value = contractorRateCard.ActivityID },
                    new SqlParameter { ParameterName = "@ServiceID", Value = contractorRateCard.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = contractorRateCard.CategoryID },
                    new SqlParameter { ParameterName = "@SelectedUnitID", Value = contractorRateCard.SelectedUnitID },
                    new SqlParameter { ParameterName = "@UnitOfSalesID", Value = contractorRateCard.UnitOfSalesID },
                    new SqlParameter { ParameterName = "@RateWithMaterials", Value = contractorRateCard.RateWithMaterials },
                    new SqlParameter { ParameterName = "@RateWithoutMaterials", Value = contractorRateCard.RateWithoutMaterials },
                    new SqlParameter { ParameterName = "@AltRateWithMaterials", Value = contractorRateCard.AltRateWithMaterials },
                    new SqlParameter { ParameterName = "@AltRateWithoutMaterials", Value = contractorRateCard.AltRateWithoutMaterials },
                    new SqlParameter { ParameterName = "@AlternateUnitOfSales", Value = contractorRateCard.AlternateUnitOfSales },
                    new SqlParameter { ParameterName = "@ShortSpecification", Value = contractorRateCard.ShortSpecification },
                    new SqlParameter { ParameterName = "@Specification", Value = contractorRateCard.Specification },
                    new SqlParameter { ParameterName = "@Display", Value = contractorRateCard.Display },
                    new SqlParameter { ParameterName = "@ContractorID", Value = contractorRateCard.ContractorID },
                };
                context.Database.ExecuteSqlRaw("exec df_InsertUpdate_Contractor_RateCard @RateCardID, @ProductID, @ActivityID, @ServiceID, @CategoryID, " +
                    "@SelectedUnitID, @UnitOfSalesID ,@RateWithMaterials ,@RateWithoutMaterials, @AltRateWithMaterials, @AltRateWithoutMaterials, @AlternateUnitOfSales ,@ShortSpecification ,@Specification ," +
                    "@Display ,@ContractorID", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public List<ContractorRateCardList> GetContractorRateCardList(DataContext context, ContractorServiceMapping contractorServiceMapping)
        {
            List<ContractorRateCardList> contractorRateCardLists = new List<ContractorRateCardList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ContractorID", Value = contractorServiceMapping.ContractorID },
                };
                contractorRateCardLists = context.ContractorRateCardList.FromSqlRaw("exec df_Get_ContractorRateCardList @ContractorID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorRateCardLists;
        }

        public List<ContractorRateCard> GetContractorRateCardByID(DataContext context, ContractorRateCard contractorRateCard)
        {
            List<ContractorRateCard> contractorRateCards = new List<ContractorRateCard>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@RateCardID", Value = contractorRateCard.RateCardID },
                };
                contractorRateCards = context.ContractorRateCard.FromSqlRaw("exec df_Get_ContractorRateCardByID @RateCardID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorRateCards;
        }
        #endregion

        #region Rate Card
        public List<ClientList> GetContractorClientList(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<ClientList> clientLists = new List<ClientList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                clientLists = context.ClientList.FromSqlRaw("exec df_Get_Clients_ForRateCard @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return clientLists;
        }

        public List<QuotationWiseEstimationList> GetQuotationWiseEstimationStatus(DataContext context, SentQuotationStatusRequest sentQuotationStatusRequest)
        {

            List<QuotationWiseEstimationList> quotationWiseEstimationLists = new List<QuotationWiseEstimationList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = sentQuotationStatusRequest.AddedByUserID },
                    new SqlParameter { ParameterName = "@Status", Value = sentQuotationStatusRequest.Status },
                };
                quotationWiseEstimationLists = context.QuotationWiseEstimationList.FromSqlRaw("exec df_Get_QuotationWiseEstimationByStatus @AddedByUserID, @Status", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return quotationWiseEstimationLists;
        }

        public long ManageRateCard(DataContext context, ContractorRateCardMappingRequest contractorRateCardMappingRequest)
        {
            List<ContractorRateCardMapping> contractorRateCardMappings = new List<ContractorRateCardMapping>();
            List<ContractorRateCardMappingItems> contractorRateCardMappingItems = new List<ContractorRateCardMappingItems>();
            List<ContractorRateCardMappingItems> contractorRateCardMappingItems_Remove = new List<ContractorRateCardMappingItems>();
            long rowsAffected = 0;
            long newID = 0;
            try
            {
                if (contractorRateCardMappingRequest.contractorRateCardMapping[0].ID == 0)
                {
                    if (contractorRateCardMappingRequest.contractorRateCardMapping[0].ClientID != 0)
                    {
                        context.ContractorRateCardMapping.Add(contractorRateCardMappingRequest.contractorRateCardMapping[0]);
                        context.SaveChanges();
                        newID = contractorRateCardMappingRequest.contractorRateCardMapping[0].ID;
                        rowsAffected = 1;

                        if (contractorRateCardMappingRequest.contractorRateCardMappingItems[0].ProductID > 0)
                        {
                            foreach (ContractorRateCardMappingItems contractorRateCardMappingItem in contractorRateCardMappingRequest.contractorRateCardMappingItems)
                            {
                                contractorRateCardMappingItem.RateCardMappingID = newID;
                                if (contractorRateCardMappingItem.ProductID > 0 && contractorRateCardMappingItem.Rate > 0)
                                {
                                    context.ContractorRateCardMappingItems.Add(contractorRateCardMappingItem);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        rowsAffected = -2;
                    }
                }
                else
                {
                    if (contractorRateCardMappingRequest.contractorRateCardMapping[0].ClientID != 0)
                    {

                        context.ContractorRateCardMapping.Update(contractorRateCardMappingRequest.contractorRateCardMapping[0]);
                        context.SaveChanges();
                        rowsAffected = 1;

                        if (contractorRateCardMappingRequest.contractorRateCardMappingItems[0].ProductID > 0)
                        {

                            contractorRateCardMappingItems_Remove = context.ContractorRateCardMappingItems.Where(b => b.RateCardMappingID == contractorRateCardMappingRequest.contractorRateCardMapping[0].ID).ToList();
                            if (contractorRateCardMappingItems_Remove.Any())
                            {
                                foreach (ContractorRateCardMappingItems contractorRateCardMappingItem in contractorRateCardMappingItems_Remove)
                                {
                                    context.ContractorRateCardMappingItems.Remove(contractorRateCardMappingItem);
                                    context.SaveChanges();
                                }
                            }

                            foreach (ContractorRateCardMappingItems contractorRateCardMappingItem in contractorRateCardMappingRequest.contractorRateCardMappingItems)
                            {
                                if (contractorRateCardMappingItem.ProductID > 0 && contractorRateCardMappingItem.Rate > 0)
                                {
                                    context.ContractorRateCardMappingItems.Add(contractorRateCardMappingItem);
                                    context.SaveChanges();
                                }
                            }
                        }
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

        public long ManageQuotationWiseEstimation(DataContext context, QuotationWiseEstimationRequest quotationWiseEstimationRequest)
        {
            List<QuotationWiseEstimation> quotationWiseEstimations = new List<QuotationWiseEstimation>();
            List<QuotationWiseEstimationItems> quotationWiseEstimationItems = new List<QuotationWiseEstimationItems>();
            List<QuotationWiseEstimationItems> quotationWiseEstimationItems_Remove = new List<QuotationWiseEstimationItems>();
            long rowsAffected = 0, newID = 0;
            try
            {
                if (quotationWiseEstimationRequest.quotationWiseEstimations[0].ID == 0)
                {
                    if (quotationWiseEstimationRequest.quotationWiseEstimations[0].ClientID != 0)
                    {
                        context.QuotationWiseEstimation.Add(quotationWiseEstimationRequest.quotationWiseEstimations[0]);
                        context.SaveChanges();

                        newID = quotationWiseEstimationRequest.quotationWiseEstimations[0].ID;

                        List<SqlParameter> parms = new List<SqlParameter>
                        {
                            new SqlParameter { ParameterName = "@ID", Value = newID }
                        };
                        context.Database.ExecuteSqlRaw("exec df_Update_QuotationWiseEstimation_QuotationNo @ID", parms.ToArray());

                        rowsAffected = 1;

                        if (quotationWiseEstimationRequest.quotationWiseEstimationItems[0].ProductID > 0)
                        {
                            foreach (QuotationWiseEstimationItems quotationWiseEstimationItem in quotationWiseEstimationRequest.quotationWiseEstimationItems)
                            {
                                quotationWiseEstimationItem.QuotationID = newID;
                                if (quotationWiseEstimationItem.ProductID > 0 && quotationWiseEstimationItem.Rate > 0)
                                {
                                    context.QuotationWiseEstimationItems.Add(quotationWiseEstimationItem);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        rowsAffected = -2;
                    }
                }
                else
                {
                    if (quotationWiseEstimationRequest.quotationWiseEstimations[0].ClientID != 0)
                    {
                        context.QuotationWiseEstimation.Update(quotationWiseEstimationRequest.quotationWiseEstimations[0]);
                        context.SaveChanges();
                        rowsAffected = 1;

                        if (quotationWiseEstimationRequest.quotationWiseEstimationItems[0].ProductID > 0)
                        {

                            quotationWiseEstimationItems_Remove = context.QuotationWiseEstimationItems.Where(b => b.QuotationID == quotationWiseEstimationRequest.quotationWiseEstimations[0].ID).ToList();
                            if (quotationWiseEstimationItems_Remove.Any())
                            {
                                foreach (QuotationWiseEstimationItems contractorRateCardMappingItem in quotationWiseEstimationItems_Remove)
                                {
                                    context.QuotationWiseEstimationItems.Remove(contractorRateCardMappingItem);
                                    context.SaveChanges();
                                }
                            }

                            foreach (QuotationWiseEstimationItems contractorRateCardMappingItem in quotationWiseEstimationRequest.quotationWiseEstimationItems)
                            {
                                if (contractorRateCardMappingItem.ProductID > 0 && contractorRateCardMappingItem.Rate > 0)
                                {
                                    context.QuotationWiseEstimationItems.Add(contractorRateCardMappingItem);
                                    context.SaveChanges();
                                }
                            }
                        }
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

        public List<ContractorRateCardSentList> GetContractorRateCardSentList(DataContext context, EmpoyeeMappingRequest empoyeeMappingRequest)
        {
            List<ContractorRateCardSentList> contractorRateCardSentLists = new List<ContractorRateCardSentList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = empoyeeMappingRequest.AddedByUserID },
                };
                contractorRateCardSentLists = context.ContractorRateCardSentList.FromSqlRaw("exec df_Get_ContractorRateCardSentList @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorRateCardSentLists;
        }

        public List<ContractorRateCardMapping> GetContractorSentRateCardByID(DataContext context, ContractorRateCardMapping contractorRateCardMapping)
        {
            List<ContractorRateCardMapping> contractorRateCardMappings = new List<ContractorRateCardMapping>();
            try
            {
                contractorRateCardMappings = context.ContractorRateCardMapping.Where(b => b.ID == contractorRateCardMapping.ID && b.AddedByUserID == contractorRateCardMapping.AddedByUserID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorRateCardMappings;
        }

        public List<QuotationWiseEstimation> GetQuotationWiseEstimationByID(DataContext context, QuotationWiseEstimation quotationWiseEstimation)
        {
            List<QuotationWiseEstimation> quotationWiseEstimations = new List<QuotationWiseEstimation>();
            try
            {
                quotationWiseEstimations = context.QuotationWiseEstimation.Where(b => b.ID == quotationWiseEstimation.ID && b.AddedByUserID == quotationWiseEstimation.AddedByUserID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return quotationWiseEstimations;
        }

        public List<RateCardProductsByCategory> GetContractorRateCardProductsByID(DataContext context, ContractorRateCardProductByIDRequest contractorRateCardProductByIDRequest)
        {
            List<RateCardProductsByCategory> rateCardProductsByCategory = new List<RateCardProductsByCategory>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ContractorID", Value = contractorRateCardProductByIDRequest.ContractorID },
                new SqlParameter { ParameterName = "@RateCardMappingID", Value = contractorRateCardProductByIDRequest.RateCardMappingID }
                };
                rateCardProductsByCategory = context.RateCardProductsByCategory.FromSqlRaw("exec df_Get_ContractorRateCardProductsByID @ContractorID, @RateCardMappingID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return rateCardProductsByCategory;
        }

        public List<QuotationEstimationProducts> GetQuotationWiseEstimationProductsByID(DataContext context, QuotationWiseEstimation quotationWiseEstimation)
        {
            List<QuotationEstimationProducts> quotationEstimationProducts = new List<QuotationEstimationProducts>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@AddedByUserID", Value = quotationWiseEstimation.AddedByUserID },
                new SqlParameter { ParameterName = "@ID", Value = quotationWiseEstimation.ID }
                };
                quotationEstimationProducts = context.QuotationEstimationProducts.FromSqlRaw("exec df_Get_QuotationWiseEstimationProductsByID @AddedByUserID, @ID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return quotationEstimationProducts;
        }

        public long UpdateQuotationEstimationStatus(DataContext context, QuotationWiseEstimation quotationWiseEstimation)
        {
            List<QuotationWiseEstimation> quotationWiseEstimations = new List<QuotationWiseEstimation>();
            long rowsAffected = 0;
            try
            {
                quotationWiseEstimations = context.QuotationWiseEstimation.Where(q => (q.ID == quotationWiseEstimation.ID)).ToList();
                if (quotationWiseEstimations.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                    {
                        new SqlParameter { ParameterName = "@ID", Value = quotationWiseEstimation.ID },
                        new SqlParameter { ParameterName = "@Status", Value = quotationWiseEstimation.Status }
                    };
                    context.Database.ExecuteSqlRaw("exec df_Update_QuotationWiseEstimation_Status @ID, @Status", parms.ToArray());
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
    }
}
