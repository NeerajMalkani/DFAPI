using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class MasterRepository
    {
        private readonly ActivityContext context;

        public MasterRepository(ActivityContext context)
        {
            this.context = context;
        }

        public List<ActivityRoles> GetActivityRoles()
        {
            List<ActivityRoles> activityRoles = context.ActivityRoles.FromSqlRaw("exec sp_GetUsers").ToList();
            return activityRoles;
        }
    }
}
