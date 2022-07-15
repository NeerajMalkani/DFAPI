using DFAPI.Entities;
using DFAPI.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DFAPI.Repositories
{
    public class ServiceCatalogueRepository
    {
        #region Work Floor
        public List<WorkFloorMaster> GetWorkFloors(DataContext context)
        {
            List<WorkFloorMaster> workFloorMaster = new List<WorkFloorMaster>();
            try
            {
                workFloorMaster = context.WorkFloorMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return workFloorMaster;
        }

        public long InsertWorkFloor(DataContext context, WorkFloorMaster workFloorMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkFloorMaster.Add(workFloorMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateWorkFloor(DataContext context, WorkFloorMaster workFloorMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkFloorMaster.Update(workFloorMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteWorkFloor(DataContext context, WorkFloorMaster workFloorMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkFloorMaster.Remove(workFloorMaster);
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

        #region Work Location
        public List<WorkLocationMaster> GetWorkLocations(DataContext context)
        {
            List<WorkLocationMaster> workLocationMaster = new List<WorkLocationMaster>();
            try
            {
                workLocationMaster = context.WorkLocationMaster.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return workLocationMaster;
        }

        public long InsertWorkLocation(DataContext context, WorkLocationMaster workLocationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkLocationMaster.Add(workLocationMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateWorkLocation(DataContext context, WorkLocationMaster workLocationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkLocationMaster.Update(workLocationMaster);
                context.SaveChanges();
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long DeleteWorkLocation(DataContext context, WorkLocationMaster workLocationMaster)
        {
            long rowsAffected = 0;
            try
            {
                context.WorkLocationMaster.Remove(workLocationMaster);
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

        #region DesignType
        public List<DesignType> GetDesignTypes(DataContext context)
        {
            List<DesignType> designTypes = new List<DesignType>();
            try
            {
                designTypes = context.DesignType.FromSqlRaw("exec df_Get_DesignTypes").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return designTypes;
        }

        public List<DesignTypeByProductID> GetDesignTypeByProductID(DataContext context, DesignTypeMaster designTypeMaster)
        {
            List<DesignTypeByProductID> designTypeMasters = new List<DesignTypeByProductID>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ServiceID", Value = designTypeMaster.ServiceID },
                new SqlParameter { ParameterName = "@CategoryID", Value = designTypeMaster.CategoryID },
                new SqlParameter { ParameterName = "@ProductID", Value = designTypeMaster.ProductID }
                };
                designTypeMasters = context.DesignTypeByProductID.FromSqlRaw("exec df_Get_DesignTypsByProductID @ServiceID, @CategoryID, @ProductID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return designTypeMasters;
        }

        public long InsertDesignType(DataContext context, DesignTypeMaster designTypeMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@DesignTypeName", Value = designTypeMaster.DesignTypeName },
                    new SqlParameter { ParameterName = "@ServiceID", Value = designTypeMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = designTypeMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = designTypeMaster.ProductID },
                    new SqlParameter { ParameterName = "@Display", Value = designTypeMaster.Display },
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_DesignType @DesignTypeName, @ServiceID, @CategoryID, @ProductID, @Display", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateDesignType(DataContext context, DesignTypeMaster designTypeMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = designTypeMaster.ID },
                    new SqlParameter { ParameterName = "@DesignTypeName", Value = designTypeMaster.DesignTypeName },
                    new SqlParameter { ParameterName = "@ServiceID", Value = designTypeMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = designTypeMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = designTypeMaster.ProductID },
                    new SqlParameter { ParameterName = "@Display", Value = designTypeMaster.Display },
                };
                context.Database.ExecuteSqlRaw("exec df_Update_DesignType @ID, @DesignTypeName, @ServiceID, @CategoryID, @ProductID, @Display", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }
        #endregion

        #region Post New Design
        public List<PostNewDesign> GetPostNewDesigns(DataContext context)
        {
            List<PostNewDesign> postNewDesigns = new List<PostNewDesign>();
            try
            {
                postNewDesigns = context.PostNewDesign.FromSqlRaw("exec df_Get_PostNewDesigns").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return postNewDesigns;
        }

        public long InsertPostNewDesign(DataContext context, PostNewDesignMaster postNewDesignMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@LabourCost", Value = postNewDesignMaster.LabourCost },
                    new SqlParameter { ParameterName = "@ServiceID", Value = postNewDesignMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = postNewDesignMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = postNewDesignMaster.ProductID },
                    new SqlParameter { ParameterName = "@DesignTypeID", Value = postNewDesignMaster.DesignTypeID },
                    new SqlParameter { ParameterName = "@WorkLocationID", Value = postNewDesignMaster.WorkLocationID },
                    new SqlParameter { ParameterName = "@DesignNumber", Value = postNewDesignMaster.DesignNumber },
                    new SqlParameter { ParameterName = "@DesignImage", Value = postNewDesignMaster.DesignImage },
                    new SqlParameter { ParameterName = "@Display", Value = postNewDesignMaster.Display },
                };
                context.Database.ExecuteSqlRaw("exec df_Insert_PostNewDesign @LabourCost, @ServiceID, @CategoryID, @ProductID, @DesignTypeID, @WorkLocationID, @DesignNumber, @DesignImage, @Display", parms.ToArray());
                rowsAffected = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdatePostNewDesign(DataContext context, PostNewDesignMaster postNewDesignMaster)
        {
            long rowsAffected = 0;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = postNewDesignMaster.ID },
                    new SqlParameter { ParameterName = "@LabourCost", Value = postNewDesignMaster.LabourCost },
                    new SqlParameter { ParameterName = "@ServiceID", Value = postNewDesignMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = postNewDesignMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = postNewDesignMaster.ProductID },
                    new SqlParameter { ParameterName = "@DesignTypeID", Value = postNewDesignMaster.DesignTypeID },
                    new SqlParameter { ParameterName = "@WorkLocationID", Value = postNewDesignMaster.WorkLocationID },
                    new SqlParameter { ParameterName = "@DesignNumber", Value = postNewDesignMaster.DesignNumber },
                    new SqlParameter { ParameterName = "@DesignImage", Value = postNewDesignMaster.DesignImage },
                    new SqlParameter { ParameterName = "@Display", Value = postNewDesignMaster.Display },
                };
                context.Database.ExecuteSqlRaw("exec df_Update_PostNewDesign @ID, @LabourCost, @ServiceID, @CategoryID, @ProductID, @DesignTypeID, @WorkLocationID, @DesignNumber, @DesignImage, @Display", parms.ToArray());
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
