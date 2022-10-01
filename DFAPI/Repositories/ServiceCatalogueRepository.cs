using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
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
            List<WorkFloorMaster> objWorkFloor = new List<WorkFloorMaster>();
            long rowsAffected = 0;
            try
            {
                objWorkFloor = context.WorkFloorMaster.Where(b => b.WorkFloorName == workFloorMaster.WorkFloorName).ToList();
                if (!objWorkFloor.Any())
                {
                    context.WorkFloorMaster.Add(workFloorMaster);
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

        public long UpdateWorkFloor(DataContext context, WorkFloorMaster workFloorMaster)
        {
            List<WorkFloorMaster> objWorkFloor = new List<WorkFloorMaster>();
            long rowsAffected = 0;
            try
            {
                objWorkFloor = context.WorkFloorMaster.Where(b => (b.WorkFloorName == workFloorMaster.WorkFloorName && b.ID != workFloorMaster.ID)).ToList();
                if (!objWorkFloor.Any())
                {
                    context.WorkFloorMaster.Update(workFloorMaster);
                    context.SaveChanges();
                    rowsAffected = 1;
                }
                else
                {
                    rowsAffected &= -2;
                }
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
            List<WorkLocationMaster> objWorkLocation = new List<WorkLocationMaster>();
            long rowsAffected = 0;
            try
            {
                objWorkLocation = context.WorkLocationMaster.Where(b => b.WorkLocationName == workLocationMaster.WorkLocationName).ToList();
                if (!objWorkLocation.Any())
                {
                    context.WorkLocationMaster.Add(workLocationMaster);
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

        public long UpdateWorkLocation(DataContext context, WorkLocationMaster workLocationMaster)
        {
            List<WorkLocationMaster> objWorkLocation = new List<WorkLocationMaster>();
            long rowsAffected = 0;
            try
            {
                objWorkLocation = context.WorkLocationMaster.Where(b => (b.WorkLocationName == workLocationMaster.WorkLocationName && b.ID != workLocationMaster.ID)).ToList();
                if (!objWorkLocation.Any())
                {
                    context.WorkLocationMaster.Update(workLocationMaster);
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

        public List<DesignTypeByProductID> GetDesignTypeByProductIDForMaterialSetup(DataContext context, DesignTypeMaster designTypeMaster)
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
                designTypeMasters = context.DesignTypeByProductID.FromSqlRaw("exec df_Get_DesignTypeByProductIDForMaterialSetup @ServiceID, @CategoryID, @ProductID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return designTypeMasters;
        }

        public long InsertDesignType(DataContext context, DesignTypeMaster designTypeMaster)
        {
            List<DesignTypeMaster> objDesignType = new List<DesignTypeMaster>();
            long rowsAffected = 0;
            try
            {
                objDesignType = context.DesignTypeMaster.Where(b => b.DesignTypeName == designTypeMaster.DesignTypeName).ToList();
                if (!objDesignType.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@DesignTypeName", Value = designTypeMaster.DesignTypeName },
                    new SqlParameter { ParameterName = "@ServiceID", Value = designTypeMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = designTypeMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = designTypeMaster.ProductID },
                    new SqlParameter { ParameterName = "@Display", Value = designTypeMaster.Display },
                    new SqlParameter { ParameterName = "@DesignImage", Value = designTypeMaster.DesignImage },
                };
                    context.Database.ExecuteSqlRaw("exec df_Insert_DesignType_v1 @DesignTypeName, @ServiceID, @CategoryID, @ProductID, @Display, @DesignImage", parms.ToArray());
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

        public long UpdateDesignType(DataContext context, DesignTypeMaster designTypeMaster)
        {
            List<DesignTypeMaster> objDesignType = new List<DesignTypeMaster>();
            long rowsAffected = 0;
            try
            {
                objDesignType = context.DesignTypeMaster.Where(b => (b.DesignTypeName == designTypeMaster.DesignTypeName && b.ID != designTypeMaster.ID)).ToList();
                if (!objDesignType.Any())
                {
                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@ID", Value = designTypeMaster.ID },
                    new SqlParameter { ParameterName = "@DesignTypeName", Value = designTypeMaster.DesignTypeName },
                    new SqlParameter { ParameterName = "@ServiceID", Value = designTypeMaster.ServiceID },
                    new SqlParameter { ParameterName = "@CategoryID", Value = designTypeMaster.CategoryID },
                    new SqlParameter { ParameterName = "@ProductID", Value = designTypeMaster.ProductID },
                    new SqlParameter { ParameterName = "@Display", Value = designTypeMaster.Display },
                    new SqlParameter { ParameterName = "@DesignImage", Value = designTypeMaster.DesignImage },
                };
                    context.Database.ExecuteSqlRaw("exec df_Update_DesignType_v1 @ID, @DesignTypeName, @ServiceID, @CategoryID, @ProductID, @Display, @DesignImage", parms.ToArray());
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

        #region Material Setup
        public List<ProductsByProductID> GetProductsByProductID(DataContext context, ProductsRequest productsRequest)
        {
            List<ProductsByProductID> productsByProducts = new List<ProductsByProductID>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ProductIDs", Value = productsRequest.ProductID }
                };
                productsByProducts = context.ProductsByProductID.FromSqlRaw("exec df_Get_ProductsByProductID @ProductIDs", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return productsByProducts;
        }

        public List<ProductsByProductID> GetProductsByBrandProductID(DataContext context, ProductBarndRequest productBarndRequest)
        {
            List<ProductsByProductID> productsByProducts = new List<ProductsByProductID>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ProductID", Value = productBarndRequest.ProductID },
                new SqlParameter { ParameterName = "@BrandID", Value = productBarndRequest.BrandID }
                };
                productsByProducts = context.ProductsByProductID.FromSqlRaw("exec df_Get_ProductsByProductID @ProductID, @BrandID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return productsByProducts;
        }

        public List<BrandsByProductID> GetBrandsByProductID(DataContext context, ProductsRequest productsRequest)
        {
            List<BrandsByProductID> brandsByProductID = new List<BrandsByProductID>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@ProductIDs", Value = productsRequest.ProductID }
                };
                brandsByProductID = context.BrandsByProductID.FromSqlRaw("exec df_Get_BrandsByProductID @ProductIDs", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return brandsByProductID;
        }

        public List<MaterialSetupMasterGet> GetMaterialSetup(DataContext context)
        {
            List<MaterialSetupMasterGet> materialSetupMasterGet = new List<MaterialSetupMasterGet>();
            try
            {
                materialSetupMasterGet = context.MaterialSetupMasterGet.FromSqlRaw("exec df_Get_MaterialSetup").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return materialSetupMasterGet;
        }

        public List<MaterialProductMappingGet> GetMaterialProductMapping(DataContext context, MaterialProductMapping materialProductMapping)
        {
            List<MaterialProductMappingGet> materialProductMappingGet = new List<MaterialProductMappingGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@MaterialSetupID", Value = materialProductMapping.MaterialSetupID }
                };
                materialProductMappingGet = context.MaterialProductMappingGet.FromSqlRaw("exec df_Get_MaterialSetupMapping @MaterialSetupID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return materialProductMappingGet;
        }


        public List<MaterialProductMappingGet> GetMaterialByDesignTypeID(DataContext context, DesignTypeRequest designTypeRequest)
        {
            List<MaterialProductMappingGet> materialProductMappingGet = new List<MaterialProductMappingGet>();
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>
                {
                new SqlParameter { ParameterName = "@DesignTypeID", Value = designTypeRequest.DesignTypeID }
                };
                materialProductMappingGet = context.MaterialProductMappingGet.FromSqlRaw("exec df_Get_MaterialByDesignTypeID @DesignTypeID", parms.ToArray()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return materialProductMappingGet;
        }



        public long InsertMaterialSetup(DataContext context, MaterialSetupRequest materialSetupRequest)
        {
            long rowsAffected = 0;
            try
            {
                if (materialSetupRequest.MaterialSetupMaster != null)
                {
                    List<MaterialSetupMaster> materialSetupMasterGet = context.MaterialSetupMaster.Where(b => b.DesignTypeID == materialSetupRequest.MaterialSetupMaster.DesignTypeID).ToList();

                    if (!materialSetupMasterGet.Any())
                    {
                        if (materialSetupRequest.MaterialSetupMaster != null)
                        {
                            context.MaterialSetupMaster.Add(materialSetupRequest.MaterialSetupMaster);
                            context.SaveChanges();
                            rowsAffected = 1;
                        }
                        if (materialSetupRequest.MaterialProductMappings != null && materialSetupRequest.MaterialSetupMaster != null && materialSetupRequest.MaterialSetupMaster.ID != 0)
                        {
                            foreach (MaterialProductMapping mpm in materialSetupRequest.MaterialProductMappings)
                            {
                                mpm.MaterialSetupID = materialSetupRequest.MaterialSetupMaster.ID;
                                context.MaterialProductMapping.Add(mpm);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        rowsAffected = -2;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rowsAffected;
        }

        public long UpdateMaterialSetup(DataContext context, MaterialSetupRequest materialSetupRequest)
        {
            long rowsAffected = 0;
            try
            {
                if (materialSetupRequest.MaterialSetupMaster != null)
                {
                    List<MaterialSetupMaster> materialSetupMasterGet = context.MaterialSetupMaster.Where(b => (b.DesignTypeID == materialSetupRequest.MaterialSetupMaster.DesignTypeID && b.ID != materialSetupRequest.MaterialSetupMaster.ID)).ToList();
                    if (!materialSetupMasterGet.Any())
                    {
                        if (materialSetupRequest.MaterialSetupMaster != null)
                        {
                            context.MaterialSetupMaster.Update(materialSetupRequest.MaterialSetupMaster);
                            context.SaveChanges();
                            rowsAffected = 1;
                        }
                        if (materialSetupRequest.MaterialProductMappings != null && materialSetupRequest.MaterialSetupMaster != null && materialSetupRequest.MaterialSetupMaster.ID != 0)
                        {
                            List<MaterialProductMapping> materialProductMappings = context.MaterialProductMapping.Where(el => el.MaterialSetupID == materialSetupRequest.MaterialSetupMaster.ID).ToList();
                            context.MaterialProductMapping.RemoveRange(materialProductMappings);
                            foreach (MaterialProductMapping mpm in materialSetupRequest.MaterialProductMappings)
                            {
                                mpm.MaterialSetupID = materialSetupRequest.MaterialSetupMaster.ID;
                                context.MaterialProductMapping.Add(mpm);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        rowsAffected = -2;
                    }
                }
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
                rowsAffected = context.Database.ExecuteSqlRaw("exec df_Insert_PostNewDesign @LabourCost, @ServiceID, @CategoryID, @ProductID, @DesignTypeID, @WorkLocationID, @DesignNumber, @DesignImage, @Display", parms.ToArray());
                if (rowsAffected > 0)
                {
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

        public long UpdatePostNewDesign(DataContext context, PostNewDesignMaster postNewDesignMaster)
        {
            long rowsAffected = 0;
            try
            {
                PostNewDesignMaster postNewDesignMasterCurrent = context.PostNewDesignMaster.Where(el => el.ID == postNewDesignMaster.ID).ToList().First();

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
                rowsAffected = context.Database.ExecuteSqlRaw("exec df_Update_PostNewDesign @ID, @LabourCost, @ServiceID, @CategoryID, @ProductID, @DesignTypeID, @WorkLocationID, @DesignNumber, @DesignImage, @Display", parms.ToArray());
                if (rowsAffected > 0)
                {
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

        private static async Task DeleteObjectNonVersionedBucketAsync(string bucketName, string keyName)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                var client = new AmazonS3Client("AKIAZGRJKC5EP34PJHE7", "4pxNounxWTG7ua6knQ9A7YRzmvelmLuwju0PLc0k", RegionEndpoint.APSouth1);
                await client.DeleteObjectAsync(deleteObjectRequest);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
        }

        #endregion
    }
}
