using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pims.Core.Model.OperationModules;
using Pims.Core.ViewModel.Operation_module;
using Pims.Persistence.Database_File;

namespace Pims.Service.Manager.OperationModule
{
     public class GeneralInfo
     {
         public PimsDbContext _dbContext;

         public GeneralInfo()
         {
             _dbContext = new PimsDbContext();
         }
         public string GenerateEmployeId()
         {
             int parsonalNo = 0;

             var list = _dbContext.GenarelInformations.ToList()
                 .OrderByDescending(c => c.Id).FirstOrDefault();

             if (list == null)
             {
                 var code = "BESL-" + "00001";
                 return code;
             }

             {
                 string[] parts = list.EmployeeId.Split('-');
                 parsonalNo = Convert.ToInt32(parts[1]);
             }

             var traineeParsonalNo = "BESL-" + (parsonalNo + 1).ToString().PadLeft(5, '0');
             return traineeParsonalNo;

         }

         public GenarelInformationViewModel Get(int id)
         {
             var entity = _dbContext.GenarelInformations.SingleOrDefault(c => c.Id == id);
             return (Mapper.Map<GenarelInformation, GenarelInformationViewModel>(entity));
             
         }

         public IEnumerable<GenarelInformationViewModel> GetAll()
         {
             var entites = _dbContext.GenarelInformations.Include("Department").Include("Designation").ToList()
                 .Select(Mapper.Map<GenarelInformation, GenarelInformationViewModel>);
             return entites;
         }

         public int Add(GenarelInformationViewModel vm)
         {
             var entity = Mapper.Map<GenarelInformationViewModel, GenarelInformation>(vm);
             entity.CreateBy = "User";
             entity.CreateDate=DateTime.Now;
             entity.IsDelete = false;
             _dbContext.GenarelInformations.Add(entity);
              _dbContext.SaveChanges();
             return entity.Id;
         }

         public int Update(int id, GenarelInformationViewModel vm)
         {
             var entity = _dbContext.GenarelInformations.SingleOrDefault(c => c.Id == id);
             Mapper.Map(vm, entity);
             entity.UpdateBy = "User";
             entity.UpdateDate=DateTime.Now;
              _dbContext.SaveChanges();
             return entity.Id;
         }
         public int Delete(int id)
         {
             var entity = _dbContext.GenarelInformations.SingleOrDefault(c => c.Id == id);
             entity.IsDeleteBy = "User";
             entity.DeleteDate = DateTime.Now;
             entity.IsDelete = true;
             _dbContext.SaveChanges();
             return entity.Id;
         }


    }
}
