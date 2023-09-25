using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.Model;
using Pims.Core.ViewModel;
using Pims.Persistence.Database_File;

namespace Pims.Service.Manager
{
     public  class DepartmentManager
     {
         public PimsDbContext _dbContext;

         public DepartmentManager()
         {
             _dbContext = new PimsDbContext();
         }

         public DepartmentViewModel Get(int id)
         {
             var entitiy = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
             //not use automapper
             //var department = new DepartmentViewModel()
             //{
             //    Id = entites.Id,
             //    Name = entites.Name,
             //    Code = entites.Code,
             //    IsActive = entites.IsActive
             //};
             return (Mapper.Map<Department, DepartmentViewModel>(entitiy));
         }

         public IEnumerable<DepartmentViewModel> GetAll()
         {
             var entites = _dbContext.Departments.ToList()
                 .Select(Mapper.Map<Department,DepartmentViewModel>);
             return entites;
             //not use automapper

             //var list = new List<DepartmentViewModel>();
             //foreach (var model in entites)
             //{
             //    var vm = new DepartmentViewModel()
             //    {
             //        Id=model.Id,
             //        Name=model.Name,
             //        Code = model.Code,
             //        IsActive = model.IsActive
             //    };
             //    list.Add(vm);
             //}

             //return list;
         }

         public int Add(DepartmentViewModel vm)
         {
             //not use automapper
             //var entity = new Department()
             //{
             //    Id = vm.Id,
             //    Name = vm.Name,
             //    Code = vm.Code,
             //    IsActive = vm.IsActive
             //};
             //_dbContext.Departments.Add(entity);
             //var isSave = _dbContext.SaveChanges();
             //return isSave;
             var entity = Mapper.Map<DepartmentViewModel, Department>(vm);
             _dbContext.Departments.Add(entity);
             var isSave = _dbContext.SaveChanges();
             return isSave;
         }

         public int Update(int id, DepartmentViewModel vm)
         {
             var entity = _dbContext.Departments.SingleOrDefault(c => c.Id ==id);
             Mapper.Map(vm,entity);
             var isUpdate = _dbContext.SaveChanges();
             return isUpdate;
         }

         public int Delete(int id)
         {
             var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
             _dbContext.Departments.Remove(entity);
             var isDelete = _dbContext.SaveChanges();
             return isDelete;
         }
     }
}
