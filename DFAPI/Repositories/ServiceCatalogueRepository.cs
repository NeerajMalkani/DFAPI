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

    }
}
