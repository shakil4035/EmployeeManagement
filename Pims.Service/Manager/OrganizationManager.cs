using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.Model.SetupModule;
using Pims.Core.ViewModel.Setup_Module;
using Pims.Persistence.Database_File;

namespace Pims.Service.Manager
{
    public  class OrganizationManager
    {
        public PimsDbContext _dbContext;

        public OrganizationManager()
        {
            _dbContext = new PimsDbContext();
        }

        public IEnumerable<OrganizationViewModel> GetAll()
        {
            var entites = _dbContext.Organizations.ToList()
                .Select(Mapper.Map<Organization, OrganizationViewModel>);
            return entites;
        }

        public OrganizationViewModel Get(int id)
        {
            var entity = _dbContext.Organizations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Organization, OrganizationViewModel>(entity));
        }

        public int Add(OrganizationViewModel vm)
        {
            var entity = (Mapper.Map<OrganizationViewModel, Organization>(vm));
            _dbContext.Organizations.Add(entity);
            var isSave = _dbContext.SaveChanges();
            return isSave;
        }

        public int Update(int id, OrganizationViewModel vm)
        {
            var entity = _dbContext.Organizations.SingleOrDefault(c => c.Id == id);
            Mapper.Map( vm,entity);
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

        public int Delete(int id)
        {
            var entity = _dbContext.Organizations.SingleOrDefault(c => c.Id == id);
            _dbContext.Organizations.Remove(entity);
            var isDelete = _dbContext.SaveChanges();
            return isDelete;
        }
    }
}
