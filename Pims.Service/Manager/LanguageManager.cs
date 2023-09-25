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
    public  class LanguageManager
    {
        public PimsDbContext _dbContext;

        public LanguageManager()
        {
            _dbContext = new PimsDbContext();
        }

        public int Add(LanguageViewModel vm)
        {
            var entity = (Mapper.Map<LanguageViewModel, Language>(vm));
            _dbContext.Languages.Add(entity);
            var isSave = _dbContext.SaveChanges();
            return isSave;
        }

        public int Update(int id, LanguageViewModel vm)
        {
            var entity = _dbContext.Languages.SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm,entity);
            var isUpdate = _dbContext.SaveChanges();
            return isUpdate;
        }

        public int Delete(int id)
        {
            var entity = _dbContext.Languages.SingleOrDefault(c => c.Id == id);
            _dbContext.Languages.Remove(entity);
            var isDelete = _dbContext.SaveChanges();
            return isDelete;
        }

        public IEnumerable<LanguageViewModel> GetAll()
        {
            var enities = _dbContext.Languages.ToList()
                .Select(Mapper.Map<Language, LanguageViewModel>);
            return enities;
        }

        public LanguageViewModel Get(int id)
        {
            var entity = _dbContext.Languages.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<Language,LanguageViewModel>(entity));
        }
    }
}
