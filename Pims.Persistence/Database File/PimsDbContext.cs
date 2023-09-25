using Pims.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModule;

namespace Pims.Persistence.Database_File
{
     public class PimsDbContext :DbContext
    {
        //setup Module
        public DbSet<Department> Departments { set; get; }
        public DbSet<Designation>Designations { set; get; }
        public DbSet<Organization>Organizations { set; get; }
        public DbSet<University>Universities { set; get; }
        public DbSet<Language>Languages { set; get; }

        //Operation Module
        public  DbSet<GenarelInformation> GenarelInformations { set; get; }
        public DbSet<EducationInfo>EducationInfos { set; get; }
    }
}
