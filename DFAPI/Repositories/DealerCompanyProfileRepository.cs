using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class DealerCompanyProfileRepository
    {
        #region My Services
        public List<DealerServiceList> GetDealerMyService(DataContext context, DealerServiceMapping dealerServiceMapping)
        {
            List<DealerServiceList> dealerServiceLists = new List<DealerServiceList>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@DealerID", Value = dealerServiceMapping.DealerID },
                };
                dealerServiceLists = context.DealerServiceList.FromSqlRaw("exec df_Get_DealerServices @DealerID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return dealerServiceLists;
        }

        public long InsertDealerMyService(DataContext context, DealerServiceMapping dealerServiceMapping)
        {
            List<DealerServiceMapping> dealerServiceMappingMain = new List<DealerServiceMapping>();
            long rowsAffected = 0;
            try
            {
                dealerServiceMappingMain = context.DealerServiceMapping.Where(b => b.DealerID == dealerServiceMapping.DealerID && b.ServiceID == dealerServiceMapping.ServiceID).ToList();
                if (!dealerServiceMappingMain.Any())
                {
                    context.DealerServiceMapping.Add(dealerServiceMapping);
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

        public long UpdateDealerMyService(DataContext context, DealerServiceMapping dealerServiceMapping)
        {
            List<DealerServiceMapping> dealerServiceMappingMain = new List<DealerServiceMapping>();
            long rowsAffected = 0;
            try
            {
                dealerServiceMappingMain = context.DealerServiceMapping.Where(b => b.DealerID == dealerServiceMapping.DealerID && b.ServiceID == dealerServiceMapping.ServiceID && b.ID != dealerServiceMapping.ID).ToList();
                if (!dealerServiceMappingMain.Any())
                {
                    context.DealerServiceMapping.Update(dealerServiceMapping);
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
    }
}
