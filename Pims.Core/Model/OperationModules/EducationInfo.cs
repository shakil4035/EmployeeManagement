using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pims.Core.CommonModule;
using Pims.Core.Model.SetupModule;

namespace Pims.Core.Model.OperationModules
{
     public class EducationInfo:BaseDomain
    {
        public int Id { set; get; }
        public int GenarelInformationId { set; get; }
        public GenarelInformation GenarelInformation { set; get; }
        public int UniversityId { set; get; }
        public University University { set; get; }
        public string ExamName { set; get; }
        public DateTime PassingYear { set; get; }
        public string SubjectName { set; get; }
        public Double Result { set; get; }
        public string SchoolOrCollage { set; get; }
    }
}
