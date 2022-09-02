using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DFAPI.Repositories
{
    public class ContractorQuotationEstimationRepository
    {

        public List<ClientGet> GetClients(DataContext context, ClientMaster clientMaster)
        {
            List<ClientGet> clientGet = new List<ClientGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@AddedByUserID", Value = clientMaster.AddedByUserID }
                };
                clientGet = context.ClientGet.FromSqlRaw("exec df_Get_Clients @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return clientGet;
        }

        public List<ClientGet> GetOtherClients(DataContext context, ClientMaster clientMaster)
        {
            List<ClientGet> clientGet = new List<ClientGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@AddedByUserID", Value = clientMaster.AddedByUserID }
                };
                clientGet = context.ClientGet.FromSqlRaw("exec df_Get_OtherClients @AddedByUserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return clientGet;
        }

        public long InsertClient(DataContext context, Client client)
        {
            List<Client> categoryMastersMain = new List<Client>();
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = client.AddedByUserID, SqlDbType = SqlDbType.BigInt },
                    new SqlParameter { ParameterName = "@CompanyName", Value = client.CompanyName, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ContactPerson", Value = client.ContactPerson, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ContactMobileNumber", Value = client.ContactMobileNumber, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@Address1", Value = client.Address1, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@StateID", Value = client.StateID, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@CityID", Value = client.CityID, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@Pincode", Value = client.Pincode, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@GSTNumber", Value = client.GSTNumber, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@PAN", Value = client.PAN, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ServiceType", Value = client.ServiceType, SqlDbType = SqlDbType.TinyInt },
                    new SqlParameter { ParameterName = "@Display", Value = client.Display, SqlDbType = SqlDbType.Bit },
                    new SqlParameter { ParameterName = "@Status", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.TinyInt }
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_Client @AddedByUserID, @CompanyName, @ContactPerson, @ContactMobileNumber, @Address1, @StateID, @CityID, @Pincode, @GSTNumber, @PAN, @ServiceType, @Display, @Status out", parms.ToArray());
                if (Convert.ToInt16(parms[12].Value) == 1)
                {
                    rowsAffected = 1;
                }
                else if (Convert.ToInt16(parms[12].Value) == 2)
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

        public long InsertOtherClient(DataContext context, Client client)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ClientID", Value = client.ID, SqlDbType = SqlDbType.BigInt },
                    new SqlParameter { ParameterName = "@AddedByUserID", Value = client.AddedByUserID, SqlDbType = SqlDbType.BigInt },
                    new SqlParameter { ParameterName = "@Status", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.TinyInt }
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_OtherClient @ClientID, @AddedByUserID, @Status out", parms.ToArray());
                if (Convert.ToInt16(parms[2].Value) == 1)
                {
                    rowsAffected = 1;
                }
                else if (Convert.ToInt16(parms[2].Value) == 2)
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

        public long InsertApprovedEstimation(DataContext context, ApprovedEstimations approvedEstimationsParams)
        {
            List<ApprovedEstimations> approvedEstimations = new List<ApprovedEstimations>();
            long rowsAffected = 0;
            try
            {
                approvedEstimations = context.ApprovedEstimations.Where(b => b.ID == approvedEstimationsParams.ID).ToList();
                if (!approvedEstimations.Any())
                {
                    context.ApprovedEstimations.Add(approvedEstimationsParams);
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

        public long UpdateClient(DataContext context, Client client)
        {
            List<Client> categoryMastersMain = new List<Client>();
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = client.ID, SqlDbType = SqlDbType.BigInt },
                    new SqlParameter { ParameterName = "@CompanyName", Value = client.CompanyName, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ContactPerson", Value = client.ContactPerson, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ContactMobileNumber", Value = client.ContactMobileNumber, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@Address1", Value = client.Address1, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@StateID", Value = client.StateID, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@CityID", Value = client.CityID, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@Pincode", Value = client.Pincode, SqlDbType = SqlDbType.Int },
                    new SqlParameter { ParameterName = "@GSTNumber", Value = client.GSTNumber, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@PAN", Value = client.PAN, SqlDbType = SqlDbType.VarChar },
                    new SqlParameter { ParameterName = "@ServiceType", Value = client.ServiceType, SqlDbType = SqlDbType.TinyInt },
                    new SqlParameter { ParameterName = "@Display", Value = client.Display, SqlDbType = SqlDbType.Bit },
                    new SqlParameter { ParameterName = "@Status", Direction = ParameterDirection.Output, SqlDbType = SqlDbType.TinyInt }
                };
                context.Database.ExecuteSqlRaw("exec df_Update_Client @ID, @CompanyName, @ContactPerson, @ContactMobileNumber, @Address1, @StateID, @CityID, @Pincode, @GSTNumber, @PAN, @ServiceType, @Display, @Status out", parms.ToArray());
                if (Convert.ToInt16(parms[12].Value) == 1)
                {
                    rowsAffected = 1;
                }
                else if (Convert.ToInt16(parms[12].Value) == 2)
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

        public List<ContractorAllEstimationGet> GetContractorAllEstimation(DataContext context, UserEstimationEnquiries userEstimationEnquiries)
        {
            List<ContractorAllEstimationGet> userAllEstimationGet = new List<ContractorAllEstimationGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@UserID", Value = userEstimationEnquiries.UserID }
                };
                userAllEstimationGet = context.ContractorAllEstimationGet.FromSqlRaw("exec df_Get_DesignEstimationsForContractor @UserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userAllEstimationGet;
        }
    }
}
