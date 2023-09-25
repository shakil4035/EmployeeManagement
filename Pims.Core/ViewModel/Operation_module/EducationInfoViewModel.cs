using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.Operation_module
{
    public class EducationInfoViewModel
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
        public string NameEnglish { get; set; }
        public string PhoneNumber { get; set; }
    }
}
