using DFAPI.Entities;
using DFAPI.Helpers;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorQuotationEstimationController : ControllerBase
    {
        private readonly DataContext _db;

        public ContractorQuotationEstimationController(DataContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        [Route("getclients")]
        public Response GetClients([FromQuery] ClientMaster clientMaster)
        {
            Response response = new Response();
            try
            {
                List<ClientGet> clientGet = new ContractorQuotationEstimationRepository().GetClients(_db, clientMaster);
                if (clientGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, clientGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, clientGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpGet]
        [Route("getotherclients")]
        public Response GetOtherClients([FromQuery] ClientMaster clientMaster)
        {
            Response response = new Response();
            try
            {
                List<ClientGet> clientGet = new ContractorQuotationEstimationRepository().GetOtherClients(_db, clientMaster);
                if (clientGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, clientGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, clientGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }

        [HttpPost]
        [Route("insertclient")]
        public Response InsertClient(Client client)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorQuotationEstimationRepository().InsertClient(_db, client);
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
        [Route("insertotherclient")]
        public Response InsertOtherClient(Client client)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorQuotationEstimationRepository().InsertOtherClient(_db, client);
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
        [Route("insertapprovedestimations")]
        public Response InsertApprovedEstimations(ApprovedEstimations approvedEstimations)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorQuotationEstimationRepository().InsertApprovedEstimation(_db, approvedEstimations);
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
        [Route("updateclient")]
        public Response UpdateClient(Client client)
        {
            Response response = new Response();
            try
            {
                long rowsAffected = new ContractorQuotationEstimationRepository().UpdateClient(_db, client);
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

        [HttpGet]
        [Route("getcontractorallestimation")]
        public Response GetContractorAllEstimation([FromQuery] UserEstimationEnquiries userEstimationEnquiries)
        {
            Response response = new Response();
            try
            {
                List<ContractorAllEstimationGet> contractorAllEstimationGet = new ContractorQuotationEstimationRepository().GetContractorAllEstimation(_db, userEstimationEnquiries);
                if (contractorAllEstimationGet.Any())
                {
                    Common.CreateResponse(HttpStatusCode.OK, "Success", "Success", out response, contractorAllEstimationGet);
                }
                else
                {
                    Common.CreateResponse(HttpStatusCode.NoContent, "Success", "No data", out response, contractorAllEstimationGet);
                }
            }
            catch (Exception ex)
            {
                Common.CreateErrorResponse(HttpStatusCode.BadRequest, out response, ex);
            }
            return response;
        }
    }
}
