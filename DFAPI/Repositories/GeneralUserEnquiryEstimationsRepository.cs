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
        #endregion
    }
}
