using Pims.Persistence.Database_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.Model.OperationModules;
using Pims.Core.ViewModel.Operation_module;

namespace Pims.Service.Manager.OperationModule
{
   public  class EducationManager
   {
       public PimsDbContext _dbContext;

       public EducationManager()
       {
           _dbContext = new PimsDbContext();
       }

       public EducationInfoViewModel Get(int id)
       {
           var entity = _dbContext.EducationInfos.SingleOrDefault(c => c.Id == id);
           return (Mapper.Map<EducationInfo, EducationInfoViewModel>(entity));
       }

       public IEnumerable<EducationInfoViewModel> GetAll()
       {
           var entity = _dbContext.EducationInfos.Include("University")
               .Where(c=>c.IsDelete==false).ToList()
               .Select(Mapper.Map<EducationInfo,EducationInfoViewModel>);
           return entity;

       }

       public int Add(EducationInfoViewModel vm)
       {
           var entity = Mapper.Map<EducationInfoViewModel, EducationInfo>(vm);
           entity.CreateBy = "user";
           entity.CreateDate=DateTime.Now;
           entity.IsDelete = false;
           _dbContext.EducationInfos.Add(entity);
           var isSave = _dbContext.SaveChanges();
           return isSave;
       }

       public int Update(int id, EducationInfoViewModel vm)
       {
           var entity = _dbContext.EducationInfos.SingleOrDefault(c => c.Id == id);
           Mapper.Map(vm, entity);
           entity.UpdateBy = "user";
           entity.UpdateDate=DateTime.Now;
           var isUpdate = _dbContext.SaveChanges();
           return isUpdate;
       }

       public int Delete(int id)
       {
           var entity = _dbContext.EducationInfos.SingleOrDefault(c => c.Id == id);
           entity.IsDeleteBy = "user";
           entity.DeleteDate=DateTime.Now;
           entity.IsDelete = true;
           var isUpdate = _dbContext.SaveChanges();
           return isUpdate;
        }
    }
}
