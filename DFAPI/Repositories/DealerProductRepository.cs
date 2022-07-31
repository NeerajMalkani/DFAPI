using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class DealerProductRepository
    {
        #region Product
        public List<DealerProduct> GetProducts(DataContext context, DealerProductMapping dealerProductMapping)
        {
            List<DealerProduct> dealerProduct = new List<DealerProduct>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@DealerID", Value = dealerProductMapping.DealerID }
                };
                dealerProduct = context.DealerProduct.FromSqlRaw("exec df_Get_DealerProducts @DealerID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return dealerProduct;
        }

        public long InsertProduct(DataContext context, DealerProductMapping dealerProductMappingParams)
        {
            List<DealerProductMapping> dealerProductMapping = new List<DealerProductMapping>();
            long rowsAffected = 0;
            try
            {
                dealerProductMapping = context.DealerProductMapping.Where(b => b.ProductID == dealerProductMappingParams.ProductID).ToList();
                if (!dealerProductMapping.Any())
                {
                    context.DealerProductMapping.Add(dealerProductMappingParams);
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

        public long UpdateProduct(DataContext context, DealerProductMapping dealerProductMappingParams)
        {
            List<DealerProductMapping> dealerProductMapping = new List<DealerProductMapping>();
            long rowsAffected = 0;
            try
            {
                dealerProductMapping = context.DealerProductMapping.Where(b => b.BrandID == dealerProductMappingParams.ProductID && b.ID != dealerProductMappingParams.ID).ToList();
                if (!dealerProductMapping.Any())
                {
                    context.DealerProductMapping.Update(dealerProductMappingParams);
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
