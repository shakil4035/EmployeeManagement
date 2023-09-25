using Pims.Core.Model;
using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pims.Core.ViewModel.Operation_module
{
   public  class GenarelInformationViewModel
    {
        public int Id { set; get; }
        [Required]
        public string EmployeeId { set; get; }
        public string NameBangla { set; get; }
        public string NameEnglish { set; get; }
        public string FatherName { set; get; }
        public string MotherName { set; get; }
        [Required]
        public string BirthDate { set; get; }
        public string BirthPlace { set; get; }
        [Required]
        public string NationalId { set; get; }
        public string Nationality { set; get; }
        public string PresentAddress { set; get; }
        public string PermanentAddress { set; get; }
        public string BloodGroup { set; get; }
        public string Religion { set; get; }
        public int BasicSalary { get; set; }
        public string Gender { set; get; }
        public string MeritialStatus { set; get; }
        [Required]
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public Department Department { set; get; }
        public int DepartmentId { set; get; }
        public string Position { set; get; }
        public Designation Designation { set; get; }
        public int DesignationId { set; get; }
        public string JobJoiningDate { set; get; }
    }
}
