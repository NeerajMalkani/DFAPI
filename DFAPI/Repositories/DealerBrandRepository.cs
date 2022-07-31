using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class DealerBrandRepository
    { 
        #region Brand Master
        public List<BrandMaster> GetBrand(DataContext context, BrandMaster brandMasterParam)
        {
            List<BrandMaster> brandMaster = new List<BrandMaster>();
            try
            {
                brandMaster = context.BrandMaster.Where(el => el.DealerID == brandMasterParam.DealerID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return brandMaster;
        }

        public long InsertBrand(DataContext context, BrandMaster brandMaster)
        {
            List<BrandMaster> brandMasterMain = new List<BrandMaster>();
            long rowsAffected = 0;
            try
            {
                brandMasterMain = context.BrandMaster.Where(b => b.BrandName == brandMaster.BrandName).ToList();
                if (!brandMasterMain.Any())
                {
                    context.BrandMaster.Add(brandMaster);
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

        public long UpdateBrand(DataContext context, BrandMaster brandMaster)
        {
            List<BrandMaster> brandMasterMain = new List<BrandMaster>();
            long rowsAffected = 0;
            try
            {
                brandMasterMain = context.BrandMaster.Where(b => (b.BrandName == brandMaster.BrandName && b.ID != brandMaster.ID)).ToList();
                if (!brandMasterMain.Any())
                {
                    context.BrandMaster.Update(brandMaster);
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

        public long DeleteBrand(DataContext context, BrandMaster brandMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.BrandMaster.Remove(brandMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Brand Setup
        public List<DealerBrandResponse> GetBrandSetup(DataContext context, DealerBrands dealerBrands)
        {
            List<DealerBrandResponse> dealerBrandResponse = new List<DealerBrandResponse>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@DealerID", Value = dealerBrands.DealerID }
                };
                dealerBrandResponse = context.DealerBrandResponse.FromSqlRaw("exec df_Get_DealerBrands @DealerID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return dealerBrandResponse;
        }

        public long InsertBrandSetup(DataContext context, DealerBrands dealerBrandsParam)
        {
            List<DealerBrands> dealerBrands = new List<DealerBrands>();
            long rowsAffected = 0;
            try
            {
                dealerBrands = context.DealerBrands.Where(b => b.BrandID == dealerBrandsParam.BrandID).ToList();
                if (!dealerBrands.Any())
                {
                    context.DealerBrands.Add(dealerBrandsParam);
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

        public long UpdateBrandSetup(DataContext context, DealerBrands dealerBrandsParam)
        {
            List<DealerBrands> dealerBrands = new List<DealerBrands>();
            long rowsAffected = 0;
            try
            {
                dealerBrands = context.DealerBrands.Where(b => b.BrandID == dealerBrandsParam.BrandID && b.ID != dealerBrandsParam.ID).ToList();
                if (!dealerBrands.Any())
                {
                    context.DealerBrands.Update(dealerBrandsParam);
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

        #region Buyer Category
        public List<BuyerCategoryMaster> GetBuyerCategory(DataContext context, BuyerCategoryMaster buyerCategoryMasterParam)
        {
            List<BuyerCategoryMaster> buyerCategoryMaster = new List<BuyerCategoryMaster>();
            try
            {
                buyerCategoryMaster = context.BuyerCategoryMaster.Where(el => el.DealerID == buyerCategoryMasterParam.DealerID).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return buyerCategoryMaster;
        }

        public long InsertBuyerCategory(DataContext context, BuyerCategoryMaster buyerCategoryMaster)
        {
            List<BuyerCategoryMaster> buyerCategoryMasterMain = new List<BuyerCategoryMaster>();
            long rowsAffected = 0;
            try
            {
                buyerCategoryMasterMain = context.BuyerCategoryMaster.Where(b => b.BuyerCategoryName == buyerCategoryMaster.BuyerCategoryName).ToList();
                if (!buyerCategoryMasterMain.Any())
                {
                    context.BuyerCategoryMaster.Add(buyerCategoryMaster);
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

        public long UpdateBuyerCategory(DataContext context, BuyerCategoryMaster buyerCategoryMaster)
        {
            List<BuyerCategoryMaster> buyerCategoryMasterMain = new List<BuyerCategoryMaster>();
            long rowsAffected = 0;
            try
            {
                buyerCategoryMasterMain = context.BuyerCategoryMaster.Where(b => (b.BuyerCategoryName == buyerCategoryMaster.BuyerCategoryName && b.ID != buyerCategoryMaster.ID)).ToList();
                if (!buyerCategoryMasterMain.Any())
                {
                    context.BuyerCategoryMaster.Update(buyerCategoryMaster);
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

        public long DeleteBuyerCategory(DataContext context, BuyerCategoryMaster buyerCategoryMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.BuyerCategoryMaster.Remove(buyerCategoryMaster);
                context.SaveChanges();
                rowsAffected = 1;
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
