using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly DataContext _db;

        public MasterController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Activity Roles
        [HttpGet]
        [Route("getactivityroles")]
        public Response GetActivityRoles()
        {
            Response response = new Response();
            try
            {
                List<ActivityMaster> activityRoles = new MasterRepository().GetActivityRoles(_db);
                if (activityRoles.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, activityRoles);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, activityRoles);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertactivityroles")]
        public Response InsertActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertActivityRoles(_db, activityMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updateactivityroles")]
        public Response UpdateActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateActivityRoles(_db, activityMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deleteactivityroles")]
        public Response DeleteActivityRoles(ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteActivityRoles(_db, activityMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Services
        [HttpGet]
        [Route("getservices")]
        public Response GetServices()
        {
            Response response = new Response();
            try
            {
                List<ServiceMaster> services = new MasterRepository().GetServices(_db);
                if (services.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, services);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, services);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertservices")]
        public Response InsertServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertServices(_db, serviceMasters);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updateservices")]
        public Response UpdateServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateServices(_db, serviceMasters);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deleteservices")]
        public Response DeleteServices(ServiceMaster serviceMasters)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteServices(_db, serviceMasters);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Unit Of Sales
        [HttpGet]
        [Route("getunitofsales")]
        public Response GetUnitOfSales()
        {
            Response response = new Response();
            try
            {
                List<UnitOfSalesMaster> unitOfSales = new MasterRepository().GetUnitOfSales(_db);
                if (unitOfSales.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, unitOfSales);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, unitOfSales);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getunitofsalesbyid")]
        public Response GetUnitOfSalesByID([FromQuery] UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                List<UnitOfSalesMaster> unitOfSales = new MasterRepository().GetUnitOfSalesByID(_db, unitOfSalesMaster);
                if (unitOfSales.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, unitOfSales);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, unitOfSales);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertunitofsales")]
        public Response InsertUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertUnitOfSales(_db, unitOfSalesMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updateunitofsales")]
        public Response UpdateUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateUnitOfSales(_db, unitOfSalesMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deleteunitofsales")]
        public Response DeleteUnitOfSales(UnitOfSalesMaster unitOfSalesMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteUnitOfSales(_db, unitOfSalesMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Category
        [HttpGet]
        [Route("getcategory")]
        public Response GetCategories()
        {
            Response response = new Response();
            try
            {
                List<CategoryMaster> categoryMasters = new MasterRepository().GetCategories(_db);
                if (categoryMasters.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, categoryMasters);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, categoryMasters);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertcategory")]
        public Response InsertCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertCategory(_db, categoryMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updatecategory")]
        public Response UpdateCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateCategory(_db, categoryMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deletecategory")]
        public Response DeleteCategory(CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteCategory(_db, categoryMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Products
        [HttpGet]
        [Route("getproducts")]
        public Response GetProducts()
        {
            Response response = new Response();
            try
            {
                List<Products> productMaster = new MasterRepository().GetProducts(_db);
                if (productMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, productMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, productMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getserviceproducts")]
        public Response GetServiceProducts()
        {
            Response response = new Response();
            try
            {
                List<Products> productMaster = new MasterRepository().GetServiceProducts(_db);
                if (productMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, productMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, productMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getmainactivities")]
        public Response GetActivitiesForProduct()
        {
            Response response = new Response();
            try
            {
                List<ActivityMaster> mainActivities = new MasterRepository().GetMainActivities(_db);
                if (mainActivities.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, mainActivities);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, mainActivities);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getservicesbyroleid")]
        public Response GetServicesByRoleID([FromQuery] ActivityMaster activityMaster)
        {
            Response response = new Response();
            try
            {
                List<ServiceMaster> servicesByRoleID = new MasterRepository().GetServicesByRoleID(_db, activityMaster);
                if (servicesByRoleID.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, servicesByRoleID);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, servicesByRoleID);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getcategoriesbyserviceid")]
        public Response GetCategoriesByServiceID([FromQuery] Products products)
        {
            Response response = new Response();
            try
            {
                List<CategoryByService> categoriesByServiceID = new MasterRepository().GetCategoriesByServiceID(_db, products);
                if (categoriesByServiceID.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, categoriesByServiceID);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, categoriesByServiceID);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getunitbycategoryid")]
        public Response GetUnitByCategoryID([FromQuery] CategoryMaster categoryMaster)
        {
            Response response = new Response();
            try
            {
                List<UnitOfSalesMaster> unitByCategoryID = new MasterRepository().GetUnitByCategoryID(_db, categoryMaster);
                if (unitByCategoryID.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, unitByCategoryID);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, unitByCategoryID);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getproductsbycategoryid")]
        public Response GetProductsByCategoryID([FromQuery] Products products)
        {
            Response response = new Response();
            try
            {
                List<ProductsByCategory> productsByCategoryID = new MasterRepository().GetProductsByCategoryID(_db, products);
                if (productsByCategoryID.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, productsByCategoryID);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, productsByCategoryID);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getunitbyproductid")]
        public Response GetUnitByCategoryID([FromQuery] ProductMaster productMaster)
        {
            Response response = new Response();
            try
            {
                List<UnitOfSalesMaster> unitByProductID = new MasterRepository().GetUnitByProductID(_db, productMaster);
                if (unitByProductID.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, unitByProductID);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, unitByProductID);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertproduct")]
        public Response InsertProduct(ProductMaster productMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertProduct(_db, productMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updateproduct")]
        public Response UpdateProduct(ProductMaster productMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateProducts(_db, productMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Department
        [HttpGet]
        [Route("getdepartments")]
        public Response GetDepartments()
        {
            Response response = new Response();
            try
            {
                List<DepartmentMaster> departmentMaster = new MasterRepository().GetDepartments(_db);
                if (departmentMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, departmentMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, departmentMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertdepartment")]
        public Response InsertDepartment(DepartmentMaster departmentMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertDepartment(_db, departmentMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updatedepartment")]
        public Response UpdateDepartment(DepartmentMaster departmentMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateDepartment(_db, departmentMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deletedepartment")]
        public Response DeleteDepartment(DepartmentMaster departmentMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteDepartment(_db, departmentMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion

        #region Designation
        [HttpGet]
        [Route("getdesignations")]
        public Response GetDesignations()
        {
            Response response = new Response();
            try
            {
                List<DesignationMaster> designationMaster = new MasterRepository().GetDesignations(_db);
                if (designationMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, designationMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, designationMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertdesignation")]
        public Response InsertDesignation(DesignationMaster designationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().InsertDesignation(_db, designationMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("updatedesignation")]
        public Response UpdateDesignation(DesignationMaster designationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().UpdateDesignation(_db, designationMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("deletedesignation")]
        public Response DeleteDesignation(DesignationMaster designationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new MasterRepository().DeleteDesignation(_db, designationMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        #endregion
    }
}
