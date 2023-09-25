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
   public  class UniversityManager
   {
       public PimsDbContext _dbContext;

       public UniversityManager()
       {
           _dbContext = new PimsDbContext();
       }

       public int Add(UniversityViewModel vm)
       {
           var entity = new University()
           {
               Name = vm.Name
           };
           _dbContext.Universities.Add(entity);
           var isSave = _dbContext.SaveChanges();
           return isSave;
       }

       public int Update(int id, UniversityViewModel vm)
       {
           var entity = _dbContext.Universities.SingleOrDefault(c => c.Id == id);
           entity.Id = entity.Id;
           entity.Name = vm.Name;
           var isUpdate = _dbContext.SaveChanges();
           return isUpdate;
       }

       public UniversityViewModel Get(int id)
       {
           var entity = _dbContext.Universities.SingleOrDefault(c => c.Id == id);
           var university = new UniversityViewModel()
           {
               Id = entity.Id,
               Name = entity.Name
           };
           return university;
       }

       public IEnumerable<UniversityViewModel> GetAll()
       {
           var enities = _dbContext.Universities.ToList();
           var list = new List<UniversityViewModel>();
           foreach (var model in enities)
           {
               var university = new UniversityViewModel()
               {
                   Id = model.Id,
                   Name = model.Name
               };
               list.Add(university);

           }

           return list;
       }

       public int Delete(int id)
       {
           var entity = _dbContext.Universities.SingleOrDefault(c => c.Id == id);
           _dbContext.Universities.Remove(entity);
           var isDelete = _dbContext.SaveChanges();
           return isDelete;
       }
   }
}
