using DFAPI.Entities;
using DFAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly MasterRepository _repository = new MasterRepository();
        public MasterController(MasterRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("activityroles")]
        public Response GetActivityRoles()
        {
            Response objRes = new Response();
            List<ActivityRoles> activityRoles = _repository.GetActivityRoles();
            if (activityRoles.Count > 0)
            {
                objRes.Status = "Success";
                objRes.Message = "Success";
                objRes.Data = activityRoles;
            }
            else
            {
                objRes.Status = "No Data";
                objRes.Message = "No Data";
            }
            return objRes;
        }
    }
}
