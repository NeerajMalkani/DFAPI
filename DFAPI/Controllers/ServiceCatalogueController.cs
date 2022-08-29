using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCatalogueController : ControllerBase
    {
        private readonly DataContext _db;

        public ServiceCatalogueController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region Work Floor
        [HttpGet]
        [Route("getworkfloors")]
        public Response GetWorkFloors()
        {
            Response response = new Response();
            try
            {
                List<WorkFloorMaster> workFloorMaster = new ServiceCatalogueRepository().GetWorkFloors(_db);
                if (workFloorMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, workFloorMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, workFloorMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertworkfloor")]
        public Response InsertWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertWorkFloor(_db, workFloorMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("updateworkfloor")]
        public Response UpdateWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateWorkFloor(_db, workFloorMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("deleteworkfloor")]
        public Response DeleteWorkFloor(WorkFloorMaster workFloorMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().DeleteWorkFloor(_db, workFloorMaster);
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

        #region Work Location
        [HttpGet]
        [Route("getworklocations")]
        public Response GetWorkLocations()
        {
            Response response = new Response();
            try
            {
                List<WorkLocationMaster> workLocationMaster = new ServiceCatalogueRepository().GetWorkLocations(_db);
                if (workLocationMaster.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, workLocationMaster);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, workLocationMaster);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertworklocation")]
        public Response InsertWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertWorkLocation(_db, workLocationMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("updateworklocation")]
        public Response UpdateWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateWorkLocation(_db, workLocationMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("deleteworklocation")]
        public Response DeleteWorkLocation(WorkLocationMaster workLocationMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().DeleteWorkLocation(_db, workLocationMaster);
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

        #region Design Type
        [HttpGet]
        [Route("getdesigntypes")]
        public Response GetDesignTypes()
        {
            Response response = new Response();
            try
            {
                List<DesignType> designTypes = new ServiceCatalogueRepository().GetDesignTypes(_db);
                if (designTypes.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, designTypes);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, designTypes);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getdesigntypebyproductid")]
        public Response GetDesignTypeByProductID([FromQuery] DesignTypeMaster designTypeMaster)
        {
            Response response = new Response();
            try
            {
                List<DesignTypeByProductID> designTypes = new ServiceCatalogueRepository().GetDesignTypeByProductID(_db, designTypeMaster);
                if (designTypes.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, designTypes);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, designTypes);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getdesigntypebyproductidformaterialsetup")]
        public Response GetDesignTypeByProductIDForMaterialSetup([FromQuery] DesignTypeMaster designTypeMaster)
        {
            Response response = new Response();
            try
            {
                List<DesignTypeByProductID> designTypes = new ServiceCatalogueRepository().GetDesignTypeByProductIDForMaterialSetup(_db, designTypeMaster);
                if (designTypes.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, designTypes);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, designTypes);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertdesigntype")]
        public Response InsertDesignType(DesignTypeMaster designTypeMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertDesignType(_db, designTypeMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("updatedesigntype")]
        public Response UpdateDesignType(DesignTypeMaster designTypeMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateDesignType(_db, designTypeMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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

        #region Material Setup
        [HttpGet]
        [Route("getproductsbyproductids")]
        public Response GetProductsByProductID([FromQuery] ProductsRequest productsRequest)
        {
            Response response = new Response();
            try
            {
                List<ProductsByProductID> productsByProductIDs = new ServiceCatalogueRepository().GetProductsByProductID(_db, productsRequest);
                if (productsByProductIDs.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, productsByProductIDs);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, productsByProductIDs);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX TBR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        [HttpGet]
        [Route("getproductsbybrandproductids")]
        public Response GetProductsByBrandProductID([FromQuery] ProductBarndRequest productBarndRequest)
        {
            Response response = new Response();
            try
            {
                List<ProductsByProductID> productsByProductIDs = new ServiceCatalogueRepository().GetProductsByBrandProductID(_db, productBarndRequest);
                if (productsByProductIDs.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, productsByProductIDs);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, productsByProductIDs);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX TBR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        [HttpGet]
        [Route("getbrandsbyproductids")]
        public Response GetBrandsByProductID([FromQuery] ProductsRequest productsRequest)
        {
            Response response = new Response();
            try
            {
                List<BrandsByProductID> brandsByProductIDs = new ServiceCatalogueRepository().GetBrandsByProductID(_db, productsRequest);
                if (brandsByProductIDs.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, brandsByProductIDs);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, brandsByProductIDs);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getmaterialsetup")]
        public Response GetMaterialSetup()
        {
            Response response = new Response();
            try
            {
                List<MaterialSetupMasterGet> materialSetupMasterGet = new ServiceCatalogueRepository().GetMaterialSetup(_db);
                if (materialSetupMasterGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, materialSetupMasterGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, materialSetupMasterGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getmaterialsetupmapping")]
        public Response GetMaterialSetupMapping([FromQuery] MaterialProductMapping materialProductMapping)
        {
            Response response = new Response();
            try
            {
                List<MaterialProductMappingGet> materialProductMappingGet = new ServiceCatalogueRepository().GetMaterialProductMapping(_db, materialProductMapping);
                if (materialProductMappingGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, materialProductMappingGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, materialProductMappingGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertmaterialsetup")]
        public Response InsertMaterialSetup(MaterialSetupRequest materialSetupRequest)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertMaterialSetup(_db, materialSetupRequest);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("updatematerialsetup")]
        public Response UpdateMaterialSetup(MaterialSetupRequest materialSetupRequest)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdateMaterialSetup(_db, materialSetupRequest);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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

        #region Post New Design
        [HttpGet]
        [Route("getpostnewdesigntypes")]
        public Response GetPostNewDesignTypes()
        {
            Response response = new Response();
            try
            {
                List<PostNewDesign> postNewDesigns = new ServiceCatalogueRepository().GetPostNewDesigns(_db);
                if (postNewDesigns.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, postNewDesigns);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, postNewDesigns);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertpostnewdesigntype")]
        public Response InsertPostNewDesignType(PostNewDesignMaster postNewDesignMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().InsertPostNewDesign(_db, postNewDesignMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
        [Route("updatepostnewdesigntype")]
        public Response UpdatePostNewDesignType(PostNewDesignMaster postNewDesignMaster)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ServiceCatalogueRepository().UpdatePostNewDesign(_db, postNewDesignMaster);
                if (rowsAffected > 0)
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response);
                }
                else if (rowsAffected == -2)
                {
                    Common.CreateResponse(HttpStatusCode.NotModified, "Error", "Name already exists", out response);
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
