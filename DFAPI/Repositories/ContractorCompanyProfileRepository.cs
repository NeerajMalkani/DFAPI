using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class ContractorCompanyProfileRepository
    {
        #region My Services
        public List<ContractorServiceList> GetContractorMyServices(DataContext context, ContractorServiceMapping contractorServiceMapping)
        {
            List<ContractorServiceList> contractorServiceLists = new List<ContractorServiceList>(); 
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ContractorID", Value = contractorServiceMapping.ContractorID },
                };
                contractorServiceLists = context.ContractorServiceList.FromSqlRaw("exec df_Get_ContractorServices @ContractorID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contractorServiceLists;
        }

        public long InsertContractorMyService(DataContext context, ContractorServiceMapping contractorServiceMapping)
        {
            List<ContractorServiceMapping> contractorServiceMappingMain = new List<ContractorServiceMapping>();
            long rowsAffected = 0;
            try
            {
                contractorServiceMappingMain = context.ContractorServiceMapping.Where(b => b.ContractorID == contractorServiceMapping.ContractorID && b.ServiceID == contractorServiceMapping.ServiceID).ToList();
                if (!contractorServiceMappingMain.Any())
                {
                    context.ContractorServiceMapping.Add(contractorServiceMapping);
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

        public long UpdateContractorMyService(DataContext context, ContractorServiceMapping contractorServiceMapping)
        {
            List<ContractorServiceMapping> contractorServiceMappingMain = new List<ContractorServiceMapping>();
            long rowsAffected = 0;
            try
            {
                contractorServiceMappingMain = context.ContractorServiceMapping.Where(b => b.ContractorID == contractorServiceMapping.ContractorID && b.ServiceID == contractorServiceMapping.ServiceID && b.ID != contractorServiceMapping.ID).ToList();
                if (!contractorServiceMappingMain.Any())
                {
                    context.ContractorServiceMapping.Update(contractorServiceMapping);
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
