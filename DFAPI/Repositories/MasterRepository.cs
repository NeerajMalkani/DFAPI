using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class MasterRepository
    {
        public List<ActivityRoles> GetActivityRoles(ActivityContext context)
        {
            List<ActivityRoles> activityRoles = context.ActivityRoles.FromSqlRaw("exec df_Get_ActivityRoles").ToList();
            return activityRoles;
        }
    }
}
