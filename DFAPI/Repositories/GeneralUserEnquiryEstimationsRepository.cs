using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Repositories
{
    public class GeneralUserEnquiryEstimationsRepository
    {
        #region Image Gallery
        public List<ImageGallery> GetImageGallery(DataContext context)
        {
            List<ImageGallery> imageGalleries = new List<ImageGallery>();
            try
            {
                imageGalleries = context.ImageGallery.FromSqlRaw("exec df_Get_ImageGallery").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return imageGalleries;
        }

        public List<ImageGallery> GetImageGalleryByCategoryID(DataContext context, ImageGalleryRequest imageGalleryRequest)
        {
            List<ImageGallery> imageGalleries = new List<ImageGallery>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@CategoryID", Value = imageGalleryRequest.CategoryID }
                };
                imageGalleries = context.ImageGallery.FromSqlRaw("exec df_Get_ImageGalleryByCategory @CategoryID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return imageGalleries;
        }

        public List<UserEstimationEnquiriesGet> GetUserEstimationEnquiries(DataContext context, UserDesignEstimation userDesignEstimation)
        {
            List<UserEstimationEnquiriesGet> userEstimationEnquiriesGet = new List<UserEstimationEnquiriesGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@UserDesignEstimationID", Value = userDesignEstimation.UserDesignEstimationID }
                };
                userEstimationEnquiriesGet = context.UserEstimationEnquiriesGet.FromSqlRaw("exec df_Get_DesignEstimation @UserDesignEstimationID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userEstimationEnquiriesGet;
        }

        public List<UserAllEstimationGet> GetUserAllEstimation(DataContext context, UserEstimationEnquiries userEstimationEnquiries)
        {
            List<UserAllEstimationGet> userAllEstimationGet = new List<UserAllEstimationGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@UserID", Value = userEstimationEnquiries.UserID }
                };
                userAllEstimationGet = context.UserAllEstimationGet.FromSqlRaw("exec df_Get_DesignEstimationsForUser @UserID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userAllEstimationGet;
        }

        public long InsertUpdateUserEstimationEnquiries(DataContext context, UserEstimationEnquiries userEstimationEnquiries)
        {
            List<UserEstimationEnquiries> userEstimationEnquiriesMain = new List<UserEstimationEnquiries>();
            long rowsAffected = 0;
            try
            {
                userEstimationEnquiriesMain = context.UserEstimationEnquiries.Where(b => b.ID == userEstimationEnquiries.ID).ToList();
                if (userEstimationEnquiriesMain.Any())
                {
                    if (userEstimationEnquiries.Status != null)
                    {
                        userEstimationEnquiriesMain.First().Status = userEstimationEnquiries.Status;
                    }
                    if (userEstimationEnquiries.SubtotalAmount != null && userEstimationEnquiries.SubtotalAmount != 0)
                    {
                        userEstimationEnquiriesMain.First().SubtotalAmount = userEstimationEnquiries.SubtotalAmount;
                    }
                    if (userEstimationEnquiries.LabourCost != null && userEstimationEnquiries.LabourCost != 0)
                    {
                        userEstimationEnquiriesMain.First().LabourCost = userEstimationEnquiries.LabourCost;
                    }
                    if (userEstimationEnquiries.TotalAmount != null && userEstimationEnquiries.TotalAmount != 0)
                    {
                        userEstimationEnquiriesMain.First().TotalAmount = userEstimationEnquiries.TotalAmount;
                    }
                    if (userEstimationEnquiries.ClientID != null && userEstimationEnquiries.ClientID != 0)
                    {
                        userEstimationEnquiriesMain.First().ClientID = userEstimationEnquiries.ClientID;
                    }
                    if (userEstimationEnquiries.ApprovalStatus != null)
                    {
                        userEstimationEnquiriesMain.First().ApprovalStatus = userEstimationEnquiries.ApprovalStatus;
                    }
                    context.UserEstimationEnquiries.Update(userEstimationEnquiriesMain.First());
                    context.SaveChanges();
                    rowsAffected = userEstimationEnquiries.ID;
                }
                else
                {
                    context.UserEstimationEnquiries.Add(userEstimationEnquiries);
                    context.SaveChanges();
                    rowsAffected = userEstimationEnquiries.ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public List<UserEstimationEnquiriesForMaterialSetup> GetUserEstimationEnquiriesForMaterialSetup(DataContext context, UserEstimationEnquiriesForMaterialSetup userEstimationEnquiriesForMaterialSetup)
        {
            List<UserEstimationEnquiriesForMaterialSetup> userEstimationEnquiriesForMaterialSetups = new List<UserEstimationEnquiriesForMaterialSetup>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@MaterialSetupID", Value = userEstimationEnquiriesForMaterialSetup.MaterialSetupID }
                };
                userEstimationEnquiriesForMaterialSetups = context.UserEstimationEnquiriesForMaterialSetup.FromSqlRaw("exec df_Get_DesignEstimationForMaterialSetup @MaterialSetupID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userEstimationEnquiriesForMaterialSetups;
        }
        #endregion
    }
}
