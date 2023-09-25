using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pims.Core.Model.SetupModule;
using Pims.Core.ViewModel.Setup_Module;
using Pims.Persistence.Database_File;

namespace Pims.Service.Manager
{
   public  class DesignationManager
   {
       public PimsDbContext _dbContext;

       public DesignationManager()
       {
           _dbContext = new PimsDbContext();
       }

       public IEnumerable<DeginationViewModel> GetAll()
       {
           var entites = _dbContext.Designations.ToList();
           var list = new List<DeginationViewModel>();
           foreach (var model in entites)
           {
               var designation = new DeginationViewModel()
               {
                   Name = model.Name,
                   Id = model.Id,
                   IsActive = model.IsActive
               };
                list.Add(designation);
           }

           return list;
       }

       public DeginationViewModel Get(int id)
       {
           var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
           var desination = new DeginationViewModel()
           {
               Id=entity.Id,
               Name = entity.Name,
               IsActive = entity.IsActive
           };
           return desination;
       }

       public int Add(DeginationViewModel vm)
       {
           var designation = new Designation()
           {
               Id = vm.Id,
               Name = vm.Name,
               IsActive = vm.IsActive
           };
           _dbContext.Designations.Add(designation);
           var isSave = _dbContext.SaveChanges();
           return isSave;
       }

       public int Update( DeginationViewModel vm)
       {
           var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == vm.Id);
           entity.Id = vm.Id;
           entity.Name = vm.Name;
           entity.IsActive = vm.IsActive;
           var isUpdate = _dbContext.SaveChanges();
           return isUpdate;
       }

       public int Delete(int id)
       {
           var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
           _dbContext.Designations.Remove(entity);
           var isDelete = _dbContext.SaveChanges();
           return isDelete;
       }
    }
}
