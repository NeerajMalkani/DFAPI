using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorCompanyProfileController : ControllerBase
    {
        private readonly DataContext _db;
        public ContractorCompanyProfileController(DataContext dbContext)
        {
            _db = dbContext;
        }

        #region My Services
        [HttpGet]
        [Route("getmyservices")]
        public Response GetContractorMyServices([FromQuery] ContractorServiceMapping contarctorServiceMapping)
        {
            Response response = new Response();
            try
            {
                List<ContractorServiceList> contractorServiceLists = new ContractorCompanyProfileRepository().GetContractorMyServices(_db, contarctorServiceMapping);
                if (contractorServiceLists.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, contractorServiceLists);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, contractorServiceLists);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertmyservices")]
        public Response InsertMyServices(ContractorServiceMapping contarctorServiceMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorCompanyProfileRepository().InsertContractorMyService(_db, contarctorServiceMapping);
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
        [Route("updatemyservices")]
        public Response UpdateMyServices(ContractorServiceMapping contarctorServiceMapping)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorCompanyProfileRepository().UpdateContractorMyService(_db, contarctorServiceMapping);
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


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
